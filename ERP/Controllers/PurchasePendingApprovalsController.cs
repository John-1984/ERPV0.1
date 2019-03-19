using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    [ERP.CustomeFilters.AjaxModelValidatorFilter]
    [ERP.CustomeFilters.LoggingFilter]
    [ERP.CustomeFilters.ExceptionFilter]
    public class PurchasePendingApprovalsController : Controller
    {
        // GET: PurchasePendingApprovals
        public ActionResult Index()
        {
            return View();
        }
    }
}