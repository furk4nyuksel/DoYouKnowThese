using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoYouNowThese.CommonModel.AppUserModel;
using DoYouNowThese.DATA.Models;
using DoYouNowThese.PROVIDER.Providers.AppUserOperation;
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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[Route("Login")]
        public JsonResult Login(AppUserLoginModel appUserModel)
        {
            Response response = new Response();
            try
            {
                AppUserProvider appUserProvider = new AppUserProvider();

                AppUserModel appuserModel= appUserProvider.GetLoginUser(appUserModel).ResultModel;

                if (appuserModel != null)
                {
                    SessionExtension.Set<AppUserModel>(HttpContext.Session, "Login", appuserModel);

                    response = new Response()
                    {
                        Message = "success",
                        Status = true,
                        RedirectUrl=Url.Action("Index","Home",new {area="Admin" })
                    };
                }
                else
                {
                   
                }

            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    Message = "Fail",
                    Status = false
                };
            }
            return Json(response);
        }
    }
}