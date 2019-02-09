using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class TaxController : Controller
    {
        private BusinessLayer.Tax _Tax = new BusinessLayer.Tax();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _TaxAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.Tax>>(_Tax.GetAll()));
        }

        public PartialViewResult _TaxEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.Tax());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Tax>(_Tax.GetTax(identity)));
        }

        public PartialViewResult _TaxView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Tax>(_Tax.GetTax(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Tax.Delete(identity);
            return RedirectToAction("_TaxAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Tax Tax)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (Tax.Identity.Equals(-1))
            {
                Tax.Identity = GetRandomNumber();
                _Tax.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Tax>(Tax));
            }
            else
                _Tax.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Tax>(Tax));
            return RedirectToAction("_TaxAll");
        }

        [HttpPost]
        public PartialViewResult TaxSearch(string searchString)
        {
            return PartialView("_TaxAll", AutoMapperConfig.Mapper().Map<List<Models.Tax>>(_Tax.GetAll().ToList().FindAll(p => p.TaxValue.ToString().ToLower().Contains(searchString.ToLower()))));
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
