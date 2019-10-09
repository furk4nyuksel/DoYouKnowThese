using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoYouNowThese.BIZ.Operations.CategoryOperation;
using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.DATA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoYouNowThese.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController
    {
        CategoryOperation categoryOperation;
        DoYouNowTheseContext context;
        public CategoryController()
        {
            context = new DoYouNowTheseContext();
            categoryOperation = new CategoryOperation(context);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("~/api/[controller]/GetAllCategoryList")]
        [HttpGet]
        public JsonResult GetAllCategoryList()
        {
            InfrastructureModel<List<Category>> response = new InfrastructureModel<List<Category>>();
            try
            {
                List<Category> categoryList = categoryOperation.GetAllCategoryList();

                response.ResultModel = categoryList;
                if (categoryList.Count() > 0)
                {
                    response.ResultStatus = true;
                }
                else
                {
                    response.ResultStatus = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return new JsonResult(response);
        }
    }
}