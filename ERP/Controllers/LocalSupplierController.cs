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
    public class LocalSupplierController : Controller
    {
        private BusinessLayer.LocalSupplier _LocalSupplier = new BusinessLayer.LocalSupplier();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _LocalSupplierAll()
        {
            return PartialView(GetLocalSuppliers("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _LocalSupplierEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.LocalSupplier mdLocalSupplier = new Models.LocalSupplier();
                mdLocalSupplier.ItemList = null;
                mdLocalSupplier.ItemList = new SelectList(_LocalSupplier.GetAllItemMaster(), "Identity", "ItemName");

                 mdLocalSupplier.RegionList = null;
                 mdLocalSupplier.RegionList = new SelectList(_LocalSupplier.GetAllRegions(), "Identity", "RegionName");

                 mdLocalSupplier.CountryList = null;
                 mdLocalSupplier.CountryList = new SelectList(_LocalSupplier.GetAllCountry(), "Identity", "CountryName");

                 mdLocalSupplier.StateList = null;
                 mdLocalSupplier.StateList = new SelectList(_LocalSupplier.GetAllStates(), "Identity", "StateName");

                 mdLocalSupplier.DistrictList = null;
                 mdLocalSupplier.DistrictList = new SelectList(_LocalSupplier.GetAllDistrict(), "Identity", "DistrictName");

                 mdLocalSupplier.LocationList = null;
                 mdLocalSupplier.LocationList = new SelectList(_LocalSupplier.GetAlllocations(), "Identity", "LocationName");



                TempData["PageInfo"] = "Add LocalSupplier Info";
                return PartialView(mdLocalSupplier);
            }
            else
            {
                Models.LocalSupplier mdLocalSupplier = AutoMapperConfig.Mapper().Map<Models.LocalSupplier>(_LocalSupplier.GetLocalSupplier(identity));

                mdLocalSupplier.ItemList = null;
                mdLocalSupplier.ItemList = new SelectList(_LocalSupplier.GetAllItemMaster(), "Identity", "ItemName", mdLocalSupplier.ItemID);

                mdLocalSupplier.RegionList = null;
                mdLocalSupplier.RegionList = new SelectList(_LocalSupplier.GetAllRegions(), "Identity", "RegionName", mdLocalSupplier.Location.District.State.Country.RegionID);

                mdLocalSupplier.CountryList = null;
                mdLocalSupplier.CountryList = new SelectList(_LocalSupplier.GetAllCountrysOnRegion(mdLocalSupplier.Location.District.State.Country.RegionID.ToString()), "Identity", "CountryName", mdLocalSupplier.Location.District.State.CountryID);

                mdLocalSupplier.StateList = null;
                mdLocalSupplier.StateList = new SelectList(_LocalSupplier.GetAllStatesOnCountry(mdLocalSupplier.Location.District.State.CountryID.ToString()), "Identity", "StateName", mdLocalSupplier.Location.District.StateID);

                mdLocalSupplier.DistrictList = null;
                mdLocalSupplier.DistrictList = new SelectList(_LocalSupplier.GetAllDistrictsOnState(mdLocalSupplier.Location.District.StateID.ToString()), "Identity", "DistrictName", mdLocalSupplier.Location.DistrictID);

                mdLocalSupplier.LocationList = null;
                mdLocalSupplier.LocationList = new SelectList(_LocalSupplier.GetAllLocationsOnDistrict(mdLocalSupplier.Location.DistrictID.ToString()), "Identity", "LocationName", mdLocalSupplier.LocationID);


                TempData["PageInfo"] = "Edit LocalSupplier Info";
                TempData.Keep();
                return PartialView(mdLocalSupplier);
            }
        }

        [HttpGet]
        public ActionResult _LocalSupplierCancel(int identity)
        {
            return RedirectToAction("_LocalSupplierAll");
        }

        [HttpPost]
        public JsonResult Country(string identity)
        {
            if (identity == "6")
                return Json(new SelectList(_LocalSupplier.GetAllCountry(), "Identity", "CountryName"));
            else
                return Json(new SelectList(_LocalSupplier.GetAllCountrysOnRegion(identity), "Identity", "CountryName"));
        }

        [HttpPost]
        public JsonResult State(string identity)
        {

            return Json(new SelectList(_LocalSupplier.GetAllStatesOnCountry(identity), "Identity", "StateName"));
        }

        [HttpPost]
        public JsonResult District(string identity)
        {

            return Json(new SelectList(_LocalSupplier.GetAllDistrictsOnState(identity), "Identity", "DistrictName"));
        }

        [HttpPost]
        public JsonResult Location(string identity)
        {

            return Json(new SelectList(_LocalSupplier.GetAllLocationsOnDistrict(identity), "Identity", "LocationName"));
        }

        [HttpGet]
        public PartialViewResult _LocalSupplierView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.LocalSupplier>(_LocalSupplier.GetLocalSupplier(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _LocalSupplier.Delete(identity);
            return RedirectToAction("_LocalSupplierAll");
        }

        [HttpPost]
        public ActionResult Update(Models.LocalSupplier LocalSupplier, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.LocalSupplier mdLocal = AutoMapperConfig.Mapper().Map<BusinessModels.LocalSupplier>(LocalSupplier);

            var locvalue = frmFields["hdnLocation"];

            if (!String.IsNullOrEmpty(locvalue))
                mdLocal.LocationID = int.Parse(locvalue);

            var itemvalue = frmFields["hdnItemMaster"];

            if (!String.IsNullOrEmpty(itemvalue))
                mdLocal.ItemID = int.Parse(itemvalue);

            if (LocalSupplier.Identity.Equals(-1))
            {
                mdLocal.CreatedDate = DateTime.Now;
                _LocalSupplier.Insert(mdLocal);
            }
            else
            {
                mdLocal.ModifiedDate = DateTime.Now;
                _LocalSupplier.Update(mdLocal);
            }
            return RedirectToAction("_LocalSupplierAll");
        }

        [HttpPost]
        public PartialViewResult LocalSupplierSearch(string searchString, string createdDate = "")
        {
            return PartialView("_LocalSupplierAll", GetLocalSuppliers("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_LocalSupplierAll", GetLocalSuppliers(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.LocalSupplier> GetLocalSuppliers(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "SupplierName" : "";

            var LocalSuppliers = AutoMapperConfig.Mapper().Map<List<Models.LocalSupplier>>(_LocalSupplier.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                LocalSuppliers = AutoMapperConfig.Mapper().Map<List<Models.LocalSupplier>>(_LocalSupplier.GetAll().ToList().FindAll(p => p.SupplierName.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                LocalSuppliers = AutoMapperConfig.Mapper().Map<List<Models.LocalSupplier>>(_LocalSupplier.GetAll().ToList().FindAll(p => p.SupplierName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                LocalSuppliers = AutoMapperConfig.Mapper().Map<List<Models.LocalSupplier>>(_LocalSupplier.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "SupplierName":
                    LocalSuppliers = LocalSuppliers.OrderByDescending(stu => stu.SupplierName).ToList();
                    break;
                case "DateAsc":
                    LocalSuppliers = LocalSuppliers.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    LocalSuppliers = LocalSuppliers.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    LocalSuppliers = LocalSuppliers.OrderBy(stu => stu.SupplierName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return LocalSuppliers.ToPagedList(No_Of_Page, Size_Of_Page);
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
