using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class CountryController : Controller
    {
        private BusinessLayer.Country _Country = new BusinessLayer.Country();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _CountryAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.Country>>(_Country.GetAll()));
        }

        public PartialViewResult _CountryEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.Country());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Country>(_Country.GetCountry(identity)));
        }

        public PartialViewResult _CountryView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Country>(_Country.GetCountry(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Country.Delete(identity);
            return RedirectToAction("_CountryAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Country Country)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (Country.Identity.Equals(-1))
            {
                Country.Identity = GetRandomNumber();
                _Country.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Country>(Country));
            }
            else
                _Country.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Country>(Country));
            return RedirectToAction("_CountryAll");
        }

        [HttpPost]
        public PartialViewResult CountrySearch(string searchString)
        {
            return PartialView("_CountryAll", AutoMapperConfig.Mapper().Map<List<Models.Country>>(_Country.GetAll().ToList().FindAll(p => p.CountryName.ToLower().Contains(searchString.ToLower()))));
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
