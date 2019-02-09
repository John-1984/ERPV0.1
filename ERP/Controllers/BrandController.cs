using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class BrandController : Controller
    {
        private BusinessLayer.Brand _Brand = new BusinessLayer.Brand();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _BrandAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.Brand>>(_Brand.GetAll()));
        }

        public PartialViewResult _BrandEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.Brand());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Brand>(_Brand.GetBrand(identity)));
        }

        public PartialViewResult _BrandView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Brand>(_Brand.GetBrand(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Brand.Delete(identity);
            return RedirectToAction("_BrandAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Brand Brand)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (Brand.Identity.Equals(-1))
            {
                Brand.Identity = GetRandomNumber();
                _Brand.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Brand>(Brand));
            }
            else
                _Brand.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Brand>(Brand));
            return RedirectToAction("_BrandAll");
        }

        [HttpPost]
        public PartialViewResult BrandSearch(string searchString)
        {
            return PartialView("_BrandAll", AutoMapperConfig.Mapper().Map<List<Models.Brand>>(_Brand.GetAll().ToList().FindAll(p => p.BrandName.ToLower().Contains(searchString.ToLower()))));
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
