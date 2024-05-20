﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
namespace PongHost
{
    internal class Users
    {
        private Dictionary<string, string> users;
        private HttpServer server;
        string file = "users.txt";

        public Users()
        {
            LoadUserData();//make sure to take it from the file later
        }

        internal void SerializeData() //used to create and update the file
        {
            if (users != null)
            {
                File.WriteAllLines(file,
                    users.Select(entry => entry.Key + " " + entry.Value).ToArray());
            }
        }

        internal void LoadUserData()
        {
            //loads data from file into the dictionary
            this.users = new Dictionary<string, string>();

            if (File.Exists(file))
            {
                try
                {

                    using (var stream = File.OpenText(file))
                    {
                        string line;
                        while ((line = stream.ReadLine()) != null)
                        {
                            string[] parts = line.Split(' ');
                            if (parts.Length == 2)
                            {
                                string username = parts[0].Trim();
                                string password = parts[1].Trim();
                                this.users[username] = password;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading user data: {ex.Message}", "Error");
                }
            }
        }

        internal bool Login(string payload)
        {
            //receives the payload of the request string
            Dictionary<string, string> userPass = DecodeFormData(payload);
            string username = userPass.Keys.First();
            string password = userPass[username];

            if (this.users.TryGetValue(username, out string result))
            {
                return result == password;
            }
            return false; //username doesn't exist in database
        }

        internal bool Register(string payload)
        //receives the username and password, returns true if registered, returns false if the username is taken
        {
            Dictionary<string, string> userPass = DecodeFormData(payload);
            string username = userPass.Keys.First();
            string password = userPass[username];
            /*
            string[] userPass = payload.Split(new string[] { Common.Protocol.UserPassDelimiter }, StringSplitOptions.None);

            string username = userPass[0];
            string password = userPass[1];
            */
            if (this.users.TryGetValue(username, out string result)) { return false; }
            users.Add(username, password);
            SerializeData();
            return true;
        }
        internal Dictionary<string, string> DecodeFormData(string encodedFormData)
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

    }
}
