using DoYouNowThese.BIZ.Operations.ErrorEntityOperation;
using DoYouNowThese.DATA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DoYouNowThese.API.Utility
{
    public class MyExceptionFilter : IExceptionFilter
    {
        DoYouNowTheseContext dbcontext;
        ErrorEntityOperation errorEntityOperation;
        public MyExceptionFilter()
        {
            dbcontext = new DoYouNowTheseContext();
            errorEntityOperation = new ErrorEntityOperation(dbcontext);
        }
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            var actionName = context.RouteData.Values["action"];
            var controllerName = context.RouteData.Values["controller"];

            ErrorEntity errorEntity = new ErrorEntity()
            {
                CreateDate=DateTime.Now,
                InnerExceptionText=context.Exception.InnerException!=null?context.Exception.InnerException.ToString():string.Empty,
                MessageText=context.Exception.Message,
                StackTraceText=context.Exception.StackTrace,
                ApiController=controllerName.ToString(),
                ApiAction=actionName.ToString(),
                IsActive=true,
                IsDeleted=false,
            };

            errorEntityOperation.Insert(errorEntity);

            #region request parameter

            //bunu araştır
            string test = string.Empty;
 


            #endregion
            var exceptionType = context.Exception.GetType();
            //if (exceptionType is MyCustomException) //Checking for my custom exception type
            //{
            //    message = context.Exception.Message;
            //}

            //You can enable logging error

            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            context.Result = new ObjectResult(errorEntity);
        }
    }
}
