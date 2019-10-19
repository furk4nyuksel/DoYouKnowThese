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
    }
}
