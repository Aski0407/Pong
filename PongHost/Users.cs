using Common;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PongHost
{
    internal class Users : FileHandler<string>
    {
        internal HashSet<string> connectedUsers = new HashSet<string>();
        public Users() : base("users.txt")
        {
        }

        protected override string EntryToRow(KeyValuePair<string, string> entry)
        //inherited method, writes data into file
        {
            return entry.Key + " " + entry.Value;
        }

        protected override void RowToEntry(string line)
        //handles turning the file lines back into a dictionary
        {
            string[] parts = line.Split(' ');
            if (parts.Length == 2)
            {
                string username = parts[0].Trim();
                string password = parts[1].Trim();
                this.data[username] = password;
            }
        }

        internal bool Login(string payload)
        {
            //receives the payload of the request string, checks if the login is valid
            Dictionary<string, string> userPass = HttpConnection.DecodeFormData(payload);
            string usernameCrypt = userPass.Keys.First();
            string passwordCrypt = userPass[usernameCrypt];
            
            byte[] usernameByte = Convert.FromBase64String(usernameCrypt);
            byte[] passwordByte = Convert.FromBase64String(passwordCrypt);
            string username = Cryptography.Decrypt(usernameByte);
            string password = Cryptography.Decrypt(passwordByte);

            if (this.data.TryGetValue(username, out string result))
            {
                if (result == password)
                {
                    if (connectedUsers.Contains(username)) { return false; }
                    connectedUsers.Add(username);
                    return true;
                }
            }
            return false; //username doesn't exist in database
        }

        internal bool AddUser(string username, string password)
        //receives username and passowrd. checks if the username exists in the dictionary. returns true if it does. adds the username and password to the dictionary if it doesnt and returns true
        {
            if (data.TryGetValue(username, out string result)) { return false; }
            data.Add(username, password);
            SerializeData();
            return true;
        }

    }
}
