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
    public class CompanyController : Controller
    {
        private BusinessLayer.Company _Company = new BusinessLayer.Company();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _CompanyAll()
        {
            return PartialView(GetCompanys("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _CompanyEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.Company mdCompany = new Models.Company();
                mdCompany.RegionList = null;
                mdCompany.RegionList = new SelectList(_Company.GetAllRegions(), "Identity", "RegionName");

                mdCompany.CountryList = null;
                mdCompany.CountryList = new SelectList(_Company.GetAllCountry(), "Identity", "CountryName");

                mdCompany.StateList = null;
                mdCompany.StateList = new SelectList(_Company.GetAllStates(), "Identity", "StateName");

                mdCompany.DistrictList = null;
                mdCompany.DistrictList = new SelectList(_Company.GetAllDistrict(), "Identity", "DistrictName");

                mdCompany.LocationList = null;
                mdCompany.LocationList = new SelectList(_Company.GetAllLocaton(), "Identity", "LocationName");

                mdCompany.CompanyTypeList = null;
                mdCompany.CompanyTypeList = new SelectList(_Company.GetAllCompanyType(), "Identity", "TypeName");

                TempData["PageInfo"] = "Add Company Info";
                return PartialView(mdCompany);
            }
            else
            {
                Models.Company mdCompany = AutoMapperConfig.Mapper().Map<Models.Company>(_Company.GetCompany(identity));
                mdCompany.RegionList = null;
                mdCompany.RegionList = new SelectList(_Company.GetAllRegions(), "Identity", "RegionName");

                mdCompany.CountryList = null;
                mdCompany.CountryList = new SelectList(_Company.GetAllCountry(), "Identity", "CountryName");

                mdCompany.StateList = null;
                mdCompany.StateList = new SelectList(_Company.GetAllStates(), "Identity", "StateName");

                mdCompany.DistrictList = null;
                mdCompany.DistrictList = new SelectList(_Company.GetAllDistrict(), "Identity", "DistrictName");

                mdCompany.LocationList = null;
                mdCompany.LocationList = new SelectList(_Company.GetAllLocaton(), "Identity", "LocationName");

                mdCompany.CompanyTypeList = null;
                mdCompany.CompanyTypeList = new SelectList(_Company.GetAllCompanyType(), "Identity", "TypeName");


                TempData["PageInfo"] = "Edit Company Info";
                TempData.Keep();
                return PartialView(mdCompany);
            }
        }

        [HttpGet]
        public PartialViewResult _CompanyView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Company>(_Company.GetCompany(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Company.Delete(identity);
            return RedirectToAction("_CompanyAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Company Company)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (Company.Identity.Equals(-1))
            {
                _Company.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Company>(Company));
            }
            else
                _Company.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Company>(Company));
            return RedirectToAction("_CompanyAll");
        }

        [HttpPost]
        public PartialViewResult CompanySearch(string searchString, string createdDate = "")
        {
            return PartialView("_CompanyAll", GetCompanys("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_CompanyAll", GetCompanys(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Company> GetCompanys(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "CompanyName" : "";

            var Companys = AutoMapperConfig.Mapper().Map<List<Models.Company>>(_Company.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                Companys = AutoMapperConfig.Mapper().Map<List<Models.Company>>(_Company.GetAll().ToList().FindAll(p => p.CompanyName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                Companys = AutoMapperConfig.Mapper().Map<List<Models.Company>>(_Company.GetAll().ToList().FindAll(p => p.CompanyName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                Companys = AutoMapperConfig.Mapper().Map<List<Models.Company>>(_Company.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "CompanyName":
                    Companys = Companys.OrderByDescending(stu => stu.CompanyName).ToList();
                    break;
                case "DateAsc":
                    Companys = Companys.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    Companys = Companys.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    Companys = Companys.OrderBy(stu => stu.CompanyName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return Companys.ToPagedList(No_Of_Page, Size_Of_Page);
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
