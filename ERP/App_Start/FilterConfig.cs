using System;
using System.Web.Mvc;

namespace ERP
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomeFilters.LoggingFilter());
            filters.Add(new CustomeFilters.ExceptionFilter());
        }
    }
}
