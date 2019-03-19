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
    public class SupplierQuotationController : Controller
    {
        private BusinessLayer.SupplierQuotation _SupplierQuotation = new BusinessLayer.SupplierQuotation();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _SupplierQuotationAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.SupplierQuotation>>(_SupplierQuotation.GetAll()));
        }

        public PartialViewResult _SupplierQuotationEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.SupplierQuotation());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.SupplierQuotation>(_SupplierQuotation.GetSupplierQuotation(identity)));
        }

        public PartialViewResult _SupplierQuotationView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.SupplierQuotation>(_SupplierQuotation.GetSupplierQuotation(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _SupplierQuotation.Delete(identity);
            return RedirectToAction("_SupplierQuotationAll");
        }

        [HttpPost]
        public ActionResult Update(Models.SupplierQuotation SupplierQuotation)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (SupplierQuotation.Identity.Equals(-1))
            {
                SupplierQuotation.Identity = GetRandomNumber();
                _SupplierQuotation.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.SupplierQuotation>(SupplierQuotation));
            }
            else
                _SupplierQuotation.Update(AutoMapperConfig.Mapper().Map<BusinessModels.SupplierQuotation>(SupplierQuotation));
            return RedirectToAction("_SupplierQuotationAll");
        }

        [HttpPost]
        public PartialViewResult SupplierQuotationSearch(string searchString)
        {
            return PartialView("_SupplierQuotationAll", AutoMapperConfig.Mapper().Map<List<Models.SupplierQuotation>>(_SupplierQuotation.GetAll().ToList().FindAll(p => p.SOCOde.ToLower().Contains(searchString.ToLower()))));
        }

        //Function to get random number
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min = 0, int max = 1000)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

    }
}
