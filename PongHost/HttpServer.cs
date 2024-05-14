using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace PongHost
{
    internal class HttpServer
    {
        private Users Users;
        public HttpServer()
        {
            this.Users = new Users();
        }
        internal void runServer()
        {
            string url = "http://localhost:8080/";
            using (HttpListener listener = new HttpListener())
            {
                listener.Prefixes.Add(url);
                listener.Start();
                Console.WriteLine("Server started. Listening on " + url);

                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    HandleRequest(context);
                }
            }

        }
        internal void HandleRequest(HttpListenerContext context)
        {
            //will receive a string in the form of "http//(address)/login?[username]\r\n[password]"
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            

            string path = request.Url.AbsolutePath;

            switch (path)
            {
                case "/login":
                    if (this.Users.Login(GetRequestPostData(request))) { SendResponse(response, null); } //the username ans passowrd are correct
                    else { SendResponse(response, null, HttpStatusCode.Forbidden); } //the username or password are not correct
                    break;
                case "/register":
                    if (this.Users.Register(GetRequestPostData(request))) { SendResponse(response, null); }
                    else { SendResponse(response, null, HttpStatusCode.Forbidden); }
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
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
                response.ContentType = "text/plain";
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



        public static string GetRequestPostData(HttpListenerRequest request)
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

