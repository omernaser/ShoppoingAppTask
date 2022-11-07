using ShoppoingAppTask.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShoppoingAppTask.Helpers;

namespace ShoppoingAppTask.Services
{
    public static class WebAPI
    {
        static readonly HttpClient client = new HttpClient();
        public static string BaseAppliocationURL = "http://192.168.1.22/orderlist/";
        public static async Task<HttpResponseMessage> Login(string username, string password)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StringContent(username), $"\"username\"");
            content.Add(new StringContent(password), $"\"password\"");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var obj = new
            {
                username = username,
                password = password
            };
            var jsonData = JsonConvert.SerializeObject(obj);
            var content1 = new StringContent(jsonData , Encoding.UTF8, "application/json"); 
            return await client.PostAsync($"{BaseAppliocationURL}api/authenticate/login", content1);
        }
        public static async Task<HttpResponseMessage> SubmitOrders(OrdersDBModel orders)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.GetString(Constants.TokenKey));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonData = JsonConvert.SerializeObject(new{Quantity=orders.Quantity.ToString(),Amount=(int)orders.OrderAmount,Description=orders.ClientDescription});
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            return await client.PostAsync($"{BaseAppliocationURL}api/Order/create", content);
        }


    }
}
