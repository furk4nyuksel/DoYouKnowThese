﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoYouNowThese.BIZ.Operations.AppUserOperation;
using DoYouNowThese.BIZ.Operations.InformationReadLog;
using DoYouNowThese.CommonModel.AppUserModel;
using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.DATA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoYouNowThese.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : BaseApiController
    {
        DoYouNowTheseContext db;
        AppUserOperation appUserOperation;
        InformationReadLogOperation InformationReadLogOperation;
        public AppUserController()
        {
            db = new DoYouNowTheseContext();
            appUserOperation = new AppUserOperation(db);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("~/api/[controller]/GetById")]
        public IActionResult GetById([FromBody] AppUserLoginModel appUserLoginModel)
        {
            InfrastructureModel<AppUserInformationModel> infrastructureModel = new InfrastructureModel<AppUserInformationModel>();

            var appUser = appUserOperation.GetById(appUserLoginModel.AppUserId);

            if (appUser != null)
            {
                AppUserInformationModel appUserInformationModel = new AppUserInformationModel()
                {
                    AppUserId = appUser.AppUserId,
                    Name = appUser.Name,
                    Surname = appUser.Surname,
                    Email = appUser.Email,
                    Username = appUser.Username
                };
                infrastructureModel.ResultModel = appUserInformationModel;
                infrastructureModel.ResultStatus = true;
            }
            return Json(infrastructureModel);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("~/api/[controller]/Update")]
        public IActionResult Update([FromBody] AppUserInformationModel appUserInformationModel)
        {
            InfrastructureModel<bool> infrastructureModel = new InfrastructureModel<bool>();

            var appUser = appUserOperation.GetById(appUserInformationModel.AppUserId);

            if (appUser != null)
            {
                //appUser.Email = appUserInformationModel.Email;
                appUser.Name = appUserInformationModel.Name;
                appUser.Surname = appUserInformationModel.Surname;
                // appUser.Username = appUserInformationModel.Username;

                appUserOperation.Update(appUser);

                infrastructureModel.ResultModel = true;
                infrastructureModel.ResultStatus = true;
            }

            return Json(infrastructureModel);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("~/api/[controller]/UpdatePassword")]
        public IActionResult UpdatePassword([FromBody] AppUserLoginModel appUserLoginModel)
        {
            InfrastructureModel<bool> infrastructureModel = new InfrastructureModel<bool>();

            var appUser = appUserOperation.GetById(appUserLoginModel.AppUserId);

            if (appUser != null)
            {
                if (appUser.Password == appUserLoginModel.NowPassword)
                {
                    if (appUserLoginModel.Password == appUserLoginModel.RePassword)
                    {
                        appUser.Password = appUserLoginModel.Password;

                        infrastructureModel.Message = "Şifre Değiştirildi";

                        appUserOperation.Update(appUser);
                    }
                    else
                    {
                        infrastructureModel.Message = "Şifreler Eşleşmiyor Veya Eski Şifreniz Yanlış";
                    }
                }
                else
                {
                    infrastructureModel.Message = "Şuanki Şifreniz Yanlış";
                }

                infrastructureModel.ResultModel = true;
                infrastructureModel.ResultStatus = true;
            }

            return Json(infrastructureModel);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("~/api/[controller]/ResetAllInformationAppUser")]
        public JsonResult ResetAllInformationAppUser([FromBody] AppUserModel appUserModel)
        {
            InfrastructureModel<bool> infrastructureModel = new InfrastructureModel<bool>();

            var appUser = appUserOperation.GetById(appUserModel.AppUser.AppUserId);

            if (appUser != null)
            {
                InformationReadLogOperation = new InformationReadLogOperation(db);

                int counter = InformationReadLogOperation.RemoveAllAppUserLog(appUser.AppUserId);

                infrastructureModel.Message = counter.ToString() + " Kayıt Silindi";
                infrastructureModel.ResultModel = true;
                infrastructureModel.ResultStatus = true;
            }

            return Json(infrastructureModel);
        }

    }
}