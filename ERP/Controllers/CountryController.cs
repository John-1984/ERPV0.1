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
    public class CountryController : Controller
    {
        private BusinessLayer.Country _Country = new BusinessLayer.Country();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _CountryAll()
        {
            return PartialView(GetCountrys("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _CountryEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.Country mdCountry = new Models.Country();
                mdCountry.RegionList = null;
                mdCountry.RegionList = new SelectList(_Country.GetAllRegions(), "Identity", "RegionName");
                TempData["PageInfo"] = "Add Country Info";
                return PartialView(mdCountry);
            }
            else
            {
                Models.Country mdCountry = AutoMapperConfig.Mapper().Map<Models.Country>(_Country.GetCountry(identity));
                mdCountry.RegionList = null;
                mdCountry.RegionList = new SelectList(_Country.GetAllRegions(), "Identity", "RegionName", mdCountry.RegionID);
                TempData["PageInfo"] = "Edit Country Info";
                TempData.Keep();
                return PartialView(mdCountry);
            }
        }

        [HttpGet]
        public ActionResult _CountryCancel(int identity)
        {
            return RedirectToAction("_CountryAll");
        }

        [HttpGet]
        public PartialViewResult _CountryView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Country>(_Country.GetCountry(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Country.Delete(identity);
            return RedirectToAction("_CountryAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Country Country,FormCollection frmCountry)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.Country con = AutoMapperConfig.Mapper().Map<BusinessModels.Country>(Country);

            var value = frmCountry["hdnRegion"];

            if (!String.IsNullOrEmpty(value))
                con.RegionID = int.Parse(value);

            //   string SelectedValue = Country.SelectedRegion.ToString();

            if (Country.Identity.Equals(-1))
            {
                con.CreatedDate = DateTime.Now;
                _Country.Insert(con);
            }
            else
            {
                
                con.ModifiedDate = DateTime.Now;  
                _Country.Update(con);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public PartialViewResult CountrySearch(string searchString, string createdDate = "")
        {
            return PartialView("_CountryAll", GetCountrys("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_CountryAll", GetCountrys(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Country> GetCountrys(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "CountryName" : "";

            var Countrys = AutoMapperConfig.Mapper().Map<List<Models.Country>>(_Country.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                Countrys = AutoMapperConfig.Mapper().Map<List<Models.Country>>(_Country.GetAll().ToList().FindAll(p => p.CountryName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                Countrys = AutoMapperConfig.Mapper().Map<List<Models.Country>>(_Country.GetAll().ToList().FindAll(p => p.CountryName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                Countrys = AutoMapperConfig.Mapper().Map<List<Models.Country>>(_Country.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "CountryName":
                    Countrys = Countrys.OrderByDescending(stu => stu.CountryName).ToList();
                    break;
                case "DateAsc":
                    Countrys = Countrys.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    Countrys = Countrys.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    Countrys = Countrys.OrderBy(stu => stu.CountryName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return Countrys.ToPagedList(No_Of_Page, Size_Of_Page);
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
