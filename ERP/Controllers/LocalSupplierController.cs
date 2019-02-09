using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class LocalSupplierController : Controller
    {
        private BusinessLayer.LocalSupplier _LocalSupplier = new BusinessLayer.LocalSupplier();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _LocalSupplierAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.LocalSupplier>>(_LocalSupplier.GetAll()));
        }

        public PartialViewResult _LocalSupplierEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.LocalSupplier());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.LocalSupplier>(_LocalSupplier.GetLocalSupplier(identity)));
        }

        public PartialViewResult _LocalSupplierView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.LocalSupplier>(_LocalSupplier.GetLocalSupplier(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _LocalSupplier.Delete(identity);
            return RedirectToAction("_LocalSupplierAll");
        }

        [HttpPost]
        public ActionResult Update(Models.LocalSupplier LocalSupplier)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (LocalSupplier.Identity.Equals(-1))
            {
                LocalSupplier.Identity = GetRandomNumber();
                _LocalSupplier.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.LocalSupplier>(LocalSupplier));
            }
            else
                _LocalSupplier.Update(AutoMapperConfig.Mapper().Map<BusinessModels.LocalSupplier>(LocalSupplier));
            return RedirectToAction("_LocalSupplierAll");
        }

        [HttpPost]
        public PartialViewResult LocalSupplierSearch(string searchString)
        {
            return PartialView("_LocalSupplierAll", AutoMapperConfig.Mapper().Map<List<Models.LocalSupplier>>(_LocalSupplier.GetAll().ToList().FindAll(p => p.SupplierName.ToLower().Contains(searchString.ToLower()))));
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
