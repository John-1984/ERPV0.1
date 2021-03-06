﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;
using System.Runtime;
using System.Globalization;

namespace ERP.Controllers
{
    public class LocationController : Controller
    {
        private BusinessLayer.Location _Location = new BusinessLayer.Location();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _LocationAll()
        {
            return PartialView(GetLocations("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _LocationEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.Location mdLocation = new Models.Location();
                mdLocation.RegionList = null;
                mdLocation.RegionList = new SelectList(_Location.GetAllRegionss(), "Identity", "RegionName");

                mdLocation.CountryList = null;
                mdLocation.CountryList = new SelectList(_Location.GetAllCountrys(), "Identity", "CountryName");

                mdLocation.StateList = null;
                mdLocation.StateList = new SelectList(_Location.GetAllStates(), "Identity", "StateName");

                mdLocation.DistrictList = null;
                mdLocation.DistrictList = new SelectList(_Location.GetAllDistrict(), "Identity", "DistrictName");

                TempData["PageInfo"] = "Add Location Info";
                return PartialView(mdLocation);
            }
            else
            {
                Models.Location mdLocation = AutoMapperConfig.Mapper().Map<Models.Location>(_Location.GetLocation(identity));
                mdLocation.RegionList = null;
                mdLocation.RegionList = new SelectList(_Location.GetAllRegionss(), "Identity", "RegionName", mdLocation.District.State.Country.RegionID);

                mdLocation.CountryList = null;
                mdLocation.CountryList = new SelectList(_Location.GetAllCountrys(mdLocation.District.State.Country.RegionID.ToString()), "Identity", "CountryName", mdLocation.District.State.CountryID);

                mdLocation.StateList = null;
                mdLocation.StateList = new SelectList(_Location.GetAllStates(mdLocation.District.State.CountryID.ToString()), "Identity", "StateName", mdLocation.District.StateID);

                mdLocation.DistrictList = null;
                mdLocation.DistrictList = new SelectList(_Location.GetAllDistricts(mdLocation.District.StateID.ToString()), "Identity", "DistrictName",mdLocation.DistrictID);

                TempData["PageInfo"] = "Edit Location Info";
                TempData.Keep();
                return PartialView(mdLocation);
            }
        }

        [HttpGet]
        public ActionResult _LocationCancel(int identity)
        {
            return RedirectToAction("_LocationAll");
        }

        [HttpPost]
        public JsonResult Country(string identity)
        {
            if (identity == "6")
                return Json(new SelectList(_Location.GetAllCountrys(), "Identity", "CountryName"));
            else
                return Json(new SelectList(_Location.GetAllCountrys(identity), "Identity", "CountryName"));
        }

        [HttpPost]
        public JsonResult State(string identity)
        {

            return Json(new SelectList(_Location.GetAllStates(identity), "Identity", "StateName"));
        }

        [HttpPost]
        public JsonResult District(string identity)
        {

            return Json(new SelectList(_Location.GetAllDistricts(identity), "Identity", "DistrictName"));
        }

        [HttpGet]
        public PartialViewResult _LocationView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Location>(_Location.GetLocation(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Location.Delete(identity);
            return RedirectToAction("_LocationAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Location Location, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value

            BusinessModels.Location mdLocation = AutoMapperConfig.Mapper().Map<BusinessModels.Location>(Location);
            var regvalue = frmFields["hdnRegion"];
            var districtvalue = frmFields["hdnDistrict"];

            if(!String.IsNullOrEmpty(districtvalue))
                mdLocation.DistrictID = int.Parse(districtvalue);

            if (Location.Identity.Equals(-1))
            {
                mdLocation.CreatedDate = DateTime.Now;
                _Location.Insert(mdLocation);
            }
            else
            {
                mdLocation.ModifiedDate = DateTime.Now;
                _Location.Update(mdLocation);
            }
            return RedirectToAction("_LocationAll");
        }

        [HttpPost]
        public PartialViewResult LocationSearch(string searchString, string createdDate = "")
        {
            return PartialView("_LocationAll", GetLocations("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_LocationAll", GetLocations(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Location> GetLocations(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "LocationName" : "";

            var Locations = AutoMapperConfig.Mapper().Map<List<Models.Location>>(_Location.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                Locations = AutoMapperConfig.Mapper().Map<List<Models.Location>>(_Location.GetAll().ToList().FindAll(p => p.LocationName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                Locations = AutoMapperConfig.Mapper().Map<List<Models.Location>>(_Location.GetAll().ToList().FindAll(p => p.LocationName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                Locations = AutoMapperConfig.Mapper().Map<List<Models.Location>>(_Location.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "LocationName":
                    Locations = Locations.OrderByDescending(stu => stu.LocationName).ToList();
                    break;
                case "DateAsc":
                    Locations = Locations.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    Locations = Locations.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    Locations = Locations.OrderBy(stu => stu.LocationName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return Locations.ToPagedList(No_Of_Page, Size_Of_Page);
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
