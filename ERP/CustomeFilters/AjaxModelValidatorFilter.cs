using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ERP.CustomeFilters
{
    public class AjaxModelValidatorFilter : ActionFilterAttribute
    {
        public AjaxModelValidatorFilter()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.HttpContext.Request.HttpMethod == "POST")
            {
                var modelState = filterContext.Controller.ViewData.ModelState;
                if (!modelState.IsValid)
                {
                    var errors = new List<string>();
                    foreach (var state in modelState.Values)
                    {
                        foreach (ModelError error in state.Errors)
                        {
                           // if(state.GetType().Equals(Type.b))
                            errors.Add(error.ErrorMessage);
                        }
                    }
                    filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    filterContext.HttpContext.Response.StatusDescription = "Model Validation Failed";
                    filterContext.Result = new JsonResult
                    {
                        Data = new
                        {
                            Error = errors
                        }
                    };
                }
            }
        }
    }
}