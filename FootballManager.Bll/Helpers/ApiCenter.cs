using FootballManager.Bll.Concrete;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Bll.Helpers
{
    public static class ApiCenter
    {
        private static HttpClient client = new HttpClient();

        static ApiCenter()
        {
            client.BaseAddress = new Uri("https://localhost:44380/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static void BaseAddress(string url)
        {
            client.BaseAddress = new Uri(url);
        }
        public static void Authorization(string username, string pass) =>
            client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{pass}")));

        public static T getData<T>(EntityHttpResponse httpResponse) where T : class
        {
            return JsonConvert.DeserializeObject<T>(httpResponse.Jsondata);
        }

        public static async Task<EntityHttpResponse> CreateAsync<T>(T t, string uri) where T : class
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(uri, t);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<EntityHttpResponse>();
            return new EntityHttpResponse();
        }

        public static async Task<EntityHttpResponse> PostAsync<T>(string uri, T t) where T : class
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(uri, t);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<EntityHttpResponse>();
            return new EntityHttpResponse();
        }

        public static async Task<EntityHttpResponse> GetAsync(string controller)
        {
            HttpResponseMessage response = await client.GetAsync(controller);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<EntityHttpResponse>();
            return new EntityHttpResponse();
        }
        public static async Task<EntityHttpResponse> UpdateAsync<T>(T t, string uri) where T : class
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"{uri}", t);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<EntityHttpResponse>();
            return new EntityHttpResponse();
        }
        public static async Task<EntityHttpResponse> DeleteAsync(string id, string uri)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<EntityHttpResponse>();
            return new EntityHttpResponse();
        }
    }
}
