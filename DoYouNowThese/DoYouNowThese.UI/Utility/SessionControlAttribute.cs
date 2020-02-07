using DoYouNowThese.CommonModel.AppUserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoYouNowThese.UI.Utility
{
    public class SessionControlAttribute : Attribute, IActionFilter
    {

        public SessionControlAttribute()
        {

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            AppUserModel userModel = new AppUserModel();

            userModel = SessionExtension.Get<AppUserModel>(context.HttpContext.Session, "Login");

            if (userModel == null)
            {
                context.Result= new ViewResult
                {
                    ViewName = "Index",
                };
            }
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            this.OnActionExecuting(context);
            var resultContext = await next();
            this.OnActionExecuted(resultContext);
        }
    }
}
