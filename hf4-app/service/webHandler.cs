using hf4_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace hf4_app.service
{
    class webHandler
    {
        private string baseUrl = "https://skol.molsen.one/";
        private string token;

        public bool isLogin
        {
            get
            {
                return !string.IsNullOrEmpty(token);
            }
        }

        static readonly HttpClient client = new HttpClient();

        private async Task<string> getAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(baseUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
        private async Task<string> postAsync(string path, object data)
        {
            HttpResponseMessage response = await client.PostAsync(baseUrl + path, new ByteArrayContent(Encoding.ASCII.GetBytes(JsonSerializer.Serialize(data))));
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string retuneData = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(retuneData))
                {
                    return "ok";
                }
                return retuneData;
                
            }
            return null;
        }

        public async Task<bool> login(string userName,string password)
        {
            UserLogin Login = new UserLogin();
            string svare = await postAsync("api/get/token", Login);
            if (!string.IsNullOrEmpty(svare))
            {
                token = svare;
                return true;
            }
            return false;
        }


    }
}
