using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class ProductEnquiryController : Controller
    {
        private BusinessLayer.ProductEnquiry _ProductEnquiry = new BusinessLayer.ProductEnquiry();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _ProductEnquiryAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.ProductEnquiry>>(_ProductEnquiry.GetAll()));
        }

        public PartialViewResult _ProductEnquiryEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.ProductEnquiry());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.ProductEnquiry>(_ProductEnquiry.GetProductEnquiry(identity)));
        }

        public PartialViewResult _ProductEnquiryView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.ProductEnquiry>(_ProductEnquiry.GetProductEnquiry(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _ProductEnquiry.Delete(identity);
            return RedirectToAction("_ProductEnquiryAll");
        }

        [HttpPost]
        public ActionResult Update(Models.ProductEnquiry ProductEnquiry)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (ProductEnquiry.Identity.Equals(-1))
            {
                ProductEnquiry.Identity = GetRandomNumber();
                _ProductEnquiry.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.ProductEnquiry>(ProductEnquiry));
            }
            else
                _ProductEnquiry.Update(AutoMapperConfig.Mapper().Map<BusinessModels.ProductEnquiry>(ProductEnquiry));
            return RedirectToAction("_ProductEnquiryAll");
        }

        [HttpPost]
        public PartialViewResult ProductEnquirySearch(string searchString)
        {
            return PartialView("_ProductEnquiryAll", AutoMapperConfig.Mapper().Map<List<Models.ProductEnquiry>>(_ProductEnquiry.GetAll().ToList().FindAll(p => p.Status.ToString().ToLower().Contains(searchString.ToLower()))));
        }

        //Function to get random number
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min = 0, int max = 1000)
        {
            lock (getrandom) // synchronize.to
            {
                return getrandom.Next(min, max);
            }
        }

    }
}
