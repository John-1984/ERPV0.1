using System;
using System.Text;
using System.Web.Mvc;
using LoggingModule;

namespace ERP.CustomeFilters
{
    public class LoggingFilter : ActionFilterAttribute
    {
        private const string messageFormat = "IP: {0} - DateTime: {1} - Action: {2} - Controller: {3} - Parameters: ";
        private const string messageFormatShort = "IP: {0} - DateTime: {1}";
        private readonly Logging _logger;
        public LoggingFilter()
        {
            _logger = new Logging();
        }

        /// <summary>Called by the ASP.NET MVC framework before the action method executes.</summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var message = "OnActionExecuting:: ";
            message = message + string.Format(messageFormat, filterContext.HttpContext.Request.UserHostAddress, filterContext.HttpContext.Timestamp, filterContext.ActionDescriptor.ActionName, filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);

            var enumerator = filterContext.ActionParameters.GetEnumerator();
            while (enumerator.MoveNext())
            {
                message = message + (enumerator.Current.Key + "|" + enumerator.Current.Value + ",");
            }

            message = message + " - URL: " + filterContext.HttpContext.Request.Url;

            _logger.Log(message, Logging.LoggingMode.Info);
        }

        /// <summary>Called by the ASP.NET MVC framework after the action method executes.</summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var message = "OnActionExecuted:: ";
            message = message + string.Format(messageFormat, filterContext.HttpContext.Request.UserHostAddress, filterContext.HttpContext.Timestamp, filterContext.ActionDescriptor.ActionName, filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
            message = message + " - URL: " + filterContext.HttpContext.Request.Url;

            if (filterContext.Exception != null)
            {
                message = message + " - Exception: " + filterContext.Exception.InnerException;
                _logger.Log(message, Logging.LoggingMode.Error);
            }
            else
                _logger.Log(message, Logging.LoggingMode.Info);
        }

        /// <summary>Called by the ASP.NET MVC framework before the action result executes.</summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var message = "OnResultExecuting:: ";
            message = message + string.Format(messageFormatShort, filterContext.HttpContext.Request.UserHostAddress, filterContext.HttpContext.Timestamp);
            message = message + " - URL: " + filterContext.HttpContext.Request.Url;

            _logger.Log(message, Logging.LoggingMode.Info);
        }

        /// <summary>Called by the ASP.NET MVC framework after the action result executes.</summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var message = "OnResultExecuted:: ";
            message = message + string.Format(messageFormatShort, filterContext.HttpContext.Request.UserHostAddress, filterContext.HttpContext.Timestamp);
            message = message + " - URL: " + filterContext.HttpContext.Request.Url;

            if (filterContext.Exception != null)
            {
                message = message + " - Exception: " + filterContext.Exception.InnerException;
                _logger.Log(message, Logging.LoggingMode.Error);
            }
            else
                _logger.Log(message, Logging.LoggingMode.Info);
        }
    }
}
