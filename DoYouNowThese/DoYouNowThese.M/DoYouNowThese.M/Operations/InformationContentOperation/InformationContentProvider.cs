using DoYouNowThese.CommonModel.InformationContentModel;
using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.M.Dependencies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DoYouNowThese.M.Operations.InformationContentOperation
{
   public class InformationContentProvider
    {

        public   InfrastructureModel<InformationContentSingleDataModel> GetInformationContentSingleData()
        {
            InfrastructureModel<InformationContentSingleDataModel> resultModel = new InfrastructureModel<InformationContentSingleDataModel>();
            using (HttpClient client=new HttpClient())
            {
                string tokenKey = Application.Current.Properties["token"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",TokenAccesModel.accesValue);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage httpResponceMessage = client.GetAsync(ConnectionStrings.url + "Information/GetSingleContent/").Result;
                httpResponceMessage.EnsureSuccessStatusCode();

                string stringResponce = httpResponceMessage.Content.ReadAsStringAsync().Result;

                resultModel = JsonConvert.DeserializeObject<InfrastructureModel<InformationContentSingleDataModel>>(stringResponce);
                return resultModel;
            }
        }
    }
}
