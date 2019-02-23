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
    public class RoleMasterController : Controller
    {
        private BusinessLayer.RoleMaster _RoleMaster = new BusinessLayer.RoleMaster();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _RoleMasterAll()
        {
            return PartialView(GetRoleMasters("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _RoleMasterEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.RoleMaster mdRoleMaster = new Models.RoleMaster();
                mdRoleMaster.RegionList = null;
                mdRoleMaster.RegionList = new SelectList(_RoleMaster.GetAllRegionss(), "Identity", "RegionName");

                mdRoleMaster.ModuleList = null;
                mdRoleMaster.ModuleList = new SelectList(_RoleMaster.GetAllModules(), "Identity", "ModuleName");

                mdRoleMaster.RoleTypeList = null;
                mdRoleMaster.RoleTypeList = new SelectList(_RoleMaster.GetAllRoleTypes(), "Identity", "RoleTypeName");

             

                TempData["PageInfo"] = "Add Role Master Info";
                return PartialView(mdRoleMaster);
            }
            else
            {
                Models.RoleMaster mdRoleMaster = AutoMapperConfig.Mapper().Map<Models.RoleMaster>(_RoleMaster.GetRoleMaster(identity));
               

                mdRoleMaster.RegionList = null;
                mdRoleMaster.RegionList = new SelectList(_RoleMaster.GetAllRegionss(), "Identity", "RegionName", mdRoleMaster.RegionID);

                mdRoleMaster.ModuleList = null;
                mdRoleMaster.ModuleList = new SelectList(_RoleMaster.GetAllModules(), "Identity", "ModuleName", mdRoleMaster.ModuleID);

                mdRoleMaster.RoleTypeList = null;
                mdRoleMaster.RoleTypeList = new SelectList(_RoleMaster.GetAllRoleTypes(), "Identity", "RoleTypeName", mdRoleMaster.RoleTypeID);

                TempData["PageInfo"] = "Edit Role Master Info";
                TempData.Keep();
                return PartialView(mdRoleMaster);
            }
        }

        [HttpGet]
        public PartialViewResult _RoleMasterView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.RoleMaster>(_RoleMaster.GetRoleMaster(identity)));
        }
        [HttpGet]
        public ActionResult _RoleMasterCancel(int identity)
        {
            return RedirectToAction("_RoleMasterAll");
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _RoleMaster.Delete(identity);
            return RedirectToAction("_RoleMasterAll");
        }

        [HttpPost]
        public ActionResult Update(Models.RoleMaster RoleMaster, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.RoleMaster mdRoleMaster= AutoMapperConfig.Mapper().Map<BusinessModels.RoleMaster>(RoleMaster);

            var roleTypevalue = frmFields["hdnRoleType"];
            if (!String.IsNullOrEmpty(roleTypevalue))
                mdRoleMaster.RoleTypeID = int.Parse(roleTypevalue);


            var modulevalue = frmFields["hdnModules"];
            if (!String.IsNullOrEmpty(modulevalue))
                mdRoleMaster.ModuleID = int.Parse(modulevalue);

            var regvalue = frmFields["hdnRegion"];
            if (!String.IsNullOrEmpty(regvalue))
                mdRoleMaster.RegionID = int.Parse(regvalue);


            if (RoleMaster.Identity.Equals(-1))
            {
                mdRoleMaster.CreatedDate = DateTime.Now;
                _RoleMaster.Insert(mdRoleMaster);
            }
            else
            {
                mdRoleMaster.ModifiedDate = DateTime.Now;
                _RoleMaster.Update(mdRoleMaster);
            }
            return RedirectToAction("_RoleMasterAll");
        }

        [HttpPost]
        public PartialViewResult RoleMasterSearch(string searchString, string createdDate = "")
        {
            return PartialView("_RoleMasterAll", GetRoleMasters("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_RoleMasterAll", GetRoleMasters(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.RoleMaster> GetRoleMasters(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "RoleName" : "";

            var RoleMasters = AutoMapperConfig.Mapper().Map<List<Models.RoleMaster>>(_RoleMaster.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                RoleMasters = AutoMapperConfig.Mapper().Map<List<Models.RoleMaster>>(_RoleMaster.GetAll().ToList().FindAll(p => p.RoleName.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                RoleMasters = AutoMapperConfig.Mapper().Map<List<Models.RoleMaster>>(_RoleMaster.GetAll().ToList().FindAll(p => p.RoleName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                RoleMasters = AutoMapperConfig.Mapper().Map<List<Models.RoleMaster>>(_RoleMaster.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "RoleName":
                    RoleMasters = RoleMasters.OrderByDescending(stu => stu.RoleName).ToList();
                    break;
                case "DateAsc":
                    RoleMasters = RoleMasters.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    RoleMasters = RoleMasters.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    RoleMasters = RoleMasters.OrderBy(stu => stu.RoleName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return RoleMasters.ToPagedList(No_Of_Page, Size_Of_Page);
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
