using hf4_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace hf4_app.service
{

    static class Token
    {
        public static string Data {  get; set; }
    }
    class webHandler
    {
        private string baseUrl = "https://skol.molsen.one";
        

        public bool isLogin//tjekker om der er en token siden der kun er en token når man er logget ind
        {
            get
            {
                return !string.IsNullOrEmpty(Token.Data);
            }
        }

        static readonly HttpClient client = new HttpClient();

        private async Task<string> getAsync(string path)//laver en GET requst til api server med diget path og tjekker om den fåre status code 200(ok) tilbager
        {
            HttpResponseMessage response = await client.GetAsync(baseUrl + path);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                Token.Data = null;
            }
            return null;
        }
        private async Task<string> postAsync(string path, object data)//laver en POST requst til api server med diget path hvor den enbeder objet som JSON og tjekker om den fåre status code 200(ok) tilbager
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
                
            }else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                Token.Data = null;
            }
            return null;
        }

        public void logout()
        {
            Token.Data = null;

            SecureStorage.Default.Remove("token");
        }

        public async Task<bool> loginAsync(string userName,string password)
        {
            UserLogin Login = new UserLogin();
            Login.UserName = userName;
            Login.Password = password;
            string svare = await postAsync("/api/token", Login);
            if (!string.IsNullOrEmpty(svare))
            {
                Token.Data = svare;
                return true;
            }
            return false;
        }

        public async Task<bool> postAsyncWarehouse(Warehouse data)
        {           
            string svare = await postAsync(string.Format("/api/warehouse/?token={0}", Token.Data), data);
            if (!string.IsNullOrEmpty(svare))
            {
                return true;
            }
            return false;
        }
        public async Task<Warehouse> getAsyncWarehouse(int id)
        {
       
            string json = await getAsync(string.Format("/api/warehouse/?token={0}&id={1}", Token.Data, id.ToString()));
            return JsonSerializer.Deserialize<Warehouse>(json);
        }


        public async Task<bool> postAsyncCustomer(Customer data)
        {
  
            string svare = await postAsync(string.Format("/api/customer?token={0}", Token.Data), data);
            if (!string.IsNullOrEmpty(svare))
            {
                return true;
            }
            return false;
        }
        public async Task<Customer> getAsyncCustomer(int id)
        {

            
            string json = await getAsync(string.Format("/api/customer/?token={0}&id={1}", Token.Data, id.ToString()));
            return JsonSerializer.Deserialize<Customer>(json);
        }

        public async Task<bool> postAsyncPackageEvent(PackageEvents data)
        {

            string svare = await postAsync(string.Format("/api/packageevent/?token={0}", Token.Data), data);
            if (!string.IsNullOrEmpty(svare))
            {
                return true;
            }
            return false;
        }
        public async Task<PackageEvents> getAsyncPackageEvent(int id)
        {

            string json = await getAsync(string.Format("/api/packageevent/?token={0}&id={1}", Token.Data, id.ToString()));
            return JsonSerializer.Deserialize<PackageEvents>(json);
        }


        public async Task<bool> postAsyncPackage(Package data)
        {

            
            string svare = await postAsync(string.Format("/api/package/?token={0}", Token.Data), data);
            
            if (!string.IsNullOrEmpty(svare))
            {
                return true;
            }
            return false;
        }
        
        public async Task<PackageEvents[]> getListAsyncPackage(int id)
        {

            string json = await getAsync(string.Format("/api/allEvents/?token={0}&id={1}", Token.Data, id.ToString()));
            return JsonSerializer.Deserialize<PackageEvents[]>(json);
        }
        public async Task<Package> getAsyncPackage(int id)
        {


            string json = await getAsync(string.Format("/api/package/?token={0}&id={1}", Token.Data, id.ToString()));
            return JsonSerializer.Deserialize<Package>(json);
        }
      
        public async Task<Warehouse[]> getListAsyncWarehouse()
        {


            string json = await getAsync(string.Format("/api/allWarehouse/?token={0}", Token.Data));

            return JsonSerializer.Deserialize<Warehouse[]>(json);
        }
    }
}
