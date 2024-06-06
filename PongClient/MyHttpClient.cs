using System.Security.Cryptography;
using System.Text;
using Common;

namespace PongClient
{
    public class MyHttpClient
    {
        private static readonly HttpClient client = new HttpClient();
        private string _url; //server url

        public MyHttpClient(string serverUrl)
        {
            if (!serverUrl.EndsWith("/"))
            {
                serverUrl += "/";
            }
            this._url = serverUrl;
        }

        public async Task Login(string username, string password) //sends user's username and password
        {
            string hashPass = HashString(password);
            byte[] encryptedUserByte = Cryptography.Encrypt(username);
            byte[] encryptedPassByte = Cryptography.Encrypt(hashPass);
            string encryptedUser = Convert.ToBase64String(encryptedUserByte);
            string encryptedHashPass = Convert.ToBase64String(encryptedPassByte);
            var values = new Dictionary<string, string>
            {
                { encryptedUser, encryptedHashPass }
            };
            var content = new FormUrlEncodedContent(values);
            await this.Post("login", content);
        }

        public async Task Register(string username, string password)
        {
            string hashPass = HashString(password);
            byte[] encryptedUserByte = Cryptography.Encrypt(password);
            byte[] encryptedPassByte = Cryptography.Encrypt(hashPass);
            string encryptedUser = Convert.ToBase64String(encryptedUserByte);
            string encryptedHashPass = Convert.ToBase64String(encryptedPassByte);
            var values = new Dictionary<string, string>
            {
                { encryptedUser, encryptedHashPass }
            };
            var content = new FormUrlEncodedContent(values);
            await this.Post("register", content);
        }

        public async Task<string> GetStats(string username)
        {
            byte[] message =  await this.Get("stats?username=" + username);
            return Encoding.UTF8.GetString(message);
        }

        private async Task Post(string uri, HttpContent content)
        {
            //posts the request to the server. if it was successful, returns, else throws exception
            var response = await client.PostAsync(_url + uri, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.Content.ToString());
            }

        }

        public async Task<byte[]> Get(string uri)
        {
            using HttpResponseMessage response = await client.GetAsync(_url + uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.StatusCode);
            }

            return await response.Content.ReadAsByteArrayAsync();
        }

        private byte[] Hash(string message) //receives the message string and makes it into a hash byte array.
        {
            using (HashAlgorithm sha = SHA256.Create())
            {
                return sha.ComputeHash(Encoding.UTF8.GetBytes(message));
            }
        }

        private string HashString(string message) //receives the string and returns it hashed
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in Hash(message))
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}

