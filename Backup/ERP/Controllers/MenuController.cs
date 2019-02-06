using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        public PartialViewResult Index()
        {
            return PartialView ();
        }
    }
}
