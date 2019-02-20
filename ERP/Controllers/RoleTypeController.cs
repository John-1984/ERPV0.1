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
    public class RoleTypeController : Controller
    {
        private BusinessLayer.RoleType _RoleType = new BusinessLayer.RoleType();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _RoleTypeAll()
        {
            return PartialView(GetRoleTypes("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _RoleTypeEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.RoleType());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.RoleType>(_RoleType.GetRoleType(identity)));
        }

        [HttpGet]
        public PartialViewResult _RoleTypeView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.RoleType>(_RoleType.GetRoleType(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _RoleType.Delete(identity);
            return RedirectToAction("_RoleTypeAll");
        }

        [HttpPost]
        public ActionResult Update(Models.RoleType RoleType)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (RoleType.Identity.Equals(-1))
            {
                _RoleType.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.RoleType>(RoleType));
            }
            else
                _RoleType.Update(AutoMapperConfig.Mapper().Map<BusinessModels.RoleType>(RoleType));
            return RedirectToAction("_RoleTypeAll");
        }

        [HttpPost]
        public PartialViewResult RoleTypeSearch(string searchString, string createdDate = "")
        {
            return PartialView("_RoleTypeAll", GetRoleTypes("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_RoleTypeAll", GetRoleTypes(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.RoleType> GetRoleTypes(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "RoletypeName" : "";

            var RoleTypes = AutoMapperConfig.Mapper().Map<List<Models.RoleType>>(_RoleType.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                RoleTypes = AutoMapperConfig.Mapper().Map<List<Models.RoleType>>(_RoleType.GetAll().ToList().FindAll(p => p.RoletypeName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                RoleTypes = AutoMapperConfig.Mapper().Map<List<Models.RoleType>>(_RoleType.GetAll().ToList().FindAll(p => p.RoletypeName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                RoleTypes = AutoMapperConfig.Mapper().Map<List<Models.RoleType>>(_RoleType.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "RoletypeName":
                    RoleTypes = RoleTypes.OrderByDescending(stu => stu.RoletypeName).ToList();
                    break;
                case "DateAsc":
                    RoleTypes = RoleTypes.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    RoleTypes = RoleTypes.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    RoleTypes = RoleTypes.OrderBy(stu => stu.RoletypeName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return RoleTypes.ToPagedList(No_Of_Page, Size_Of_Page);
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