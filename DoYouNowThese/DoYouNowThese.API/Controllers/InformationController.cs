﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoYouNowThese.BIZ.Operations.InformationContentOperation;
using DoYouNowThese.CommonModel.InformationContentModel;
using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.CORE;
using DoYouNowThese.DATA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DoYouNowThese.API.Controllers
{

    [ApiController]
    public class InformationController : BaseApiController
    {
        DoYouNowTheseContext db;
        InformationContentOperation informationContentOperation;
       
        public InformationController()
        {
            db = new DoYouNowTheseContext();
            informationContentOperation = new InformationContentOperation(db);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("~/api/[controller]/GetSingleContent")]
        [HttpGet]
        public JsonResult GetSingleContent()
        {
            InfrastructureModel<InformationContentSingleDataModel> response = new InfrastructureModel<InformationContentSingleDataModel>();
            InformationContentSingleDataModel resultModel = new InformationContentSingleDataModel();
            try
            {
                InformationContent informationContext = informationContentOperation.GetSingleInformationContent(0);
                resultModel.AuthorFullName = informationContext.Author.Name + " " + informationContext.Author.Surname;
                resultModel.Explanation = informationContext.Explanation;
                resultModel.ImagePath = informationContext.PostImagePath;
                resultModel.LikeCount = informationContext.LikeCount.ToString();
                resultModel.Title = informationContext.Title;

                response.ResultModel = resultModel;
                response.ResultStatus = true;
            }
            catch (Exception ex)
            {
                response.ResultStatus = false;
                throw ex;
            }
            return new JsonResult(response);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("~/api/[controller]/GetCategorySingleContent")]
        [HttpGet]
        public JsonResult GetCategorySingleContent(InformationContentPostModel model)
        {
            try
            {
                InfrastructureModel<InformationContentSingleDataModel> response = new InfrastructureModel<InformationContentSingleDataModel>();
                InformationContentSingleDataModel resultModel = new InformationContentSingleDataModel();
                try
                {
                    InformationContent informationContext = informationContentOperation.GetCategorySingleInformationContent(model.AppUserId, model.CategoryId);
                    resultModel.AuthorFullName = informationContext.Author.Name + " " + informationContext.Author.Surname;
                    resultModel.Explanation = informationContext.Explanation;
                    resultModel.ImagePath = informationContext.PostImagePath;
                    resultModel.LikeCount = informationContext.LikeCount.ToString();
                    resultModel.Title = informationContext.Title;

                    response.ResultModel = resultModel;
                    response.ResultStatus = true;
                }
                catch (Exception ex)
                {
                    response.ResultStatus = false;
                    throw ex;
                }
                return new JsonResult(response);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}