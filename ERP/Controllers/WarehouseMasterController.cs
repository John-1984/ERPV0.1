using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class WarehouseMasterController : Controller
    {
        private BusinessLayer.WarehouseMaster _WarehouseMaster = new BusinessLayer.WarehouseMaster();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _WarehouseMasterAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.WarehouseMaster>>(_WarehouseMaster.GetAll()));
        }

        public PartialViewResult _WarehouseMasterEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.WarehouseMaster());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.WarehouseMaster>(_WarehouseMaster.GetWarehouseMaster(identity)));
        }

        public PartialViewResult _WarehouseMasterView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.WarehouseMaster>(_WarehouseMaster.GetWarehouseMaster(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _WarehouseMaster.Delete(identity);
            return RedirectToAction("_WarehouseMasterAll");
        }

        [HttpPost]
        public ActionResult Update(Models.WarehouseMaster WarehouseMaster)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (WarehouseMaster.Identity.Equals(-1))
            {
                WarehouseMaster.Identity = GetRandomNumber();
                _WarehouseMaster.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.WarehouseMaster>(WarehouseMaster));
            }
            else
                _WarehouseMaster.Update(AutoMapperConfig.Mapper().Map<BusinessModels.WarehouseMaster>(WarehouseMaster));
            return RedirectToAction("_WarehouseMasterAll");
        }

        [HttpPost]
        public PartialViewResult WarehouseMasterSearch(string searchString)
        {
            return PartialView("_WarehouseMasterAll", AutoMapperConfig.Mapper().Map<List<Models.WarehouseMaster>>(_WarehouseMaster.GetAll().ToList().FindAll(p => p.WarehouseName.ToLower().Contains(searchString.ToLower()))));
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
