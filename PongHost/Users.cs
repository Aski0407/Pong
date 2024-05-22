using System.Collections.Generic;
using System.Linq;
namespace PongHost
{
    internal class Users : FileHandler<string>
    {
        public Users() : base("data.txt")
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
            //receives the payload of the request string
            Dictionary<string, string> userPass = HttpServer.DecodeFormData(payload);
            string username = userPass.Keys.First();
            string password = userPass[username];

            if (this.data.TryGetValue(username, out string result))
            {
                return result == password;
            }
            return false; //username doesn't exist in database
        }

        internal bool AddUser(string username, string password)
        {
            if (data.TryGetValue(username, out string result)) { return false; }
            data.Add(username, password);
            SerializeData();
            return true;
        }

    }
}
