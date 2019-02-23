using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;
using System.Runtime;
using System.Globalization;

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
            return PartialView(GetPurchaseRequestTypes("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _PurchaseRequestTypeEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.PurchaseRequestType());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.PurchaseRequestType>(_PurchaseRequestType.GetPurchaseRequestType(identity)));
        }

        [HttpGet]
        public ActionResult _PurchaseRequestTypeCancel(int identity)
        {
            return RedirectToAction("_PurchaseRequestTypeAll");
        }

        [HttpGet]
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
        public ActionResult Update(Models.PurchaseRequestType PurchaseRequestType, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value

            BusinessModels.PurchaseRequestType mdPurchase = AutoMapperConfig.Mapper().Map<BusinessModels.PurchaseRequestType>(PurchaseRequestType);

            if (PurchaseRequestType.Identity.Equals(-1))
            {
                mdPurchase.CreatedDate = DateTime.Now;

                _PurchaseRequestType.Insert(mdPurchase);
            }
            else
            {
                mdPurchase.ModifiedDate = DateTime.Now;
                _PurchaseRequestType.Update(mdPurchase);
            }
            return RedirectToAction("_PurchaseRequestTypeAll");
        }

        [HttpPost]
        public PartialViewResult PurchaseRequestTypeSearch(string searchString, string createdDate = "")
        {
            return PartialView("_PurchaseRequestTypeAll", GetPurchaseRequestTypes("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_PurchaseRequestTypeAll", GetPurchaseRequestTypes(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.PurchaseRequestType> GetPurchaseRequestTypes(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "PurchaseRequestTypeName" : "";

            var PurchaseRequestTypes = AutoMapperConfig.Mapper().Map<List<Models.PurchaseRequestType>>(_PurchaseRequestType.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                PurchaseRequestTypes = AutoMapperConfig.Mapper().Map<List<Models.PurchaseRequestType>>(_PurchaseRequestType.GetAll().ToList().FindAll(p => p.Name.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                PurchaseRequestTypes = AutoMapperConfig.Mapper().Map<List<Models.PurchaseRequestType>>(_PurchaseRequestType.GetAll().ToList().FindAll(p => p.Name.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                PurchaseRequestTypes = AutoMapperConfig.Mapper().Map<List<Models.PurchaseRequestType>>(_PurchaseRequestType.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "Name":
                    PurchaseRequestTypes = PurchaseRequestTypes.OrderByDescending(stu => stu.Name).ToList();
                    break;
                case "DateAsc":
                    PurchaseRequestTypes = PurchaseRequestTypes.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    PurchaseRequestTypes = PurchaseRequestTypes.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    PurchaseRequestTypes = PurchaseRequestTypes.OrderBy(stu => stu.Name).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return PurchaseRequestTypes.ToPagedList(No_Of_Page, Size_Of_Page);
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
