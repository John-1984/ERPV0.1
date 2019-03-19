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
    [ERP.CustomeFilters.AjaxModelValidatorFilter]
    [ERP.CustomeFilters.LoggingFilter]
    [ERP.CustomeFilters.ExceptionFilter]
    public class DeadStockController : Controller
    {
        private BusinessLayer.DeadStock _Stocks = new BusinessLayer.DeadStock();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _DeadStockAll()
        {
            return PartialView(GetStockss("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _DeadStockEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.Stocks mdStocks = new Models.Stocks();

                mdStocks.ProductMasterList = null;
                mdStocks.ProductMasterList = new SelectList(_Stocks.GetAllProductMasters(), "Identity", "ProductName");

                mdStocks.VendorList = null;
                mdStocks.VendorList = new SelectList(_Stocks.GetAllVendors(), "Identity", "VendorName");

                mdStocks.BrandList = null;
                mdStocks.BrandList = new SelectList(_Stocks.GetAllBrands(), "Identity", "BrandName");

                mdStocks.ItemList = null;
                mdStocks.ItemList = new SelectList(_Stocks.GetAllItems(), "Identity", "ItemName");

                TempData["PageInfo"] = "Add Stocks Info";
                return PartialView(mdStocks);
            }
            else
            {
                Models.Stocks mdStocks = AutoMapperConfig.Mapper().Map<Models.Stocks>(_Stocks.GetStocks(identity));
                // Models.Stocks mdStocks = new Models.Stocks();
                mdStocks.ProductMasterList = null;
                mdStocks.ProductMasterList = new SelectList(_Stocks.GetAllProductMasters(), "Identity", "ProductName", mdStocks.ItemMaster.Brand.Vendor.ProductMasterID);

                mdStocks.VendorList = null;
                mdStocks.VendorList = new SelectList(_Stocks.GetAllVendors(), "Identity", "VendorName", mdStocks.ItemMaster.Brand.VendorID);

                mdStocks.BrandList = null;
                mdStocks.BrandList = new SelectList(_Stocks.GetAllBrands(), "Identity", "BrandName", mdStocks.ItemMaster.BrandID);

                mdStocks.ItemList = null;
                mdStocks.ItemList = new SelectList(_Stocks.GetAllItems(), "Identity", "ItemName", mdStocks.ItemID);
                mdStocks.Identity = identity;
                TempData["PageInfo"] = "Edit Stocks Info";
                TempData.Keep();
                return PartialView(mdStocks);
            }
        }
        [HttpPost]
        public JsonResult Brand(string identity)
        {
            return Json(new SelectList(_Stocks.GetAllBrands(identity), "Identity", "BrandName"));
        }

        [HttpPost]
        public JsonResult Vendor(string identity)
        {
            return Json(new SelectList(_Stocks.GetAllVendors(identity), "Identity", "VendorName"));
        }

        [HttpPost]
        public JsonResult Item(string identity)
        {
            return Json(_Stocks.GetItemDetails(identity));
        }

        [HttpGet]
        public ActionResult _DeadStockCancel(int identity)
        {
            return RedirectToAction("_DeadStockAll");
        }
        [HttpGet]
        public PartialViewResult _DeadStockView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Stocks>(_Stocks.GetStocks(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Stocks.Delete(identity);
            return RedirectToAction("_DeadStockAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Stocks Stocks, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.Stocks mdStocks = AutoMapperConfig.Mapper().Map<BusinessModels.Stocks>(Stocks);
            var itemvalue = frmFields["hdnItem"];

            mdStocks.LocationId = Convert.ToInt32(Convert.ToString(Session["LocationID"]));
            mdStocks.CompanyTypeID = Convert.ToInt32(Convert.ToString(Session["EmployeeCompanyTypeID"]));
            if (!String.IsNullOrEmpty(itemvalue))
                mdStocks.ItemID = int.Parse(itemvalue);

            mdStocks.IsActive = true;
            if (mdStocks.Identity.Equals(-1))
            {
                mdStocks.CreatedDate = DateTime.Now;
                mdStocks.CreatedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));

                if (!String.IsNullOrEmpty(itemvalue))
                    mdStocks.ItemID = Convert.ToInt32(itemvalue);

                _Stocks.Insert(mdStocks);
            }
            else
            {
                mdStocks.ModifiedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
                mdStocks.ModifiedDate = DateTime.Now;
                _Stocks.Update(mdStocks);
            }
            return RedirectToAction("_DeadStockAll");
        }

        [HttpPost]
        public PartialViewResult StocksSearch(string searchString, string createdDate = "")
        {
            return PartialView("_DeadStockAll", GetStockss("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_DeadStockAll", GetStockss(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Stocks> GetStockss(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "ItemName" : "";

            var Stockss = new List<Models.Stocks>();

            if (Convert.ToString(Session["RoleAccess"]) == "1")
                Stockss = AutoMapperConfig.Mapper().Map<List<Models.Stocks>>(_Stocks.GetAllDeadStock());
            else if (Convert.ToString(Session["RoleAccess"]) == "2")
                Stockss = AutoMapperConfig.Mapper().Map<List<Models.Stocks>>(_Stocks.GetAllDeadStock(Convert.ToInt32(Convert.ToString(Session["LocationID"]))));
            else if (Convert.ToString(Session["RoleAccess"]) == "3")
                Stockss = AutoMapperConfig.Mapper().Map<List<Models.Stocks>>(_Stocks.GetAllDeadStock(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeID"]))));


            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                Stockss = AutoMapperConfig.Mapper().Map<List<Models.Stocks>>(_Stocks.GetAllDeadStock().ToList().FindAll(p => p.ItemMaster.ItemName.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                Stockss = AutoMapperConfig.Mapper().Map<List<Models.Stocks>>(_Stocks.GetAllDeadStock().ToList().FindAll(p => p.ItemMaster.ItemName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                Stockss = AutoMapperConfig.Mapper().Map<List<Models.Stocks>>(_Stocks.GetAllDeadStock().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "CustomerName":
                    Stockss = Stockss.OrderByDescending(stu => stu.ItemMaster.ItemName).ToList();
                    break;
                case "DateAsc":
                    Stockss = Stockss.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    Stockss = Stockss.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    Stockss = Stockss.OrderBy(stu => stu.ItemMaster.ItemName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return Stockss.ToPagedList(No_Of_Page, Size_Of_Page);
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
