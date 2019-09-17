using DoYouNowThese.CommonModel.InformationContentModel;
using DoYouNowThese.M.Dependencies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DoYouNowThese.M.Operations.InformationContentOperation
{
   public class InformationContentOperation
    {
        public string _conString = ConnectionStrings.url;

        public async Task<InformationContentSingleDataModel> GetInformationContentSingleData()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

                HttpResponseMessage responce = await client.GetAsync(new Uri(_conString+"Information/"));

                responce.EnsureSuccessStatusCode();
                string responceBody = await responce.Content.ReadAsStringAsync();
                InformationContentSingleDataModel mobileResult = JsonConvert.DeserializeObject<InformationContentSingleDataModel>(responceBody);
                var result = JsonConvert.DeserializeObject<InformationContentSingleDataModel>(mobileResult.ToString());
                return result;
            }
        }
    }
}
