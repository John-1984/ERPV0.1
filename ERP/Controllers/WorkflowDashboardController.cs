using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class WorkflowDashboardController : Controller
    {
        public ActionResult Inbox()
        {
            return View ("Inbox");
        }
    }
}
