using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class ProductMasterController : Controller
    {
        private BusinessLayer.ProductMaster _ProductMaster = new BusinessLayer.ProductMaster();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _ProductMasterAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.ProductMaster>>(_ProductMaster.GetAll()));
        }

        public PartialViewResult _ProductMasterEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.ProductMaster());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.ProductMaster>(_ProductMaster.GetProductMaster(identity)));
        }

        public PartialViewResult _ProductMasterView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.ProductMaster>(_ProductMaster.GetProductMaster(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _ProductMaster.Delete(identity);
            return RedirectToAction("_ProductMasterAll");
        }

        [HttpPost]
        public ActionResult Update(Models.ProductMaster ProductMaster)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (ProductMaster.Identity.Equals(-1))
            {
                ProductMaster.Identity = GetRandomNumber();
                _ProductMaster.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.ProductMaster>(ProductMaster));
            }
            else
                _ProductMaster.Update(AutoMapperConfig.Mapper().Map<BusinessModels.ProductMaster>(ProductMaster));
            return RedirectToAction("_ProductMasterAll");
        }

        [HttpPost]
        public PartialViewResult ProductMasterSearch(string searchString)
        {
            return PartialView("_ProductMasterAll", AutoMapperConfig.Mapper().Map<List<Models.ProductMaster>>(_ProductMaster.GetAll().ToList().FindAll(p => p.ProductName.ToLower().Contains(searchString.ToLower()))));
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
