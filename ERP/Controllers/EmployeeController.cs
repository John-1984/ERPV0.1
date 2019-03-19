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
    public class EmployeeController : Controller
    {
        private BusinessLayer.Employee _Employee = new BusinessLayer.Employee();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _EmployeeAll()
        {
            return PartialView(GetEmployees("", 1, "", ""));
        }
        [HttpGet]
        public ActionResult _EmployeeCancel(int identity)
        {
            return RedirectToAction("_EmployeeAll");
        }

        [HttpPost]
        public JsonResult Country(string identity)
        {
            if (identity == "6")
                return Json(new SelectList(_Employee.GetAllCountry(), "Identity", "CountryName"));
            else
                return Json(new SelectList(_Employee.GetAllCountrysOnRegion(identity), "Identity", "CountryName"));
        }

        [HttpPost]
        public JsonResult State(string identity)
        {

            return Json(new SelectList(_Employee.GetAllStatesOnCountry(identity), "Identity", "StateName"));
        }

        [HttpPost]
        public JsonResult District(string identity)
        {

            return Json(new SelectList(_Employee.GetAllDistrictsOnState(identity), "Identity", "DistrictName"));
        }
        [HttpPost]
        public JsonResult Location(string identity)
        {

            return Json(new SelectList(_Employee.GetAllLocationsOnDistrict(identity), "Identity", "LocationName"));
        }

        [HttpPost]
        public JsonResult Company(string identity)
        {

            return Json(new SelectList(_Employee.GetAllCompaniesonLocation(identity), "Identity", "CompanyName"));
        }

        [HttpPost]
        public JsonResult CompanyType(string identity)
        {

            return Json(new SelectList(_Employee.GetAllCompaniesTypeonCompany(identity), "Identity", "TypeName"));
        }
        [HttpPost]
        public JsonResult FloorMaster(string identity)
        {

            return Json(new SelectList(_Employee.GetAllFloorOnCompanyType(identity), "Identity", "FloorName"));
        }
        [HttpGet]
        public PartialViewResult _EmployeeEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.Employee mdEmployee = new Models.Employee();

                mdEmployee.RegionList = null;
                mdEmployee.RegionList = new SelectList(_Employee.GetAllRegions(), "Identity", "RegionName");

                mdEmployee.CountryList = null;
                mdEmployee.CountryList = new SelectList(_Employee.GetAllCountry(), "Identity", "CountryName");

                mdEmployee.StateList = null;
                mdEmployee.StateList = new SelectList(_Employee.GetAllStates(), "Identity", "StateName");

                mdEmployee.DistrictList = null;
                mdEmployee.DistrictList = new SelectList(_Employee.GetAllDistrict(), "Identity", "DistrictName");

                mdEmployee.LocationList = null;
                mdEmployee.LocationList = new SelectList(_Employee.GetAllLocations(), "Identity", "LocationName");

                mdEmployee.CompanyList = null;
                mdEmployee.CompanyList = new SelectList(_Employee.GetAllCompanies(), "Identity", "CompanyName");

                mdEmployee.CompanyTypeList = null;
                mdEmployee.CompanyTypeList = new SelectList(_Employee.GetAllCompanyType(), "Identity", "TypeName");

                mdEmployee.IdentificationList = null;
                mdEmployee.IdentificationList = new SelectList(_Employee.GetAllIdentificationTypes(), "Identity", "IdentificationName");               

                mdEmployee.RoleList = null;
                mdEmployee.RoleList = new SelectList(_Employee.GetAllRoles(), "Identity", "RoleName");

                mdEmployee.FloorMasterList = null;
                mdEmployee.FloorMasterList = new SelectList(_Employee.GetAllFloors(), "Identity", "FloorName");

                TempData["PageInfo"] = "Add Employee Info";
                return PartialView(mdEmployee);
            }
            else
            {
                Models.Employee mdEmployee = AutoMapperConfig.Mapper().Map<Models.Employee>(_Employee.GetEmployee(identity));

               mdEmployee.RegionList = null;
               mdEmployee.RegionList = new SelectList(_Employee.GetAllRegions(), "Identity", "RegionName",mdEmployee.CompanyType.Company.Location.District.State.Country.Region.Identity);

               mdEmployee.CountryList = null;
               mdEmployee.CountryList = new SelectList(_Employee.GetAllCountrysOnRegion(mdEmployee.CompanyType.Company.Location.District.State.Country.RegionID.ToString()), "Identity", "CountryName",mdEmployee.CompanyType.Company.Location.District.State.CountryID);

               mdEmployee.StateList = null;
               mdEmployee.StateList = new SelectList(_Employee.GetAllStatesOnCountry(mdEmployee.CompanyType.Company.Location.District.State.CountryID.ToString()), "Identity", "StateName",mdEmployee.CompanyType.Company.Location.District.StateID);

               mdEmployee.DistrictList = null;
               mdEmployee.DistrictList = new SelectList(_Employee.GetAllDistrictsOnState(mdEmployee.CompanyType.Company.Location.District.StateID.ToString()), "Identity", "DistrictName",mdEmployee.CompanyType.Company.Location.DistrictID);

               mdEmployee.LocationList = null;
               mdEmployee.LocationList = new SelectList(_Employee.GetAllLocationsOnDistrict(mdEmployee.CompanyType.Company.Location.DistrictID.ToString()), "Identity", "LocationName",mdEmployee.CompanyType.Company.LocationID);

               mdEmployee.CompanyList = null;
               mdEmployee.CompanyList = new SelectList(_Employee.GetAllCompaniesonLocation(mdEmployee.CompanyType.Company.LocationID.ToString()), "Identity", "CompanyName",mdEmployee.CompanyType.CompanyID);


               mdEmployee.CompanyTypeList = null;
               mdEmployee.CompanyTypeList = new SelectList(_Employee.GetAllCompaniesTypeonCompany(mdEmployee.CompanyType.CompanyID.ToString()), "Identity", "TypeName",mdEmployee.CompanyTypeID);

                mdEmployee.FloorMasterList = null;
                mdEmployee.FloorMasterList = new SelectList(_Employee.GetAllFloorOnCompanyType(mdEmployee.CompanyTypeID.ToString()), "Identity", "FloorName", mdEmployee.FloorMasterID);

                mdEmployee.IdentificationList = null;
                mdEmployee.IdentificationList = new SelectList(_Employee.GetAllIdentificationTypes(), "Identity", "IdentificationName", mdEmployee.IdentificationID);             

                mdEmployee.RoleList = null;
                mdEmployee.RoleList = new SelectList(_Employee.GetAllRoles(), "Identity", "RoleName", mdEmployee.RoleMasterID);

                TempData["PageInfo"] = "Edit Employee Info";
                TempData.Keep();
                return PartialView(mdEmployee);
            }
        }

        [HttpGet]
        public PartialViewResult _EmployeeView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Employee>(_Employee.GetEmployee(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            BusinessModels.Employee mdEmployee = _Employee.GetEmployee(identity);
            mdEmployee.IsActive = false;
            _Employee.Update(mdEmployee);
            return RedirectToAction("_EmployeeAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Employee Employee, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.Employee mdemployee = AutoMapperConfig.Mapper().Map<BusinessModels.Employee>(Employee);

            var rolevalue = frmFields["hdnRoleMaster"];
            if (!String.IsNullOrEmpty(rolevalue))
                mdemployee.RoleMasterID = int.Parse(rolevalue);

            var locvalue = frmFields["hdnLocation"];
            if (!String.IsNullOrEmpty(locvalue))
            {
                if(locvalue!="0")
                mdemployee.LocationID = int.Parse(locvalue);
                else
                mdemployee.LocationID = null;
            }

            var compvalue = frmFields["hdnCompany"];
            if (!String.IsNullOrEmpty(compvalue))
            {
                mdemployee.CompanyID = int.Parse(compvalue);

                if (compvalue != "0")
                    mdemployee.CompanyID = int.Parse(compvalue);
                else
                    mdemployee.CompanyID = null;
            }

            var companytypevalue = frmFields["hdnCompanyType"];
            if (!String.IsNullOrEmpty(companytypevalue))
            {
                if (companytypevalue != "0")
                    mdemployee.CompanyTypeID = int.Parse(companytypevalue);
                else
                    mdemployee.CompanyTypeID = null;

            }

            var floorvalue = frmFields["hdnFloorMaster"];
            if (!String.IsNullOrEmpty(floorvalue))
            {
                if (floorvalue != "0")
                    mdemployee.FloorMasterID = int.Parse(floorvalue);
                else
                    mdemployee.FloorMasterID = null;
            }

            var identificationrvalue = frmFields["hdnempidentification"];
            if (!String.IsNullOrEmpty(identificationrvalue))
            {
                if (identificationrvalue != "0")
                    mdemployee.IdentificationID = int.Parse(identificationrvalue);
                else
                    mdemployee.IdentificationID = null;
            }
            mdemployee.IsActive = true;
            if (Employee.Identity.Equals(-1))
            {
                mdemployee.CreatedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
                mdemployee.CreatedDate = DateTime.Now;
              
                _Employee.Insert(mdemployee);
            }
            else
            {
                mdemployee.ModifiedDate = DateTime.Now;
                mdemployee.ModifiedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
                _Employee.Update(mdemployee);
            }
            return RedirectToAction("_EmployeeAll");
        }

        [HttpPost]
        public PartialViewResult EmployeeSearch(string searchString, string createdDate = "")
        {
            return PartialView("_EmployeeAll", GetEmployees("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_EmployeeAll", GetEmployees(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Employee> GetEmployees(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "EmployeeName" : "";

            var Employees = AutoMapperConfig.Mapper().Map<List<Models.Employee>>(_Employee.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                Employees = AutoMapperConfig.Mapper().Map<List<Models.Employee>>(_Employee.GetAll().ToList().FindAll(p => p.EmployeeName.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                Employees = AutoMapperConfig.Mapper().Map<List<Models.Employee>>(_Employee.GetAll().ToList().FindAll(p => p.EmployeeName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                Employees = AutoMapperConfig.Mapper().Map<List<Models.Employee>>(_Employee.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "EmployeeName":
                    Employees = Employees.OrderByDescending(stu => stu.EmployeeName).ToList();
                    break;
                case "DateAsc":
                    Employees = Employees.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    Employees = Employees.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    Employees = Employees.OrderBy(stu => stu.EmployeeName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return Employees.ToPagedList(No_Of_Page, Size_Of_Page);
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
