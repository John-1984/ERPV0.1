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
    public class DistrictController : Controller
    {
        private BusinessLayer.District _District = new BusinessLayer.District();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _DistrictAll()
        {
            return PartialView(GetDistricts("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _DistrictEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.District mdDistrict = new Models.District();
                mdDistrict.RegionList = null;
                mdDistrict.RegionList = new SelectList(_District.GetAllRegionss(), "Identity", "RegionName");

                mdDistrict.CountryList = null;
                mdDistrict.CountryList = new SelectList(_District.GetAllCountrys(), "Identity", "CountryName");

                mdDistrict.StateList = null;
                mdDistrict.StateList = new SelectList(_District.GetAllState(), "Identity", "StateName");

                TempData["PageInfo"] = "Add District Info";
                return PartialView(mdDistrict);
            }
            else
            {
                Models.District mdDistrict = AutoMapperConfig.Mapper().Map<Models.District>(_District.GetDistrict(identity));
                mdDistrict.RegionList = null;
                mdDistrict.RegionList = new SelectList(_District.GetAllRegionss(), "Identity", "RegionName", mdDistrict.State.Country.RegionID);

                mdDistrict.CountryList = null;
                mdDistrict.CountryList = new SelectList(_District.GetAllCountrys(mdDistrict.State.Country.RegionID.ToString()), "Identity", "CountryName", mdDistrict.State.CountryID);

                mdDistrict.StateList = null;
                mdDistrict.StateList = new SelectList(_District.GetAllStates(mdDistrict.State.CountryID.ToString()), "Identity", "StateName", mdDistrict.StateID);

               

                TempData["PageInfo"] = "Edit District Info";
                TempData.Keep();
                return PartialView(mdDistrict);
            }
        }

        [HttpGet]
        public PartialViewResult _DistrictView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.District>(_District.GetDistrict(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _District.Delete(identity);
            return RedirectToAction("_DistrictAll");
        }

        [HttpGet]
        public ActionResult _DistrictCancel(int identity)
        {
            return RedirectToAction("_DistrictAll");
        }

        [HttpPost]
        public JsonResult Country(string identity)
        {
            if (identity == "6")
                return Json(new SelectList(_District.GetAllCountrys(), "Identity", "CountryName"));
            else
                return Json(new SelectList(_District.GetAllCountrys(identity), "Identity", "CountryName"));
        }

        [HttpPost]
        public JsonResult State(string identity)
        {
          
                return Json(new SelectList(_District.GetAllStates(identity), "Identity", "StateName"));
        }

        [HttpPost]
        public ActionResult Update(Models.District District, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value

            BusinessModels.District mdDistrict = AutoMapperConfig.Mapper().Map<BusinessModels.District>(District);
            var regvalue = frmFields["hdnRegion"];
            var statevalue = frmFields["hdnState"];

            if (!String.IsNullOrEmpty(statevalue))
                mdDistrict.StateID= int.Parse(statevalue);

            if (District.Identity.Equals(-1))
            {

                mdDistrict.CreatedDate = DateTime.Now;
                _District.Insert(mdDistrict);
            }
            else
            {
                mdDistrict.ModifiedDate = DateTime.Now;
                _District.Update(mdDistrict);
            }


            return RedirectToAction("_DistrictAll");
        }

        [HttpPost]
        public PartialViewResult DistrictSearch(string searchString, string createdDate = "")
        {
            return PartialView("_DistrictAll", GetDistricts("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_DistrictAll", GetDistricts(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.District> GetDistricts(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "DistrictName" : "";

            var Districts = AutoMapperConfig.Mapper().Map<List<Models.District>>(_District.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                Districts = AutoMapperConfig.Mapper().Map<List<Models.District>>(_District.GetAll().ToList().FindAll(p => p.DistrictName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                Districts = AutoMapperConfig.Mapper().Map<List<Models.District>>(_District.GetAll().ToList().FindAll(p => p.DistrictName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                Districts = AutoMapperConfig.Mapper().Map<List<Models.District>>(_District.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "DistrictName":
                    Districts = Districts.OrderByDescending(stu => stu.DistrictName).ToList();
                    break;
                case "DateAsc":
                    Districts = Districts.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    Districts = Districts.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    Districts = Districts.OrderBy(stu => stu.DistrictName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return Districts.ToPagedList(No_Of_Page, Size_Of_Page);
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
