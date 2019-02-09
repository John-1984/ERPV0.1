using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class WarrantyController : Controller
    {
        private BusinessLayer.Warranty _Warranty = new BusinessLayer.Warranty();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _WarrantyAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.Warranty>>(_Warranty.GetAll()));
        }

        public PartialViewResult _WarrantyEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.Warranty());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Warranty>(_Warranty.GetWarranty(identity)));
        }

        public PartialViewResult _WarrantyView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Warranty>(_Warranty.GetWarranty(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Warranty.Delete(identity);
            return RedirectToAction("_WarrantyAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Warranty Warranty)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (Warranty.Identity.Equals(-1))
            {
                Warranty.Identity = GetRandomNumber();
                _Warranty.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Warranty>(Warranty));
            }
            else
                _Warranty.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Warranty>(Warranty));
            return RedirectToAction("_WarrantyAll");
        }

        [HttpPost]
        public PartialViewResult WarrantySearch(string searchString)
        {
            return PartialView("_WarrantyAll", AutoMapperConfig.Mapper().Map<List<Models.Warranty>>(_Warranty.GetAll().ToList().FindAll(p => p.WarrantyValue.ToString().ToLower().Contains(searchString.ToLower()))));
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
