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
        public InfrastructureModel<AppUserModel> GetLoginUser(AppUserLoginModel loginModel)
        {
            InfrastructureModel<AppUserModel> resultModel = new InfrastructureModel<AppUserModel>();
            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                var serializePostModel = JsonConvert.SerializeObject(loginModel);

                StringContent contentPost = new StringContent(serializePostModel, Encoding.UTF8,"application/json");
                HttpResponseMessage httpResponceMessage = client.PostAsync(ConnectionHelper.GetConnectionUrl() + "Token/GetUserToken/", contentPost).Result;
                httpResponceMessage.EnsureSuccessStatusCode();

                string stringResponce = httpResponceMessage.Content.ReadAsStringAsync().Result;

                resultModel = JsonConvert.DeserializeObject<InfrastructureModel<AppUserModel>>(stringResponce);
                return resultModel;
            }
        }
    }
}
