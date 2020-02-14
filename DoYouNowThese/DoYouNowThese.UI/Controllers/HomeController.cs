using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DoYouNowThese.UI.Models;
using DoYouNowThese.CommonModel.AppUserModel;
using DoYouNowThese.PROVIDER.Providers.InformationContentOperation;
using DoYouNowThese.UI.Utility;
using DoYouNowThese.PROVIDER.TokenOperation;
using DoYouNowThese.UI.Models.Utility;
using DoYouNowThese.PROVIDER.Providers.AppUserOperation;
using DoYouNowThese.CommonModel.InformationContentModel;
using DoYouNowThese.CommonModel.Infrastructure;

namespace DoYouNowThese.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        InformationContentProvider informationContentProvider;
        TokenProvider tokenProvider;
        AppUserProvider appUserProvider;
        public HomeController(ILogger<HomeController> logger)
        {
            informationContentProvider = new InformationContentProvider();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetJsonPost()
        {
            informationContentProvider = new InformationContentProvider();
            tokenProvider = new TokenProvider();
            string token = string.Empty;
            InfrastructureModel<InformationContentSingleDataModel> infrastructureModel = new InfrastructureModel<InformationContentSingleDataModel>();

            if (SessionExtension.GetSessionUser(HttpContext.Session)==null)
            {
                token = tokenProvider.GetAnonimToken();
                SessionExtension.Set(HttpContext.Session, "FreeToken", token);
                infrastructureModel = informationContentProvider.GetInformationContentSingleData(new InformationContentPostModel() { TokenKey = token });

            }
            else
            {
                AppUserModel appUserModel = SessionExtension.GetSessionUser(HttpContext.Session);
                if (appUserModel != null)
                {
                    token = appUserModel.TokenKey;

                    infrastructureModel = informationContentProvider.GetInformationContentSingleData(new InformationContentPostModel() { AppUserId = appUserModel.AppUser.AppUserId, TokenKey = token });
                }

            }
            return Json(infrastructureModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult Login(AppUserLoginModel appUserLoginModel)
        {
            Response response = new Response();

            tokenProvider = new TokenProvider();
            try
            {
                appUserProvider = new AppUserProvider();

                AppUserModel appuserModel = appUserProvider.GetLoginUser(appUserLoginModel).ResultModel;

                if (appuserModel != null)
                {
                    SessionExtension.Set<AppUserModel>(HttpContext.Session, "Login", appuserModel);

                    response = new Response()
                    {
                        Message = "success",
                        Status = true,
                        RedirectUrl = Url.Action("Index", "Home")
                    };
                }
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    Message = "Fail",
                    Status = false,
                };
            }
            return Json(response);
        }
        [HttpPost]
        public JsonResult GetAppUserInformation(AppUserLoginModel appUserLoginModel)
        {
            Response<AppUserInformationModel> response = new Response<AppUserInformationModel>();
            appUserProvider = new AppUserProvider();
            AppUserModel appUserModel = SessionExtension.GetSessionUser(HttpContext.Session);

            if (appUserModel != null)
            {
                AppUserModel appUserTokenModel = SessionExtension.GetSessionUser(HttpContext.Session);
                InfrastructureModel<AppUserInformationModel> appUserInformationModel = appUserProvider.GetById(new AppUserLoginModel() { AppUserId= appUserModel.AppUser.AppUserId,TokenKey= appUserModel.TokenKey });
                response = new Response<AppUserInformationModel>()
                {
                    Data = appUserInformationModel.ResultModel,
                    Message = "succes",
                    Status = true
                };
            }
            return Json(response);
        }

        [HttpPost]
        public JsonResult ChangePassword(AppUserLoginModel appUserLoginModel)
        {
            Response<bool> response = new Response<bool>();
            appUserProvider = new AppUserProvider();

            AppUserModel appUserModel = SessionExtension.GetSessionUser(HttpContext.Session);

            if (appUserModel != null)
            {
                AppUserModel appUserTokenModel = SessionExtension.GetSessionUser(HttpContext.Session);

                appUserLoginModel.TokenKey = appUserModel.TokenKey;
                appUserLoginModel.AppUserId = appUserModel.AppUser.AppUserId;

                InfrastructureModel<bool> infrastructureModel= appUserProvider.ChangePassword(appUserLoginModel);

                response = new Response<bool>()
                {
                    Data = infrastructureModel.ResultModel,
                    Message = infrastructureModel.Message,
                    Status = true,
                    Refresh=true
                };
            }
            return Json(response);
        }


        [HttpPost]
        public JsonResult UpdateAppUserInformation(AppUserInformationModel appUserInformationModel)
        {
            Response<bool> response = new Response<bool>();
            appUserProvider = new AppUserProvider();

            AppUserModel appUserModel = SessionExtension.GetSessionUser(HttpContext.Session);

            if (appUserModel != null)
            {
                AppUserModel appUserTokenModel = SessionExtension.GetSessionUser(HttpContext.Session);

                appUserInformationModel.TokenKey = appUserModel.TokenKey;

                appUserInformationModel.AppUserId = appUserModel.AppUser.AppUserId;

                InfrastructureModel<bool> infrastructureModel = appUserProvider.Update(appUserInformationModel);

                response = new Response<bool>
                {
                    Data = infrastructureModel.ResultStatus,
                    Message = "success",
                    Status = infrastructureModel.ResultStatus,
                };
            }
            return Json(response);
        }

        public JsonResult ResetAllInformation()
        {
            Response<bool> response = new Response<bool>();
            appUserProvider = new AppUserProvider();
            AppUserModel appUserModel = SessionExtension.GetSessionUser(HttpContext.Session);

            if (appUserModel != null)
            {
                AppUserModel appUserTokenModel = SessionExtension.GetSessionUser(HttpContext.Session);

                InfrastructureModel<bool> infrastructureModel = appUserProvider.ResetAllInformationAppUser(appUserTokenModel);

                response = new Response<bool>
                {
                    Data = infrastructureModel.ResultStatus,
                    Message = infrastructureModel.Message,
                    Status = infrastructureModel.ResultStatus,
                };
            }
            return Json(response);
        }
    }
}
