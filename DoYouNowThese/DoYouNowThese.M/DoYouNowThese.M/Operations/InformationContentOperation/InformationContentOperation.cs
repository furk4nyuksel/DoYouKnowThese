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
   public class InformationContentOperation
    {
        public string _conString = ConnectionStrings.url;

        public   InfrastructureModel<InformationContentSingleDataModel> GetInformationContentSingleData()
        {
            //using (var client = new WebClient())
            //{

            //    var json = client.DownloadString(ConnectionStrings.url+ "Information/GetSingleContent/");

            //    InfrastructureModel<InformationContentSingleDataModel> mobileResult = JsonConvert.DeserializeObject<InfrastructureModel<InformationContentSingleDataModel>>(json);
            //    return mobileResult;
            //}
            InfrastructureModel<InformationContentSingleDataModel> resultModel = new InfrastructureModel<InformationContentSingleDataModel>();
            using (HttpClient client=new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImZ1cms0bnl1a3NlbEBpY2xvdWQuY29tIiwiZW1haWwiOiJpbmZvQHRla25vaGlzYXIuY29tIiwibmFtZWlkIjoiYWFjYjNiMzctNjRkMS00N2FmLTgyNTctMWQyNzZkNzAwYmNhIiwiZXhwIjoxNTY5NzAxMTIxLCJpc3MiOiIxOTQuMTY5LjEyMC4yNyIsImF1ZCI6IjE5NC4xNjkuMTIwLjI3In0.FBondshPkDUxM-dZWzPhAIr5rx_-i8gODxkKXDFsWYE");
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
