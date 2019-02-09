using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class DiscountController : Controller
    {
        private BusinessLayer.Discount _Discount = new BusinessLayer.Discount();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _DiscountAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.Discount>>(_Discount.GetAll()));
        }

        public PartialViewResult _DiscountEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.Discount());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Discount>(_Discount.GetDiscount(identity)));
        }

        public PartialViewResult _DiscountView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Discount>(_Discount.GetDiscount(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Discount.Delete(identity);
            return RedirectToAction("_DiscountAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Discount Discount)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (Discount.Identity.Equals(-1))
            {
                Discount.Identity = GetRandomNumber();
                _Discount.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Discount>(Discount));
            }
            else
                _Discount.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Discount>(Discount));
            return RedirectToAction("_DiscountAll");
        }

        [HttpPost]
        public PartialViewResult DiscountSearch(string searchString)
        {
            return PartialView("_DiscountAll", AutoMapperConfig.Mapper().Map<List<Models.Discount>>(_Discount.GetAll().ToList().FindAll(p => p.DiscountValue.ToString().ToLower().Contains(searchString.ToLower()))));
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
