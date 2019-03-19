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
    public class RegionController : Controller
    {
        private BusinessLayer.Region _Region = new BusinessLayer.Region();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _RegionAll()
        {
            return PartialView(GetRegions("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _RegionEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.Region());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Region>(_Region.GetRegion(identity)));
        }

        [HttpGet]
        public PartialViewResult _RegionView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Region>(_Region.GetRegion(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            BusinessModels.Region regDet=  _Region.GetRegion(identity);
            regDet.IsActive = false;
            _Region.Update(regDet);
            return RedirectToAction("_RegionAll", regDet);
        }

        [HttpPost]
        public ActionResult Update(Models.Region Region)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.Region mdRegion = AutoMapperConfig.Mapper().Map<BusinessModels.Region>(Region);
            mdRegion.IsActive = true;
            if (Region.Identity.Equals(-1))
            {
                mdRegion.CreatedDate = DateTime.Now;
                
                _Region.Insert(mdRegion);
            }
            else
            {
                mdRegion.ModifiedDate = DateTime.Now;
                _Region.Update(mdRegion);
            } 
            return RedirectToAction("_RegionAll", GetRegions("", 1, "", ""));
        }


        [HttpGet]
        public ActionResult _RegionCancel(int identity)
        {
            return RedirectToAction("_RegionAll", GetRegions("", 1, "", ""));
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

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var regionss = _Region.GetMatchingRegions(prefix);

            return Json(regionss);
        }

        private IPagedList<Models.Region> GetRegions(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "RegionName" : "";

            var Regions = AutoMapperConfig.Mapper().Map<List<Models.Region>>(_Region.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                Regions = AutoMapperConfig.Mapper().Map<List<Models.Region>>(Regions.ToList().FindAll(p => p.RegionName.ToLower().Contains(searchString.ToLower()) && Convert.ToDateTime(p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                Regions = AutoMapperConfig.Mapper().Map<List<Models.Region>>(Regions.ToList().FindAll(p => p.RegionName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                Regions = AutoMapperConfig.Mapper().Map<List<Models.Region>>(Regions.ToList().FindAll(p => Convert.ToDateTime(p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

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
