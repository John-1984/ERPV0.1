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
    public class StateController : Controller
    {
        private BusinessLayer.State _State = new BusinessLayer.State();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _StateAll()
        {
            return PartialView(GetStates("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _StateEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.State mdState = new Models.State();
                mdState.RegionList = null;
                mdState.RegionList = new SelectList(_State.GetAllRegionss(), "Identity", "RegionName");

                mdState.CountryList = null;
                mdState.CountryList = new SelectList(_State.GetAllCountrys(), "Identity", "CountryName");

                TempData["PageInfo"] = "Add State Info";
                return PartialView(mdState);
            }
            else
            {
                Models.State mdState = AutoMapperConfig.Mapper().Map<Models.State>(_State.GetState(identity));

                mdState.CountryList = null;
                mdState.CountryList = new SelectList(_State.GetAllCountrys(mdState.Country.RegionID.ToString()), "Identity", "CountryName", mdState.CountryID);

                mdState.RegionList = null;
                mdState.RegionList = new SelectList(_State.GetAllRegionss(), "Identity", "RegionName",mdState.Country.RegionID);

               
                TempData["PageInfo"] = "Edit State Info";
                TempData.Keep();
                return PartialView(mdState);
            }
        }

        [HttpPost]
        public JsonResult Country(string identity)
        {
            if(identity=="6")
                return Json(new SelectList(_State.GetAllCountrys(), "Identity", "CountryName"));
            else
            return Json(new SelectList(_State.GetAllCountrys(identity), "Identity", "CountryName"));
        }

        [HttpGet]
        public PartialViewResult _StateView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.State>(_State.GetState(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _State.Delete(identity);
            return RedirectToAction("_StateAll");
        }

        [HttpGet]
        public ActionResult _StateCancel(int identity)
        {
            return RedirectToAction("_StateAll");
        }

        [HttpPost]
        public ActionResult Update(Models.State State, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.State mdState = AutoMapperConfig.Mapper().Map<BusinessModels.State>(State);
            var regvalue = frmFields["hdnRegion"];
            var convalue = frmFields["hdnCountry"];

            if (!String.IsNullOrEmpty(convalue))
                mdState.CountryID = int.Parse(convalue);

            if (State.Identity.Equals(-1))
            {
                _State.Insert(mdState);
            }
            else
            {
               
                _State.Update(mdState);
            }
            return RedirectToAction("_StateAll");
        }

        [HttpPost]
        public PartialViewResult StateSearch(string searchString, string createdDate = "")
        {
            return PartialView("_StateAll", GetStates("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_StateAll", GetStates(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.State> GetStates(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "StateName" : "";

            var States = AutoMapperConfig.Mapper().Map<List<Models.State>>(_State.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                States = AutoMapperConfig.Mapper().Map<List<Models.State>>(_State.GetAll().ToList().FindAll(p => p.StateName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                States = AutoMapperConfig.Mapper().Map<List<Models.State>>(_State.GetAll().ToList().FindAll(p => p.StateName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                States = AutoMapperConfig.Mapper().Map<List<Models.State>>(_State.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "StateName":
                    States = States.OrderByDescending(stu => stu.StateName).ToList();
                    break;
                case "DateAsc":
                    States = States.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    States = States.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    States = States.OrderBy(stu => stu.StateName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return States.ToPagedList(No_Of_Page, Size_Of_Page);
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
