using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class PurchaseRequestController : Controller
    {
        private BusinessLayer.PurchaseRequest _PurchaseRequest = new BusinessLayer.PurchaseRequest();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _PurchaseRequestAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.PurchaseRequest>>(_PurchaseRequest.GetAll()));
        }

        public PartialViewResult _PurchaseRequestEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.PurchaseRequest());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.PurchaseRequest>(_PurchaseRequest.GetPurchaseRequest(identity)));
        }

        public PartialViewResult _PurchaseRequestView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.PurchaseRequest>(_PurchaseRequest.GetPurchaseRequest(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _PurchaseRequest.Delete(identity);
            return RedirectToAction("_PurchaseRequestAll");
        }

        [HttpPost]
        public ActionResult Update(Models.PurchaseRequest PurchaseRequest)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (PurchaseRequest.Identity.Equals(-1))
            {
                PurchaseRequest.Identity = GetRandomNumber();
                _PurchaseRequest.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.PurchaseRequest>(PurchaseRequest));
            }
            else
                _PurchaseRequest.Update(AutoMapperConfig.Mapper().Map<BusinessModels.PurchaseRequest>(PurchaseRequest));
            return RedirectToAction("_PurchaseRequestAll");
        }

        [HttpPost]
        public PartialViewResult PurchaseRequestSearch(string searchString)
        {
            return PartialView("_PurchaseRequestAll", AutoMapperConfig.Mapper().Map<List<Models.PurchaseRequest>>(_PurchaseRequest.GetAll().ToList().FindAll(p => p.CaseNo.ToLower().Contains(searchString.ToLower()))));
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
