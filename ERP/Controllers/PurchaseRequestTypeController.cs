using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class PurchaseRequestTypeController : Controller
    {
        private BusinessLayer.PurchaseRequestType _PurchaseRequestType = new BusinessLayer.PurchaseRequestType();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _PurchaseRequestTypeAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.PurchaseRequestType>>(_PurchaseRequestType.GetAll()));
        }

        public PartialViewResult _PurchaseRequestTypeEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.PurchaseRequestType());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.PurchaseRequestType>(_PurchaseRequestType.GetPurchaseRequestType(identity)));
        }

        public PartialViewResult _PurchaseRequestTypeView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.PurchaseRequestType>(_PurchaseRequestType.GetPurchaseRequestType(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _PurchaseRequestType.Delete(identity);
            return RedirectToAction("_PurchaseRequestTypeAll");
        }

        [HttpPost]
        public ActionResult Update(Models.PurchaseRequestType PurchaseRequestType)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (PurchaseRequestType.Identity.Equals(-1))
            {
                PurchaseRequestType.Identity = GetRandomNumber();
                _PurchaseRequestType.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.PurchaseRequestType>(PurchaseRequestType));
            }
            else
                _PurchaseRequestType.Update(AutoMapperConfig.Mapper().Map<BusinessModels.PurchaseRequestType>(PurchaseRequestType));
            return RedirectToAction("_PurchaseRequestTypeAll");
        }

        [HttpPost]
        public PartialViewResult PurchaseRequestTypeSearch(string searchString)
        {
            return PartialView("_PurchaseRequestTypeAll", AutoMapperConfig.Mapper().Map<List<Models.PurchaseRequestType>>(_PurchaseRequestType.GetAll().ToList().FindAll(p => p.Name.ToLower().Contains(searchString.ToLower()))));
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
