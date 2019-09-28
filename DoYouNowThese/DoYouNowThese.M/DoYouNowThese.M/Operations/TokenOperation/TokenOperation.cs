using DoYouNowThese.M.Dependencies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DoYouNowThese.M.Operations.TokenOperation
{
    public class TokenOperation
    {
        public string _conString = ConnectionStrings.url;

        public string  GetAnonimToken()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                string userName = JsonConvert.SerializeObject(Guid.NewGuid().ToString());

                StringContent content = new StringContent(userName,Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponceMessage = client.PostAsync(_conString + "Token/GetAnonimToken/",content).Result;
                httpResponceMessage.EnsureSuccessStatusCode();

                string stringResponce = httpResponceMessage.Content.ReadAsStringAsync().Result;

                return stringResponce;
            }
        }
    }
}
