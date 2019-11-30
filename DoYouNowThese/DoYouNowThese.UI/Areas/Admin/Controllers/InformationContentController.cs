using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoYouNowThese.CommonModel.InformationContentModel;
using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.DATA.Models;
using DoYouNowThese.PROVIDER.Providers.CategoryOperation;
using DoYouNowThese.PROVIDER.Providers.InformationContentOperation;
using DoYouNowThese.UI.Areas.Admin.Models.InformationContent;
using DoYouNowThese.UI.Controllers;
using DoYouNowThese.UI.Models.Utility;
using DoYouNowThese.UI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoYouNowThese.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionControl]
    public class InformationContentController : BaseController
    {
        InformationContentProvider informationContentProvider;
        CategoryProvider categoryProvider;

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Insert()
        {
            InformationContentCRUDModel informationContentCRUDModel = new InformationContentCRUDModel();
            categoryProvider = new CategoryProvider();

            InfrastructureModel<List<Category>> infrastructerCategoryList = categoryProvider.GetCategoryList(SessionExtension.GetSessionUserTokeyKey(HttpContext.Session));

            informationContentCRUDModel.CategoryList = new SelectList(infrastructerCategoryList.ResultModel, "CategoryId", "Name");

            return View(informationContentCRUDModel);
        }

        [HttpPost]
        public JsonResult Insert(InformationContentCRUDModel informationContentCRUDModel)
        {
            Response response = new Response();
            try
            {
                informationContentProvider = new InformationContentProvider();


                InformationApiContentCRUDModel apiContentCRUDModel = new InformationApiContentCRUDModel();


                informationContentProvider.InsertInformationContent(apiContentCRUDModel);

                response = new Response()
                {
                    Message = "Succes",
                    Status = true
                };
            }
            catch (Exception)
            {
                response = new Response()
                {
                    Message = "Failed",
                    Status = false
                };
            }

            return Json(response);
        }
    }
}