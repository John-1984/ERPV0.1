using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class StoreInfoController : Controller
    {
        private BusinessLayer.StoreInfo _StoreInfo = new BusinessLayer.StoreInfo();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _StoreInfoAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.StoreInfo>>(_StoreInfo.GetAll()));
        }

        public PartialViewResult _StoreInfoEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.StoreInfo());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.StoreInfo>(_StoreInfo.GetStoreInfo(identity)));
        }

        public PartialViewResult _StoreInfoView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.StoreInfo>(_StoreInfo.GetStoreInfo(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _StoreInfo.Delete(identity);
            return RedirectToAction("_StoreInfoAll");
        }

        [HttpPost]
        public ActionResult Update(Models.StoreInfo StoreInfo)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (StoreInfo.Identity.Equals(-1))
            {
                StoreInfo.Identity = GetRandomNumber();
                _StoreInfo.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.StoreInfo>(StoreInfo));
            }
            else
                _StoreInfo.Update(AutoMapperConfig.Mapper().Map<BusinessModels.StoreInfo>(StoreInfo));
            return RedirectToAction("_StoreInfoAll");
        }

        [HttpPost]
        public PartialViewResult StoreInfoSearch(string searchString)
        {
            return PartialView("_StoreInfoAll", AutoMapperConfig.Mapper().Map<List<Models.StoreInfo>>(_StoreInfo.GetAll().ToList().FindAll(p => p.StoreName.ToLower().Contains(searchString.ToLower()))));
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
