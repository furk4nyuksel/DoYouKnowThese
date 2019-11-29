using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoYouNowThese.UI.Utility;
using Microsoft.AspNetCore.Mvc;

namespace DoYouNowThese.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionControl]
    public class InformationContentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}