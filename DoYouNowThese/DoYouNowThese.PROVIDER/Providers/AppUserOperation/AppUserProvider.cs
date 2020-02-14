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
                HttpResponseMessage httpResponceMessage = client.PostAsync(ConnectionHelper.GetConnectionUrl() + "Token/GetUserToken/", contentPost).Result;
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

        public InfrastructureModel<bool> Update(AppUserInformationModel appUserInformationModel)
        {
            InfrastructureModel<bool> infrastructureModel = new InfrastructureModel<bool>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", appUserInformationModel.TokenKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                var serializePostModel = JsonConvert.SerializeObject(appUserInformationModel);

                StringContent contentPost = new StringContent(serializePostModel, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponceMessage = client.PostAsync(ConnectionHelper.GetConnectionUrl() + "AppUser/Update/", contentPost).Result;

                httpResponceMessage.EnsureSuccessStatusCode();

                string stringResponce = httpResponceMessage.Content.ReadAsStringAsync().Result;

                infrastructureModel = JsonConvert.DeserializeObject<InfrastructureModel<bool>>(stringResponce);

                if (infrastructureModel.ResultModel)
                {
                    infrastructureModel.ResultStatus = true;
                }
                return infrastructureModel;
            }
        }

        public InfrastructureModel<bool> ChangePassword(AppUserLoginModel appUserLoginModel)
        {
            InfrastructureModel<bool> infrastructureModel = new InfrastructureModel<bool>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", appUserLoginModel.TokenKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                var serializePostModel = JsonConvert.SerializeObject(appUserLoginModel);

                StringContent contentPost = new StringContent(serializePostModel, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponceMessage = client.PostAsync(ConnectionHelper.GetConnectionUrl() + "AppUser/UpdatePassword/", contentPost).Result;

                httpResponceMessage.EnsureSuccessStatusCode();

                string stringResponce = httpResponceMessage.Content.ReadAsStringAsync().Result;

                infrastructureModel = JsonConvert.DeserializeObject<InfrastructureModel<bool>>(stringResponce);

                if (!infrastructureModel.ResultModel)
                {
                    infrastructureModel.ResultStatus = true;
                }
                return infrastructureModel;
            }
        }

        public InfrastructureModel<bool> ResetAllInformationAppUser(AppUserModel appUserModel)
        {
            InfrastructureModel<bool> infrastructureModel = new InfrastructureModel<bool>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", appUserModel.TokenKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                var serializePostModel = JsonConvert.SerializeObject(appUserModel);

                StringContent contentPost = new StringContent(serializePostModel, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponceMessage = client.PostAsync(ConnectionHelper.GetConnectionUrl() + "AppUser/ResetAllInformationAppUser/", contentPost).Result;

                httpResponceMessage.EnsureSuccessStatusCode();

                string stringResponce = httpResponceMessage.Content.ReadAsStringAsync().Result;

                infrastructureModel = JsonConvert.DeserializeObject<InfrastructureModel<bool>>(stringResponce);

                if (!infrastructureModel.ResultModel)
                {
                    infrastructureModel.ResultStatus = true;
                }
                return infrastructureModel;
            }
        }
    }
}
