using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DoYouNowThese.BIZ.Operations.InformationContentOperation;
using DoYouNowThese.CommonModel.InformationContentModel;
using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.CORE;
using DoYouNowThese.DATA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private IHostingEnvironment _env;
        public InformationController(IHostingEnvironment environment)
        {
            _env = environment;
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
        [HttpPost]
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

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("~/api/[controller]/InsertInformationContent")]
        [HttpPost]
        public JsonResult InsertInformationContent([FromForm]InformationApiContentCRUDModel model)
        {
            InfrastructureModel response;
            try
            {

                if (model != null)
                {
                    InformationContent informationContent = new InformationContent()
                    {
                        CategoryId=model.CategoryId,
                        AuthorId=model.AuthorId,
                        CreateDate=DateTime.Now,
                        IsActive=true,
                        IsDeleted=false,
                        Explanation=model.Explanation,
                        LikeCount=model.LikeCount,
                        Title=model.Title,
                    };



                    long size = model.PostImageFile.Length;

                    if (model.PostImageFile != null)
                    {
                        string filePath = Path.Combine(_env.WebRootPath, "Content", "Information");

                        string imagePath = string.Empty;

                        string fileExtension = Path.GetExtension(model.PostImageFile.FileName);

                        string fileName = (Guid.NewGuid() + fileExtension);

                        if (model.PostImageFile.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                model.PostImageFile.CopyTo(ms);
                                var fileBytes = ms.ToArray();
                                imagePath = Convert.ToBase64String(fileBytes);
                            }
                            var bytes = Convert.FromBase64String(imagePath);
                            using (var imageFile = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                            {
                                imageFile.Write(bytes, 0, bytes.Length);
                                imageFile.Flush();
                            }
                        }
                        informationContent.PostImagePath = fileName;
                    }


                    informationContentOperation.Insert(informationContent);

                   response = new InfrastructureModel()
                    {
                        ResultStatus=true
                    };
                }
                else
                {
                    response = new InfrastructureModel()
                    {
                        ResultStatus = false
                    };
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return Json(response);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("~/api/[controller]/GetAllInformationContent")]
        [HttpGet]
        public JsonResult GetAllInformationContent()
        {
            InfrastructureModel<List<InformationContentSingleDataModel>> response = new InfrastructureModel<List<InformationContentSingleDataModel>>();
            List<InformationContentSingleDataModel> resultModel = new List<InformationContentSingleDataModel>();
            try
            {
                List<InformationContent> informationContextList = informationContentOperation.GetAllInformationContent();


                foreach (var info in informationContextList)
                {
                    resultModel.Add(new InformationContentSingleDataModel()
                    {
                        AuthorFullName = info.Author!=null?info.Author.Name + " " + info.Author.Surname:string.Empty,
                        CategoryName = info.Category!=null?info.Category.Name:string.Empty,
                        Explanation = info.Explanation,
                        ImagePath = info.PostImagePath,
                        LikeCount = info.LikeCount.ToString(),
                        Title = info.Title
                    });
                }

                response.ResultStatus = true;
                response.ResultModel = resultModel;
            }
            catch (Exception ex)
            {
                response.ResultStatus = false;
                throw ex;
            }
            return new JsonResult(response);
        }
    }
}