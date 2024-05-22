using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Dynamic;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Windows.Forms.VisualStyles;
using Common;

namespace PongClient
{
    public class MyHttpClient
    {
        private static readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
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
            var values = new Dictionary<string, string>
            {
                { username, password }
            };
            var content = new FormUrlEncodedContent(values);
            await this.Post("login", content);
        }

        public async Task Register(string username, string password)
        {
            var values = new Dictionary<string, string>
            {
                { username, password }
            };
            var content = new FormUrlEncodedContent(values);
            await this.Post("register", content);
        }

        public async Task<string> GetStats(string username)
        {
            var values = new Dictionary<string, string>
            {
                { "username", username }
            };
            var content = new FormUrlEncodedContent(values);
            return await this.Get("stats", content);
        }
        
        private async Task Post(string uri, HttpContent content)
        {
            //posts the request to the server. if it was successful, returns, else throws exception
            var response = await client.PostAsync(_url + uri, content);
            if(!response.IsSuccessStatusCode) 
            {
                throw new Exception(response.Content.ToString());
            }
            
        }

        private async Task<string> Get(string uri, HttpContent content)
        {
            var response = await client.PostAsync(_url + uri, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.StatusCode);
            }
            return await response.Content.ReadAsStringAsync();
        }
        

    }


}

