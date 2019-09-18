using DoYouNowThese.CommonModel.InformationContentModel;
using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.M.Dependencies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
            using (var client = new WebClient())
            {

                var json = client.DownloadString("http://192.168.1.20/api/Information");

                InfrastructureModel<InformationContentSingleDataModel> mobileResult = JsonConvert.DeserializeObject<InfrastructureModel<InformationContentSingleDataModel>>(json);
                return mobileResult;
            }
        }
    }
}
