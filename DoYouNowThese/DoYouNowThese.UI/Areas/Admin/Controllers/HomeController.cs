using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoYouNowThese.CommonModel.AppUserModel;
using DoYouNowThese.DATA.Models;
using DoYouNowThese.UI.Controllers;
using DoYouNowThese.UI.Models.Utility;
using DoYouNowThese.UI.Utility;
using Microsoft.AspNetCore.Mvc;

namespace DoYouNowThese.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(AppUserLoginModel appUserModel)
        {
            Response response = new Response();
            try
            {
                AppUser appUser = SessionExtension.Get<AppUser>(HttpContext.Session, "Login");
                if (appUser!=null)
                {
                    response.Message = "Session Dolu";
                    response.Status = true;
                }
                else
                {
                    response.Message = "Session Boş";
                    response.Status = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Json(response);
        }
    }
}