using DoYouNowThese.CommonModel.AppUserModel;
using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.DATA.Models;
using DoYouNowThese.PROVIDER.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DoYouNowThese.PROVIDER.Providers.AppUserOperation
{
   public class AppUserProvider
    {
        public InfrastructureModel<AppUser> GetLoginUser(AppUserLoginModel loginModel)
        {
            InfrastructureModel<AppUser> resultModel = new InfrastructureModel<AppUser>();
            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage httpResponceMessage = client.GetAsync(ConnectionHelper.GetConnectionUrl() + "Token/GetUserToken/").Result;
                httpResponceMessage.EnsureSuccessStatusCode();

                string stringResponce = httpResponceMessage.Content.ReadAsStringAsync().Result;

                resultModel = JsonConvert.DeserializeObject<InfrastructureModel<AppUser>>(stringResponce);
                return resultModel;
            }
        }
    }
}
