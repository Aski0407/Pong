﻿using System;
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

namespace PongClient
{
    internal class HttpClient
    {
        private static readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        private string _url; //server url

        public HttpClient(string serverUrl)
        {
            if (!serverUrl.EndsWith("/"))
            {
                serverUrl += "/";
            }
            this._url = serverUrl;
        }

        internal void Login(string username, string password) //sends user's username and password
        {
            var values = new Dictionary<string, string>
            {
                { username, password }
            };
            var content = new FormUrlEncodedContent(values);
            this.Post("login", content);
        }

        internal async void Register(string username, string password)
        {
            var values = new Dictionary<string, string>
            {
                { username, password }
            };
            var content = new FormUrlEncodedContent(values);
            await this.Post("register", content);
        }
        private async Task<string> Post(string uri, HttpContent content)
        {
            //posts the request to the server. if it was successful, returns true, else false
            var response = await client.PostAsync(_url + uri, content);
            if(!response.IsSuccessStatusCode) {
                throw new Exception("Error " + response.StatusCode);
            }
            return await response.Content.ReadAsStringAsync();
        }


    }


}

