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
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            var message = "Server error occurred.";

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
            //context.Result = new ObjectResult(new ApiResponse { Message = message, Data = null });
        }
    }
}
