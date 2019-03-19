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
    public class StocksShortageController : Controller
    {
        private BusinessLayer.StocksShortage _Stocks = new BusinessLayer.StocksShortage();
        private BusinessLayer.PurchaseRequest _PurchaseRequest = new BusinessLayer.PurchaseRequest();
        private BusinessLayer.PurchaseRequestDetails _PurchaseRequestDetails = new BusinessLayer.PurchaseRequestDetails();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _StocksShortageAll()
        {
            return PartialView(GetStockss("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _StocksShortageEdit(int identity)
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
        public ActionResult _StocksShortageCancel(int identity)
        {
            return RedirectToAction("_StocksShortageAll");
        }
        [HttpGet]
        public PartialViewResult _StocksShortageView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Stocks>(_Stocks.GetStocks(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Stocks.Delete(identity);
            return RedirectToAction("_StocksShortageAll");
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
            return RedirectToAction("_StocksShortageAll");
        }
        [HttpPost]
        public ActionResult _StocksShortageCreateRequest(int identity)
        {
            //Create purchase request
            BusinessModels.PurchaseRequest mdPurchaseRequest = new BusinessModels.PurchaseRequest();
            mdPurchaseRequest.LocationID = Convert.ToInt32(Convert.ToString(Session["LocationID"]));
            mdPurchaseRequest.CompanyTypeID = Convert.ToInt32(Convert.ToString(Session["EmployeeCompanyTypeID"]));
            mdPurchaseRequest.POStatus = 1;
            mdPurchaseRequest.IsActive = true;
            mdPurchaseRequest.IsVerified = false;
            mdPurchaseRequest.IsApproved = false;
            mdPurchaseRequest.CreatedDate = DateTime.Now;
            mdPurchaseRequest.CreatedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
            mdPurchaseRequest.OriginatorID = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
            BusinessModels.PurchaseRequest result=_PurchaseRequest.Insert(mdPurchaseRequest);

            //Insert Item Details
            BusinessModels.Stocks mdstrock = _Stocks.GetStocks(identity);
            BusinessModels.PurchaseRequestDetails mdPurchaseRequestdetails = new BusinessModels.PurchaseRequestDetails();
            mdPurchaseRequestdetails.PurchaseRequestID = result.Identity;
            mdPurchaseRequestdetails.Quantity = Convert.ToInt32(0);
            mdPurchaseRequestdetails.Purpose = String.Empty;
            _PurchaseRequestDetails.Insert(mdPurchaseRequestdetails);
            //_PurchaseRequest.Delete(identity);
            return RedirectToAction("_PurchaseRequestAll");
        }
        [HttpPost]
        public PartialViewResult StocksSearch(string searchString, string createdDate = "")
        {
            return PartialView("_StocksShortageAll", GetStockss("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_StocksShortageAll", GetStockss(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Stocks> GetStockss(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "ItemName" : "";

            var Stockss = new List<Models.Stocks>();

            if (Convert.ToString(Session["RoleAccess"]) == "1")
                Stockss = AutoMapperConfig.Mapper().Map<List<Models.Stocks>>(_Stocks.GetAllStockShortage());
            else if (Convert.ToString(Session["RoleAccess"]) == "2")
                Stockss = AutoMapperConfig.Mapper().Map<List<Models.Stocks>>(_Stocks.GetAllStockShortage(Convert.ToInt32(Convert.ToString(Session["LocationID"]))));
            else if (Convert.ToString(Session["RoleAccess"]) == "3")
                Stockss = AutoMapperConfig.Mapper().Map<List<Models.Stocks>>(_Stocks.GetAllStockShortage(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeID"]))));


            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                Stockss = AutoMapperConfig.Mapper().Map<List<Models.Stocks>>(_Stocks.GetAllStockShortage().ToList().FindAll(p => p.ItemMaster.ItemName.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                Stockss = AutoMapperConfig.Mapper().Map<List<Models.Stocks>>(_Stocks.GetAllStockShortage().ToList().FindAll(p => p.ItemMaster.ItemName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                Stockss = AutoMapperConfig.Mapper().Map<List<Models.Stocks>>(_Stocks.GetAllStockShortage().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "ItemName":
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
