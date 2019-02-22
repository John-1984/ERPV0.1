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
    public class BrandController : Controller
    {
        private BusinessLayer.Brand _Brand = new BusinessLayer.Brand();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _BrandAll()
        {
            return PartialView(GetBrands("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _BrandEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.Brand mdBrand = new Models.Brand();

                mdBrand.VendorList = null;
                mdBrand.VendorList = new SelectList(_Brand.GetAllVendors(), "Identity", "VendorName");               

                TempData["PageInfo"] = "Add Brand Info";
                return PartialView(mdBrand);
            }
            else
            {
                Models.Brand mdBrand = AutoMapperConfig.Mapper().Map<Models.Brand>(_Brand.GetBrand(identity));

                mdBrand.VendorList = null;
                mdBrand.VendorList = new SelectList(_Brand.GetAllVendors(), "Identity", "VendorName",mdBrand.VendorID );

                TempData["PageInfo"] = "Edit Brand Info";
                TempData.Keep();
                return PartialView(mdBrand);
            }
        }

        [HttpGet]
        public ActionResult _BrandCancel(int identity)
        {
            return RedirectToAction("_BrandAll");
        }
        [HttpGet]
        public PartialViewResult _BrandView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Brand>(_Brand.GetBrand(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Brand.Delete(identity);
            return RedirectToAction("_BrandAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Brand Brand, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value

            BusinessModels.Brand mdBrand = AutoMapperConfig.Mapper().Map<BusinessModels.Brand>(Brand);
            var value = frmFields["hdnVendor"];

            if (!String.IsNullOrEmpty(value))
                mdBrand.VendorID = int.Parse(value);

            if (Brand.Identity.Equals(-1))
            {
                mdBrand.CreatedDate = DateTime.Now;
                _Brand.Insert(mdBrand);
            }
            else
            {
                mdBrand.ModifiedDate = DateTime.Now;
               
                _Brand.Update(mdBrand);
            }
            return RedirectToAction("_BrandAll");
        }

        [HttpPost]
        public PartialViewResult BrandSearch(string searchString, string createdDate = "")
        {
            return PartialView("_BrandAll", GetBrands("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_BrandAll", GetBrands(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Brand> GetBrands(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "BrandName" : "";

            var Brands = AutoMapperConfig.Mapper().Map<List<Models.Brand>>(_Brand.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                Brands = AutoMapperConfig.Mapper().Map<List<Models.Brand>>(_Brand.GetAll().ToList().FindAll(p => p.BrandName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                Brands = AutoMapperConfig.Mapper().Map<List<Models.Brand>>(_Brand.GetAll().ToList().FindAll(p => p.BrandName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                Brands = AutoMapperConfig.Mapper().Map<List<Models.Brand>>(_Brand.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "BrandName":
                    Brands = Brands.OrderByDescending(stu => stu.BrandName).ToList();
                    break;
                case "DateAsc":
                    Brands = Brands.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    Brands = Brands.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    Brands = Brands.OrderBy(stu => stu.BrandName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return Brands.ToPagedList(No_Of_Page, Size_Of_Page);
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
