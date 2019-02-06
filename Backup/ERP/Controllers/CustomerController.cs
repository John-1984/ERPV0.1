using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace ERP.Controllers
{
    public class CustomerController : Controller
    {
        private BusinessLayer.Customer _customer = new BusinessLayer.Customer();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _CustomerAll()
        {
            return PartialView(_customer.GetAll());
        }

        public PartialViewResult _CustomerEdit()
        {
            return PartialView(_customer.GetCustomer(1));
        }

        public PartialViewResult _CustomerView()
        {
            return PartialView(_customer.GetCustomer(1));
        }

        public JsonResult Delete(BusinessModels.Customer customer)
        {
            return Json(new { Success = false, Status = "Success" });
        }  

        public JsonResult Update(BusinessModels.Customer customer){
            return Json(new { Success = false, Status = "Success" });
        }
    }
}
