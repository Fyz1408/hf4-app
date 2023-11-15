using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hf4_app.service
{
    class webHandler
    {
        private string baseUrl = "https://skol.molsen.one";
        private string token;

        static readonly HttpClient client = new HttpClient();

        private async Task get(string path)
        {
            HttpResponseMessage response = await client.GetAsync(baseUrl+path);

        }
    }
}
