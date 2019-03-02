using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ERP.Controllers;
using LoggingModule;

namespace ERP
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperConfig.RegisterAutoMapperConfig();
            FilterConfig.RegisterGlobalFilters(new GlobalFilterCollection());
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Logging _logger = new Logging();
            var message = "Application_Error:: ";
            string messageFormatShort = "IP: {0} - DateTime: {1}";

            HttpContext httpContext = HttpContext.Current;
            RequestContext requestContext;
            if (httpContext != null)
            {
                   requestContext = ((MvcHandler)httpContext.CurrentHandler).RequestContext;
            }
            //var httpContext = ((MvcApplication)sender).Context;
            var currentController = " ";
            var currentAction = " ";
            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    currentController = currentRouteData.Values["controller"].ToString();
                }

                if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }

            var ex = Server.GetLastError();
            var controller = new ErrorController();
            var routeData = new RouteData();
            var action = "Index";

            if (ex is HttpException)
            {
                var httpEx = ex as HttpException;

                switch (httpEx.GetHttpCode())
                {
                    case 404:
                        action = "NotFound";
                        break;

                        // others if any
                }
            }

            //Log the Error Message
            message = message + string.Format(messageFormatShort, httpContext.Request.UserHostAddress, httpContext.Timestamp);
            message = message + " - URL: " + httpContext.Request.Url;
            message = message + " - Exception: " + ex.Message;
            _logger.Log(message, Logging.LoggingMode.Error);

            httpContext.ClearError();
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
            httpContext.Response.TrySkipIisCustomErrors = true;

            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = action;

            controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        }
    }
}
