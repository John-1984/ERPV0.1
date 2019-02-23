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
    public class ItemMasterController : Controller
    {
        private BusinessLayer.ItemMaster _ItemMaster = new BusinessLayer.ItemMaster();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _ItemMasterAll()
        {
            return PartialView(GetItemMasters("", 1, "", ""));
        }

        [HttpGet]
        public ActionResult _ItemMasterCancel(int identity)
        {
            return RedirectToAction("_ItemMasterAll");
        }
        [HttpPost]
        public JsonResult Brand(string identity)
        {           
          return Json(new SelectList(_ItemMaster.GetAllBrands(identity), "Identity", "BrandName"));
        }

        [HttpPost]
        public JsonResult Vendor(string identity)
        {
            return Json(new SelectList(_ItemMaster.GetAllVendors(identity), "Identity", "VendorName"));
        }


        [HttpGet]
        public PartialViewResult _ItemMasterEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.ItemMaster mdItemMaster = new Models.ItemMaster();

                mdItemMaster.ProductMasterList = null;
                mdItemMaster.ProductMasterList = new SelectList(_ItemMaster.GetAllProductMasters(), "Identity", "ProductName");

                mdItemMaster.VendorList = null;
                mdItemMaster.VendorList = new SelectList(_ItemMaster.GetAllVendors(), "Identity", "VendorName");

                mdItemMaster.BrandList = null;
                mdItemMaster.BrandList = new SelectList(_ItemMaster.GetAllBrands(), "Identity", "BrandName");

                mdItemMaster.UOMList = null;
                mdItemMaster.UOMList = new SelectList(_ItemMaster.GetAllUOMs(), "Identity", "UOMName");               

                TempData["PageInfo"] = "Add ItemMaster Info";
                return PartialView(mdItemMaster);
            }
            else
            {
                Models.ItemMaster mdItemMaster = AutoMapperConfig.Mapper().Map<Models.ItemMaster>(_ItemMaster.GetItemMaster(identity));

                mdItemMaster.ProductMasterList = null;
                mdItemMaster.ProductMasterList = new SelectList(_ItemMaster.GetAllProductMasters(), "Identity", "ProductName", mdItemMaster.Brand.Vendor.ProductMasterID);

                mdItemMaster.VendorList = null;
                mdItemMaster.VendorList = new SelectList(_ItemMaster.GetAllVendors(mdItemMaster.Brand.Vendor.ProductMaster.Identity.ToString()), "Identity", "VendorName",mdItemMaster.Brand.VendorID);

                mdItemMaster.BrandList = null;
                mdItemMaster.BrandList = new SelectList(_ItemMaster.GetAllBrands(mdItemMaster.Brand.VendorID.ToString()), "Identity", "BrandName", mdItemMaster.BrandID);

                mdItemMaster.UOMList = null;
                mdItemMaster.UOMList = new SelectList(_ItemMaster.GetAllUOMs(), "Identity", "UOMName", mdItemMaster.UOMID);

                TempData["PageInfo"] = "Edit ItemMaster Info";
                TempData.Keep();
                return PartialView(mdItemMaster);
            }
        }

        [HttpGet]
        public PartialViewResult _ItemMasterView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.ItemMaster>(_ItemMaster.GetItemMaster(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _ItemMaster.Delete(identity);
            return RedirectToAction("_ItemMasterAll");
        }

        [HttpPost]
        public ActionResult Update(Models.ItemMaster ItemMaster, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.ItemMaster mdItem = AutoMapperConfig.Mapper().Map<BusinessModels.ItemMaster>(ItemMaster);
            var brndvalue = frmFields["hdnBrand"];
            var uomvalue = frmFields["hdnUOM"];

            if (!String.IsNullOrEmpty(brndvalue))
                mdItem.BrandID= int.Parse(brndvalue);

            if (!String.IsNullOrEmpty(uomvalue))
                mdItem.UOMID = int.Parse(uomvalue);

            if (ItemMaster.Identity.Equals(-1))
            {
                mdItem.CreatedDate = DateTime.Now;
                _ItemMaster.Insert(mdItem);
            }
            else
            {
                mdItem.ModifiedDate = DateTime.Now;
                _ItemMaster.Update(mdItem);
            }
            return RedirectToAction("_ItemMasterAll");
        }

        [HttpPost]
        public PartialViewResult ItemMasterSearch(string searchString, string createdDate = "")
        {
            return PartialView("_ItemMasterAll", GetItemMasters("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_ItemMasterAll", GetItemMasters(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.ItemMaster> GetItemMasters(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "ItemName" : "";

            var ItemMasters = AutoMapperConfig.Mapper().Map<List<Models.ItemMaster>>(_ItemMaster.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                ItemMasters = AutoMapperConfig.Mapper().Map<List<Models.ItemMaster>>(_ItemMaster.GetAll().ToList().FindAll(p => p.ItemName.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                ItemMasters = AutoMapperConfig.Mapper().Map<List<Models.ItemMaster>>(_ItemMaster.GetAll().ToList().FindAll(p => p.ItemName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                ItemMasters = AutoMapperConfig.Mapper().Map<List<Models.ItemMaster>>(_ItemMaster.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "ItemName":
                    ItemMasters = ItemMasters.OrderByDescending(stu => stu.ItemName).ToList();
                    break;
                case "DateAsc":
                    ItemMasters = ItemMasters.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    ItemMasters = ItemMasters.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    ItemMasters = ItemMasters.OrderBy(stu => stu.ItemName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return ItemMasters.ToPagedList(No_Of_Page, Size_Of_Page);
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
