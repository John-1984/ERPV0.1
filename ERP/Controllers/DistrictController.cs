using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class DistrictController : Controller
    {
        private BusinessLayer.District _District = new BusinessLayer.District();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _DistrictAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.District>>(_District.GetAll()));
        }

        public PartialViewResult _DistrictEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.District());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.District>(_District.GetDistrict(identity)));
        }

        public PartialViewResult _DistrictView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.District>(_District.GetDistrict(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _District.Delete(identity);
            return RedirectToAction("_DistrictAll");
        }

        [HttpPost]
        public ActionResult Update(Models.District District)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (District.Identity.Equals(-1))
            {
                District.Identity = GetRandomNumber();
                _District.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.District>(District));
            }
            else
                _District.Update(AutoMapperConfig.Mapper().Map<BusinessModels.District>(District));
            return RedirectToAction("_DistrictAll");
        }

        [HttpPost]
        public PartialViewResult DistrictSearch(string searchString)
        {
            return PartialView("_DistrictAll", AutoMapperConfig.Mapper().Map<List<Models.District>>(_District.GetAll().ToList().FindAll(p => p.DistrictName.ToLower().Contains(searchString.ToLower()))));
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
