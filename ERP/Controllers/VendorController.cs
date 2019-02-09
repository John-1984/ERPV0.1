using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class VendorController : Controller
    {
        private BusinessLayer.Vendor _Vendor = new BusinessLayer.Vendor();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _VendorAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.Vendor>>(_Vendor.GetAll()));
        }

        public PartialViewResult _VendorEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.Vendor());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Vendor>(_Vendor.GetVendor(identity)));
        }

        public PartialViewResult _VendorView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Vendor>(_Vendor.GetVendor(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Vendor.Delete(identity);
            return RedirectToAction("_VendorAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Vendor Vendor)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (Vendor.Identity.Equals(-1))
            {
                Vendor.Identity = GetRandomNumber();
                _Vendor.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Vendor>(Vendor));
            }
            else
                _Vendor.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Vendor>(Vendor));
            return RedirectToAction("_VendorAll");
        }

        [HttpPost]
        public PartialViewResult VendorSearch(string searchString)
        {
            return PartialView("_VendorAll", AutoMapperConfig.Mapper().Map<List<Models.Vendor>>(_Vendor.GetAll().ToList().FindAll(p => p.VendorName.ToLower().Contains(searchString.ToLower()))));
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
