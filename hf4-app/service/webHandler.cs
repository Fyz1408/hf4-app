using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hf4_app.service
{
    class webHandler
    {
        private string baseUrl = "https://skol.molsen.one/";
        private string token;

        public bool isLogin { get
            {
                return !string.IsNullOrEmpty(token);
            } }

        static readonly HttpClient client = new HttpClient();

        private async Task<string> get(string path)
        {
            HttpResponseMessage response = await client.GetAsync(baseUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
        private async Task<string> post(string path,string data)
        {
            HttpResponseMessage response = await client.PostAsync(baseUrl + path, new ByteArrayContent(Encoding.ASCII.GetBytes(data)));
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }

        
    }
}
