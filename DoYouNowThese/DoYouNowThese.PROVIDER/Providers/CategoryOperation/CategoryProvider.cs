using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.DATA.Models;
using DoYouNowThese.PROVIDER.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DoYouNowThese.PROVIDER.Providers.CategoryOperation
{
    public class CategoryProvider
    {
        public InfrastructureModel<List<Category>> GetInformationContentSingleData(string tokenKey)
        {
            InfrastructureModel<List<Category>> resultModel = new InfrastructureModel<List<Category>>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json charset=utf-8");
                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage httpResponceMessage = client.GetAsync(ConnectionHelper.GetConnectionUrl() + "Category/GetAllCategoryList/").Result;
                httpResponceMessage.EnsureSuccessStatusCode();

                string stringResponce = httpResponceMessage.Content.ReadAsStringAsync().Result;

                resultModel = JsonConvert.DeserializeObject<InfrastructureModel<List<Category>>>(stringResponce);
                return resultModel;
            }
        }
    }
}
