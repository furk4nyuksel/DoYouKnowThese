using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.DATA.Models;
using DoYouNowThese.M.Dependencies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;

namespace DoYouNowThese.M.Operations.CategoryOperation
{
   public class CategoryProvider
    {
        public InfrastructureModel<List<Category>> GetInformationContentSingleData()
        {
            InfrastructureModel<List<Category>> resultModel = new InfrastructureModel<List<Category>>();
            using (HttpClient client = new HttpClient())
            {
                string tokenKey = Application.Current.Properties["token"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenAccesModel.accesValue);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage httpResponceMessage = client.GetAsync(ConnectionStrings.url + "Category/GetAllCategoryList/").Result;
                httpResponceMessage.EnsureSuccessStatusCode();

                string stringResponce = httpResponceMessage.Content.ReadAsStringAsync().Result;

                resultModel = JsonConvert.DeserializeObject<InfrastructureModel<List<Category>>>(stringResponce);
                return resultModel;
            }
        }
    }
}
