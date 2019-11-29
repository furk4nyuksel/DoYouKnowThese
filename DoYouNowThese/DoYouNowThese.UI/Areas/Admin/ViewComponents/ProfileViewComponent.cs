using DoYouNowThese.CommonModel.AppUserModel;
using DoYouNowThese.UI.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoYouNowThese.UI.Areas.Admin.ViewComponents
{
    public class ProfileViewComponent:ViewComponent
    {
        public ProfileViewComponent()
        {
                
        }

        public IViewComponentResult Invoke()
        {
            AppUserModel userModel = new AppUserModel();

            userModel = SessionExtension.Get<AppUserModel>(HttpContext.Session, "Login");
            return View(userModel);
        }
    }
}
