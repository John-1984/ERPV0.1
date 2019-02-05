using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace ERP.Controllers
{
    [HandleError]  
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewData["UserName"] = TempData["UserName"];

            return View();
        }

    }
}
