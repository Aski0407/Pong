using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Common;

//run cmd as administrator (rmb on cmd)
//netsh http add urlacl url=http://*:8080/ user=Nataly (Natal for laptop)

namespace PongHost
{
    internal class HttpConnection
    {

        private PongServer server;

        public HttpConnection(PongServer server)
        {
            this.server = server;
            try
            {
                Thread serverThread = new Thread(new ThreadStart(RunServer));
                serverThread.Name = "HTTP Server";
                serverThread.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        internal void RunServer()
        {
            string url = "http://*:8080/";
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
            Console.WriteLine("Server started. Listening on " + url);

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HandleRequest(context);
            }
        }

        internal void HandleRequest(HttpListenerContext context)
        {
            //will receive a string in the form of "http//(address)/login?[username]\r\n[password]"
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string path = request.Url.AbsolutePath;

            string data = GetRequestPostData(request);

            switch (path)
            {
                case "/login":
                    if (server.users.Login(data)) { SendResponse(response, null); Console.WriteLine("received: " + request); } //the username ans passowrd are correct
                    else { SendResponse(response, null, HttpStatusCode.Unauthorized); } //the username or password are not correct
                    break;
                case "/register":
                    if (Register(data)) { SendResponse(response, null); Console.WriteLine("received: " + request); }
                    else { SendResponse(response, "Username already registered", HttpStatusCode.BadRequest); }
                    break;
                case "/stats":
                    string username = request.QueryString["username"];
                    SendResponse(response, server.stats.GetStructAsString(username)); //should receive username only
                    break;
                default:
                    SendResponse(response, "Page not found", statusCode: HttpStatusCode.NotFound);
                    break;
            }
        }

        internal void SendResponse(HttpListenerResponse response, string content, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            //sends the response to the client
            if (content != null)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(content);
                response.ContentType = "application/octet-stream";
                response.StatusCode = (int)statusCode;
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
            }
            else
            {
                response.ContentLength64 = 0;
                response.StatusCode = (int)statusCode;
            }
            response.OutputStream.Close();
        }

        internal bool Register(string payload)
        //receives the username and password, returns true if registered, returns false if the username is taken
        {
            Dictionary<string, string> userPass = DecodeFormData(payload);
            string usernameCrypt = userPass.Keys.First();
            string passwordCrypt = userPass[usernameCrypt];
            byte[] usernameByte = Convert.FromBase64String(usernameCrypt);
            byte[] passwordByte = Convert.FromBase64String(passwordCrypt);
            string username = Cryptography.Decrypt(usernameByte);
            string password = Cryptography.Decrypt(passwordByte);
            if (server.users.AddUser(username, password))
            {
                server.stats.CreateNewEntry(username);
                return true;
            }
            return false;

        }
        internal static Dictionary<string, string> DecodeFormData(string encodedFormData)
        {
            var decodedData = new Dictionary<string, string>();

            string[] pairs = encodedFormData.Split('&');
            foreach (string pair in pairs)
            {
                string[] keyValue = pair.Split('=');
                if (keyValue.Length == 2)
                {
                    string key = Uri.UnescapeDataString(keyValue[0]);
                    string value = Uri.UnescapeDataString(keyValue[1]);
                    decodedData[key] = value;
                }
            }

            return decodedData;
        }

        public string GetRequestPostData(HttpListenerRequest request)
        {
            //receives the request url, returns the body of the request
            if (!request.HasEntityBody)
            {
                return null;
            }
            using (System.IO.Stream body = request.InputStream) // here we have data
            {
                using (var reader = new System.IO.StreamReader(body, request.ContentEncoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

    }
}

