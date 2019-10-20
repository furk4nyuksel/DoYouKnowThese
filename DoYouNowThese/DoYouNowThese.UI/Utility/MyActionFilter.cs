using DoYouNowThese.BIZ.Operations.LogEntityOperation;
using DoYouNowThese.DATA.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoYouNowThese.UI.Utility
{
    public class MyActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.RouteData.Values["action"].ToString();
            var controllerName = context.RouteData.Values["controller"].ToString();

            var type = context.HttpContext.Request.Method.ToString();
            LogEntity logEntity = new LogEntity()
            {
                ActionName = actionName,
                ControllerName = controllerName,
                ActionType = type,
                CreateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
            };
            LogEntityOperation.Insert(logEntity);
        }
    }
}
