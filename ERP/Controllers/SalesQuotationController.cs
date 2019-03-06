using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class SalesQuotationController : Controller
    {
        private BusinessLayer.SalesQuotation _SalesQuotation = new BusinessLayer.SalesQuotation();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _SalesQuotationAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.SalesQuotation>>(_SalesQuotation.GetAll()));
        }

        public PartialViewResult _SalesQuotationEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.SalesQuotation());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.SalesQuotation>(_SalesQuotation.GetSalesQuotation(identity)));
        }

        public PartialViewResult _SalesQuotationView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.SalesQuotation>(_SalesQuotation.GetSalesQuotation(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _SalesQuotation.Delete(identity);
            return RedirectToAction("_SalesQuotationAll");
        }

        [HttpPost]
        public ActionResult Update(Models.SalesQuotation SalesQuotation)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (SalesQuotation.Identity.Equals(-1))
            {
                SalesQuotation.Identity = GetRandomNumber();
                _SalesQuotation.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.SalesQuotation>(SalesQuotation));
            }
            else
                _SalesQuotation.Update(AutoMapperConfig.Mapper().Map<BusinessModels.SalesQuotation>(SalesQuotation));
            return RedirectToAction("_SalesQuotationAll");
        }

        [HttpPost]
        public PartialViewResult SalesQuotationSearch(string searchString)
        {
            return PartialView("_SalesQuotationAll", AutoMapperConfig.Mapper().Map<List<Models.SalesQuotation>>(_SalesQuotation.GetAll().ToList().FindAll(p => p.SQCode.ToLower().Contains(searchString.ToLower()))));
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
