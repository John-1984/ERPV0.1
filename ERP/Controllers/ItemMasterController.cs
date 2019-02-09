using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class ItemMasterController : Controller
    {
        private BusinessLayer.ItemMaster _ItemMaster = new BusinessLayer.ItemMaster();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _ItemMasterAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.ItemMaster>>(_ItemMaster.GetAll()));
        }

        public PartialViewResult _ItemMasterEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.ItemMaster());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.ItemMaster>(_ItemMaster.GetItemMaster(identity)));
        }

        public PartialViewResult _ItemMasterView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.ItemMaster>(_ItemMaster.GetItemMaster(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _ItemMaster.Delete(identity);
            return RedirectToAction("_ItemMasterAll");
        }

        [HttpPost]
        public ActionResult Update(Models.ItemMaster ItemMaster)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (ItemMaster.Identity.Equals(-1))
            {
                ItemMaster.Identity = GetRandomNumber();
                _ItemMaster.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.ItemMaster>(ItemMaster));
            }
            else
                _ItemMaster.Update(AutoMapperConfig.Mapper().Map<BusinessModels.ItemMaster>(ItemMaster));
            return RedirectToAction("_ItemMasterAll");
        }

        [HttpPost]
        public PartialViewResult ItemMasterSearch(string searchString)
        {
            return PartialView("_ItemMasterAll", AutoMapperConfig.Mapper().Map<List<Models.ItemMaster>>(_ItemMaster.GetAll().ToList().FindAll(p => p.ItemName.ToLower().Contains(searchString.ToLower()))));
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
