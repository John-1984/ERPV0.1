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
    public class ProductMasterController : Controller
    {
        private BusinessLayer.ProductMaster _ProductMaster = new BusinessLayer.ProductMaster();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _ProductMasterAll()
        {
            return PartialView(GetProductMasters("", 1, "", ""));
        }

        [HttpGet]
        public ActionResult _ProductMasterCancel(int identity)
        {
            return RedirectToAction("_ProductMasterAll");
        }
        [HttpGet]
        public PartialViewResult _ProductMasterEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.ProductMaster());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.ProductMaster>(_ProductMaster.GetProductMaster(identity)));
        }

        [HttpGet]
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
                _ProductMaster.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.ProductMaster>(ProductMaster));
            }
            else
                _ProductMaster.Update(AutoMapperConfig.Mapper().Map<BusinessModels.ProductMaster>(ProductMaster));
            return RedirectToAction("_ProductMasterAll");
        }

        [HttpPost]
        public PartialViewResult ProductMasterSearch(string searchString, string createdDate = "")
        {
            return PartialView("_ProductMasterAll", GetProductMasters("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_ProductMasterAll", GetProductMasters(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.ProductMaster> GetProductMasters(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "ProductMasterName" : "";

            var ProductMasters = AutoMapperConfig.Mapper().Map<List<Models.ProductMaster>>(_ProductMaster.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                ProductMasters = AutoMapperConfig.Mapper().Map<List<Models.ProductMaster>>(_ProductMaster.GetAll().ToList().FindAll(p => p.ProductName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                ProductMasters = AutoMapperConfig.Mapper().Map<List<Models.ProductMaster>>(_ProductMaster.GetAll().ToList().FindAll(p => p.ProductName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                ProductMasters = AutoMapperConfig.Mapper().Map<List<Models.ProductMaster>>(_ProductMaster.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "ProductName":
                    ProductMasters = ProductMasters.OrderByDescending(stu => stu.ProductName).ToList();
                    break;
                case "DateAsc":
                    ProductMasters = ProductMasters.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    ProductMasters = ProductMasters.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    ProductMasters = ProductMasters.OrderBy(stu => stu.ProductName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return ProductMasters.ToPagedList(No_Of_Page, Size_Of_Page);
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
