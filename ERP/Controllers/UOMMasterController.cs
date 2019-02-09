using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class UOMMasterController : Controller
    {
        private BusinessLayer.UOMMaster _UOMMaster = new BusinessLayer.UOMMaster();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _UOMMasterAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.UOMMaster>>(_UOMMaster.GetAll()));
        }

        public PartialViewResult _UOMMasterEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.UOMMaster());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.UOMMaster>(_UOMMaster.GetUOMMaster(identity)));
        }

        public PartialViewResult _UOMMasterView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.UOMMaster>(_UOMMaster.GetUOMMaster(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _UOMMaster.Delete(identity);
            return RedirectToAction("_UOMMasterAll");
        }

        [HttpPost]
        public ActionResult Update(Models.UOMMaster UOMMaster)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (UOMMaster.Identity.Equals(-1))
            {
                UOMMaster.Identity = GetRandomNumber();
                _UOMMaster.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.UOMMaster>(UOMMaster));
            }
            else
                _UOMMaster.Update(AutoMapperConfig.Mapper().Map<BusinessModels.UOMMaster>(UOMMaster));
            return RedirectToAction("_UOMMasterAll");
        }

        [HttpPost]
        public PartialViewResult UOMMasterSearch(string searchString)
        {
            return PartialView("_UOMMasterAll", AutoMapperConfig.Mapper().Map<List<Models.UOMMaster>>(_UOMMaster.GetAll().ToList().FindAll(p => p.UOMName.ToLower().Contains(searchString.ToLower()))));
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
