using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class RegionController : Controller
    {
        private BusinessLayer.Region _Region = new BusinessLayer.Region();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _RegionAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.Region>>(_Region.GetAll()));
        }

        public PartialViewResult _RegionEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.Region());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Region>(_Region.GetRegion(identity)));
        }

        public PartialViewResult _RegionView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Region>(_Region.GetRegion(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Region.Delete(identity);
            return RedirectToAction("_RegionAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Region Region)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (Region.Identity.Equals(-1))
            {
                Region.Identity = GetRandomNumber();
                _Region.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Region>(Region));
            }
            else
                _Region.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Region>(Region));
            return RedirectToAction("_RegionAll");
        }

        [HttpPost]
        public PartialViewResult RegionSearch(string searchString)
        {
            return PartialView("_RegionAll", AutoMapperConfig.Mapper().Map<List<Models.Region>>(_Region.GetAll().ToList().FindAll(p => p.RegionName.ToLower().Contains(searchString.ToLower()))));
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
