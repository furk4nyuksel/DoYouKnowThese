using DoYouNowThese.CommonModel.AppUserModel;
using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.DATA.Models;
using DoYouNowThese.PROVIDER.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DoYouNowThese.PROVIDER.Providers.AppUserOperation
{
   public class AppUserProvider
    {
        public InfrastructureModel<AppUserModel> GetLoginUser(AppUserLoginModel loginModel)
        {
            InfrastructureModel<AppUserModel> infrastructureModel = new InfrastructureModel<AppUserModel>();
            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                var serializePostModel = JsonConvert.SerializeObject(loginModel);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginModel.TokenKey);
                StringContent contentPost = new StringContent(serializePostModel, Encoding.UTF8,"application/json");
                HttpResponseMessage httpResponceMessage = client.PostAsync(ConnectionHelper.GetConnectionUrl() + "AppUser/GetUserToken/", contentPost).Result;
                httpResponceMessage.EnsureSuccessStatusCode();

                string stringResponce = httpResponceMessage.Content.ReadAsStringAsync().Result;

                infrastructureModel.ResultModel = JsonConvert.DeserializeObject<AppUserModel>(stringResponce);

                if (infrastructureModel.ResultModel != null)
                {
                    infrastructureModel.ResultStatus = true;
                }
                return infrastructureModel;
            }
        }

        public InfrastructureModel<AppUserInformationModel> GetById(AppUserLoginModel loginModel)
        {
            InfrastructureModel<AppUserInformationModel> infrastructureModel = new InfrastructureModel<AppUserInformationModel>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginModel.TokenKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                var serializePostModel = JsonConvert.SerializeObject(loginModel);

                StringContent contentPost = new StringContent(serializePostModel, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponceMessage = client.PostAsync(ConnectionHelper.GetConnectionUrl() + "AppUser/GetById/", contentPost).Result;
                
                httpResponceMessage.EnsureSuccessStatusCode();

                string stringResponce = httpResponceMessage.Content.ReadAsStringAsync().Result;

                infrastructureModel = JsonConvert.DeserializeObject<InfrastructureModel<AppUserInformationModel>>(stringResponce);

                if (infrastructureModel.ResultModel != null)
                {
                    infrastructureModel.ResultStatus = true;
                }
                return infrastructureModel;
            }
        }
    }
}
