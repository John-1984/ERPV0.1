using System;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using LoggingModule;

namespace ERP.CustomeFilters
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        private const string messageFormatShort = "IP: {0} - DateTime: {1}";
        private readonly Logging _logger;

        public ExceptionFilter() {
            _logger = new Logging();
        }


        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            //This section has to be modified to catch CLient Side Errors. I.e 4XX error types.
            if (new HttpException(null, filterContext.Exception).GetHttpCode() != 500)
            {
                return;
            }

            //if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            //{
            //    return;
            //}

            // if the request is AJAX return JSON else view.
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        error = true,
                        message = filterContext.Exception.Message
                    }
                };
            }
            else
            {
                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];
                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                filterContext.Result = new ViewResult
                {
                    ViewName = "Error",
                    MasterName = "_Layout",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = filterContext.Controller.TempData
                };
            }

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            var message = "OnException:: ";
            message = message + string.Format(messageFormatShort, filterContext.HttpContext.Request.UserHostAddress, filterContext.HttpContext.Timestamp);
            message = message + " - URL: " + filterContext.HttpContext.Request.Url;
            message = message + " - Exception: " + filterContext.Exception.Message;
            message = message + " - ExceptionHandled: " + filterContext.ExceptionHandled.ToString();

            _logger.Log(message, Logging.LoggingMode.Error);
        }
    }
}
