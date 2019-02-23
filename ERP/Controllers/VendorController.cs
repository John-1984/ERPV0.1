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
    public class VendorController : Controller
    {
        private BusinessLayer.Vendor _Vendor = new BusinessLayer.Vendor();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _VendorAll()
        {
            return PartialView(GetVendors("", 1, "", ""));
        }
        [HttpGet]
        public ActionResult _VendorCancel(int identity)
        {
            return RedirectToAction("_VendorAll");
        }

        [HttpGet]
        public PartialViewResult _VendorEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.Vendor mdvendor = new Models.Vendor();
                mdvendor.ProductMasterList = null;
                mdvendor.ProductMasterList = new SelectList(_Vendor.GetAllProductMaster(), "Identity", "ProductName");
                return PartialView(mdvendor);
            } 
            else
            {
                Models.Vendor mdvendor = AutoMapperConfig.Mapper().Map<Models.Vendor>(_Vendor.GetVendor(identity));

                mdvendor.ProductMasterList = null;
                mdvendor.ProductMasterList = new SelectList(_Vendor.GetAllProductMaster(), "Identity", "ProductName",mdvendor.ProductMasterID);

                return PartialView(mdvendor);
            }

        }

        [HttpGet]
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
        public ActionResult Update(Models.Vendor Vendor, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.Vendor mdVendor = AutoMapperConfig.Mapper().Map<BusinessModels.Vendor>(Vendor);

            var value = frmFields["hdnProductMaster"];

            if (!String.IsNullOrEmpty(value))
                mdVendor.ProductMasterID = int.Parse(value);


            if (Vendor.Identity.Equals(-1))
            {
                mdVendor.CreatedDate = DateTime.Now;
                _Vendor.Insert(mdVendor);
            }
            else
            {
                mdVendor.ModifiedDate = DateTime.Now;
                _Vendor.Update(mdVendor);

            }
            return RedirectToAction("_VendorAll");
        }

        [HttpPost]
        public PartialViewResult VendorSearch(string searchString, string createdDate = "")
        {
            return PartialView("_VendorAll", GetVendors("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_VendorAll", GetVendors(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Vendor> GetVendors(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "VendorName" : "";

            var Vendors = AutoMapperConfig.Mapper().Map<List<Models.Vendor>>(_Vendor.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                Vendors = AutoMapperConfig.Mapper().Map<List<Models.Vendor>>(_Vendor.GetAll().ToList().FindAll(p => p.VendorName.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                Vendors = AutoMapperConfig.Mapper().Map<List<Models.Vendor>>(_Vendor.GetAll().ToList().FindAll(p => p.VendorName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                Vendors = AutoMapperConfig.Mapper().Map<List<Models.Vendor>>(_Vendor.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "VendorName":
                    Vendors = Vendors.OrderByDescending(stu => stu.VendorName).ToList();
                    break;
                case "DateAsc":
                    Vendors = Vendors.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    Vendors = Vendors.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    Vendors = Vendors.OrderBy(stu => stu.VendorName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return Vendors.ToPagedList(No_Of_Page, Size_Of_Page);
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
