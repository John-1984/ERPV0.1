using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private BusinessLayer.PurchaseOrder _PurchaseOrder = new BusinessLayer.PurchaseOrder();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _PurchaseOrderAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.PurchaseOrder>>(_PurchaseOrder.GetAll()));
        }

        public PartialViewResult _PurchaseOrderEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.PurchaseOrder());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.PurchaseOrder>(_PurchaseOrder.GetPurchaseOrder(identity)));
        }

        public PartialViewResult _PurchaseOrderView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.PurchaseOrder>(_PurchaseOrder.GetPurchaseOrder(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _PurchaseOrder.Delete(identity);
            return RedirectToAction("_PurchaseOrderAll");
        }

        [HttpPost]
        public ActionResult Update(Models.PurchaseOrder PurchaseOrder)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (PurchaseOrder.Identity.Equals(-1))
            {
                PurchaseOrder.Identity = GetRandomNumber();
                _PurchaseOrder.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.PurchaseOrder>(PurchaseOrder));
            }
            else
                _PurchaseOrder.Update(AutoMapperConfig.Mapper().Map<BusinessModels.PurchaseOrder>(PurchaseOrder));
            return RedirectToAction("_PurchaseOrderAll");
        }

        [HttpPost]
        public PartialViewResult PurchaseOrderSearch(string searchString)
        {
            return PartialView("_PurchaseOrderAll", AutoMapperConfig.Mapper().Map<List<Models.PurchaseOrder>>(_PurchaseOrder.GetAll().ToList().FindAll(p => p.POCode.ToLower().Contains(searchString.ToLower()))));
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
