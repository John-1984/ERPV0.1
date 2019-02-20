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
    public class FloorMasterController : Controller
    {
        private BusinessLayer.FloorMaster _FloorMaster = new BusinessLayer.FloorMaster();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _FloorMasterAll()
        {
            return PartialView(GetFloorMasters("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _FloorMasterEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.FloorMaster mdFloorMaster = new Models.FloorMaster();
                mdFloorMaster.CompanyList = null;
                mdFloorMaster.CompanyList = new SelectList(_FloorMaster.GetAllCompanies(), "Identity", "CompanyName");

                mdFloorMaster.CompanyTypeList = null;
                mdFloorMaster.CompanyTypeList = new SelectList(_FloorMaster.GetAllCompanyTypes(), "Identity", "TypeName");

               

                TempData["PageInfo"] = "Add FloorMaster Info";
                return PartialView(mdFloorMaster);
            }
            else
            {
                Models.FloorMaster mdFloorMaster = AutoMapperConfig.Mapper().Map<Models.FloorMaster>(_FloorMaster.GetFloorMaster(identity));
                mdFloorMaster.CompanyList = null;
                mdFloorMaster.CompanyList = new SelectList(_FloorMaster.GetAllCompanies(), "Identity", "CompanyName");

                mdFloorMaster.CompanyTypeList = null;
                mdFloorMaster.CompanyTypeList = new SelectList(_FloorMaster.GetAllCompanyTypes(), "Identity", "TypeName");


                TempData["PageInfo"] = "Edit FloorMaster Info";
                TempData.Keep();
                return PartialView(mdFloorMaster);
            }
        }

        [HttpGet]
        public PartialViewResult _FloorMasterView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.FloorMaster>(_FloorMaster.GetFloorMaster(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _FloorMaster.Delete(identity);
            return RedirectToAction("_FloorMasterAll");
        }

        [HttpPost]
        public ActionResult Update(Models.FloorMaster FloorMaster)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (FloorMaster.Identity.Equals(-1))
            {
                _FloorMaster.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.FloorMaster>(FloorMaster));
            }
            else
                _FloorMaster.Update(AutoMapperConfig.Mapper().Map<BusinessModels.FloorMaster>(FloorMaster));
            return RedirectToAction("_FloorMasterAll");
        }

        [HttpPost]
        public PartialViewResult FloorMasterSearch(string searchString, string createdDate = "")
        {
            return PartialView("_FloorMasterAll", GetFloorMasters("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_FloorMasterAll", GetFloorMasters(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.FloorMaster> GetFloorMasters(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "CompanyName" : "";

            var FloorMasters = AutoMapperConfig.Mapper().Map<List<Models.FloorMaster>>(_FloorMaster.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                FloorMasters = AutoMapperConfig.Mapper().Map<List<Models.FloorMaster>>(_FloorMaster.GetAll().ToList().FindAll(p => p.CompanyName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                FloorMasters = AutoMapperConfig.Mapper().Map<List<Models.FloorMaster>>(_FloorMaster.GetAll().ToList().FindAll(p => p.CompanyName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                FloorMasters = AutoMapperConfig.Mapper().Map<List<Models.FloorMaster>>(_FloorMaster.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "CompanyName":
                    FloorMasters = FloorMasters.OrderByDescending(stu => stu.CompanyName).ToList();
                    break;
                case "DateAsc":
                    FloorMasters = FloorMasters.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    FloorMasters = FloorMasters.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    FloorMasters = FloorMasters.OrderBy(stu => stu.CompanyName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return FloorMasters.ToPagedList(No_Of_Page, Size_Of_Page);
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
