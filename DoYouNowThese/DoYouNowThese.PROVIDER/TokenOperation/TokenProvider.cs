using DoYouNowThese.PROVIDER.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DoYouNowThese.PROVIDER.TokenOperation
{
   public class TokenProvider
    {
        public string GetAnonimToken()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                string userName = JsonConvert.SerializeObject(Guid.NewGuid().ToString());

                StringContent content = new StringContent(userName, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponceMessage = client.PostAsync(ConnectionHelper.GetConnectionUrl() + "Token/GetAnonimToken/", content).Result;
                httpResponceMessage.EnsureSuccessStatusCode();

                string stringResponce = httpResponceMessage.Content.ReadAsStringAsync().Result;

                return stringResponce;
            }
        }
    }
}
