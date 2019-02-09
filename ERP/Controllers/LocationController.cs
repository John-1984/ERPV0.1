using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class LocationController : Controller
    {
        private BusinessLayer.Location _Location = new BusinessLayer.Location();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _LocationAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.Location>>(_Location.GetAll()));
        }

        public PartialViewResult _LocationEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.Location());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Location>(_Location.GetLocation(identity)));
        }

        public PartialViewResult _LocationView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Location>(_Location.GetLocation(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Location.Delete(identity);
            return RedirectToAction("_LocationAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Location Location)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (Location.Identity.Equals(-1))
            {
                Location.Identity = GetRandomNumber();
                _Location.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Location>(Location));
            }
            else
                _Location.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Location>(Location));
            return RedirectToAction("_LocationAll");
        }

        [HttpPost]
        public PartialViewResult LocationSearch(string searchString)
        {
            return PartialView("_LocationAll", AutoMapperConfig.Mapper().Map<List<Models.Location>>(_Location.GetAll().ToList().FindAll(p => p.LocationName.ToLower().Contains(searchString.ToLower()))));
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
