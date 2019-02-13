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
    public class RegionController : Controller
    {
        private BusinessLayer.Region _Region = new BusinessLayer.Region();

        public ActionResult Index()
        {
            TempData["PageInfo"] = "View Region Info";
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Update", "Region");
            }
            else
            {
                return View();
            }
            //}
        }

        public PartialViewResult _RegionAll()
        {
            return PartialView(GetRegions("", 1, "", ""));
        }

        public PartialViewResult _RegionEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                TempData["PageInfo"] = "Add Region Info";
                return PartialView(new Models.Region());
            }
            else
            {
                TempData["PageInfo"] = "Edit Region Info";
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Region>(_Region.GetRegion(identity)));
            }
        }

        public PartialViewResult _RegionView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Region>(_Region.GetRegion(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Region.Delete(identity);
            return RedirectToAction("_RegionAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Region Region)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (ModelState.IsValid)
            {
                if (Region.Identity.Equals(-1))
                {
                    Region.Identity = GetRandomNumber();
                    _Region.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Region>(Region));
                }
                else
                    _Region.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Region>(Region));
                return RedirectToAction("_RegionAll", Region);

            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();

                List<string> lstErrors = new List<string>();
                foreach (var error in errors)
                {
                    foreach (var er in error)
                    {
                        lstErrors.Add(((System.Web.Mvc.ModelError)er).ErrorMessage.ToString());
                       // ModelState.AddModelError(string.Empty, ((System.Web.Mvc.ModelError)er).ErrorMessage.ToString());
                    }
                }
                ViewData["ErrorData"] = lstErrors;
                Region.ErrorList = lstErrors;
                // return RedirectToAction("_RegionEdit", Region);
                return PartialView(Region);
            }
        }

        [HttpPost]
        public PartialViewResult RegionSearch(string searchString, string createdDate = "")
        {
            return PartialView("_RegionAll", GetRegions("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_RegionAll", GetRegions(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Region> GetRegions(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "RegionName" : "";

            var Regions = AutoMapperConfig.Mapper().Map<List<Models.Region>>(_Region.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                Regions = AutoMapperConfig.Mapper().Map<List<Models.Region>>(_Region.GetAll().ToList().FindAll(p => p.RegionName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                Regions = AutoMapperConfig.Mapper().Map<List<Models.Region>>(_Region.GetAll().ToList().FindAll(p => p.RegionName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                Regions = AutoMapperConfig.Mapper().Map<List<Models.Region>>(_Region.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "RegionName":
                    Regions = Regions.OrderByDescending(stu => stu.RegionName).ToList();
                    break;
                case "DateAsc":
                    Regions = Regions.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    Regions = Regions.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    Regions = Regions.OrderBy(stu => stu.RegionName).ToList();
                    break;
            }

            int Size_Of_Page = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return Regions.ToPagedList(No_Of_Page, Size_Of_Page);
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
