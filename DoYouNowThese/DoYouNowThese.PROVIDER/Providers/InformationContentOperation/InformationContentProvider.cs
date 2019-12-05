using DoYouNowThese.CommonModel.InformationContentModel;
using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.PROVIDER.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DoYouNowThese.PROVIDER.Providers.InformationContentOperation
{
    public class InformationContentProvider
    {
        public InfrastructureModel<InformationContentSingleDataModel> GetInformationContentSingleData(string tokenKey)
        {
            InfrastructureModel<InformationContentSingleDataModel> resultModel = new InfrastructureModel<InformationContentSingleDataModel>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage httpResponceMessage = client.GetAsync(ConnectionHelper.GetConnectionUrl() + "Information/GetSingleContent/").Result;
                httpResponceMessage.EnsureSuccessStatusCode();

                string stringResponce = httpResponceMessage.Content.ReadAsStringAsync().Result;

                resultModel = JsonConvert.DeserializeObject<InfrastructureModel<InformationContentSingleDataModel>>(stringResponce);
                return resultModel;
            }
        }
        public InfrastructureModel<InformationContentSingleDataModel> GetInformationCategoryContentSingleData(InformationContentPostModel postModel)
        {
            InfrastructureModel<InformationContentSingleDataModel> resultModel = new InfrastructureModel<InformationContentSingleDataModel>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", postModel.TokenKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                var serializeJsonObject = JsonConvert.SerializeObject(postModel);
                StringContent content = new StringContent(serializeJsonObject, Encoding.UTF8, "application/json");


                HttpResponseMessage httpResponceMessage = client.PostAsync(ConnectionHelper.GetConnectionUrl() + "Information/GetCategorySingleContent/", content).Result;
                httpResponceMessage.EnsureSuccessStatusCode();

                string response = httpResponceMessage.Content.ReadAsStringAsync().Result;

                resultModel = JsonConvert.DeserializeObject<InfrastructureModel<InformationContentSingleDataModel>>(response);

                return resultModel;
            }
        }

        public InfrastructureModel InsertInformationContent(InformationApiContentCRUDModel postModel)
        {
            InfrastructureModel resultModel = new InfrastructureModel();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", postModel.TokenKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                var serializeJsonObject = JsonConvert.SerializeObject(postModel);
                StringContent content = new StringContent(serializeJsonObject, Encoding.UTF8, "application/json");


                HttpResponseMessage httpResponceMessage = client.PostAsync(ConnectionHelper.GetConnectionUrl() + "Information/InsertInformationContent/", content).Result;
                httpResponceMessage.EnsureSuccessStatusCode();

                string response = httpResponceMessage.Content.ReadAsStringAsync().Result;

                return resultModel;
            }
        }

        public InfrastructureModel<List<InformationContentSingleDataModel>> GetListInformationContent(string tokenKey)
        {
            InfrastructureModel<List<InformationContentSingleDataModel>> resultModel = new InfrastructureModel<List<InformationContentSingleDataModel>>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage httpResponceMessage = client.GetAsync(ConnectionHelper.GetConnectionUrl() + "Information/GetAllInformationContent/").Result;
                httpResponceMessage.EnsureSuccessStatusCode();

                string stringResponce = httpResponceMessage.Content.ReadAsStringAsync().Result;

                resultModel = JsonConvert.DeserializeObject<InfrastructureModel<List<InformationContentSingleDataModel>>>(stringResponce);
                return resultModel;
            }
        }

    }
}
