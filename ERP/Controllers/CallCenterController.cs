using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class CallCenterController : Controller
    {
        private BusinessLayer.CallCenter _CallCenter = new BusinessLayer.CallCenter();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _CallCenterAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.CallCenter>>(_CallCenter.GetAll()));
        }

        public PartialViewResult _CallCenterEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.CallCenter());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.CallCenter>(_CallCenter.GetCallCenter(identity)));
        }

        public PartialViewResult _CallCenterView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.CallCenter>(_CallCenter.GetCallCenter(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _CallCenter.Delete(identity);
            return RedirectToAction("_CallCenterAll");
        }

        [HttpPost]
        public ActionResult Update(Models.CallCenter CallCenter)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (CallCenter.Identity.Equals(-1))
            {
                CallCenter.Identity = GetRandomNumber();
                _CallCenter.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.CallCenter>(CallCenter));
            }
            else
                _CallCenter.Update(AutoMapperConfig.Mapper().Map<BusinessModels.CallCenter>(CallCenter));
            return RedirectToAction("_CallCenterAll");
        }

        [HttpPost]
        public PartialViewResult CallCenterSearch(string searchString)
        {
            return PartialView("_CallCenterAll", AutoMapperConfig.Mapper().Map<List<Models.CallCenter>>(_CallCenter.GetAll().ToList().FindAll(p => p.CustomerID.ToString().ToLower().Contains(searchString.ToLower()))));
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
