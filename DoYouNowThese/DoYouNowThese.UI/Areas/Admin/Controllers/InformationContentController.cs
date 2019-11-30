using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoYouNowThese.CommonModel.InformationContentModel;
using DoYouNowThese.PROVIDER.Providers.InformationContentOperation;
using DoYouNowThese.UI.Areas.Admin.Models.InformationContent;
using DoYouNowThese.UI.Controllers;
using DoYouNowThese.UI.Utility;
using Microsoft.AspNetCore.Mvc;

namespace DoYouNowThese.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionControl]
    public class InformationContentController : BaseController
    {
        InformationContentProvider informationContentProvider;

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(InformationContentCRUDModel informationContentCRUDModel)
        {
            informationContentProvider = new InformationContentProvider();


            InformationApiContentCRUDModel apiContentCRUDModel = new InformationApiContentCRUDModel();





            informationContentProvider.InsertInformationContent(apiContentCRUDModel);

            return View();
        }
    }
}