﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    [ERP.CustomeFilters.AjaxModelValidatorFilter]
    [ERP.CustomeFilters.LoggingFilter]
    [ERP.CustomeFilters.ExceptionFilter]
    public class StockTransferController : Controller
    {
        // GET: StockTransfer
        public ActionResult Index()
        {
            return View();
        }
    }
}