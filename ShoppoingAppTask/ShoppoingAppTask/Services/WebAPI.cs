using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShoppoingAppTask.Services
{
    public static class WebAPI
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetAsync(string url)
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return await response.Content.ReadAsStringAsync();
            else
                return null;
        }
    }
}
