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
    public class UOMMasterController : Controller
    {
        private BusinessLayer.UOMMaster _UOMMaster = new BusinessLayer.UOMMaster();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _UOMMasterAll()
        {
            return PartialView(GetUOMMasters("", 1, "", ""));
        }

        [HttpGet]
        public ActionResult _UOMMasterCancel(int identity)
        {
            return RedirectToAction("_UOMMasterAll");
        }

        [HttpGet]
        public PartialViewResult _UOMMasterEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.UOMMaster());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.UOMMaster>(_UOMMaster.GetUOMMaster(identity)));
        }

        [HttpGet]
        public PartialViewResult _UOMMasterView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.UOMMaster>(_UOMMaster.GetUOMMaster(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _UOMMaster.Delete(identity);
            return RedirectToAction("_UOMMasterAll");
        }

        [HttpPost]
        public ActionResult Update(Models.UOMMaster UOMMaster)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.UOMMaster mdUom = AutoMapperConfig.Mapper().Map<BusinessModels.UOMMaster>(UOMMaster);
            if (UOMMaster.Identity.Equals(-1))
            {
                mdUom.CreatedDate = DateTime.Now;
                _UOMMaster.Insert(mdUom);
            }
            else
            {
                mdUom.ModifiedDate = DateTime.Now;
                _UOMMaster.Update(mdUom);
            }
            return RedirectToAction("_UOMMasterAll");
        }

        [HttpPost]
        public PartialViewResult UOMMasterSearch(string searchString, string createdDate = "")
        {
            return PartialView("_UOMMasterAll", GetUOMMasters("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_UOMMasterAll", GetUOMMasters(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.UOMMaster> GetUOMMasters(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "UOMName" : "";

            var UOMMasters = AutoMapperConfig.Mapper().Map<List<Models.UOMMaster>>(_UOMMaster.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                UOMMasters = AutoMapperConfig.Mapper().Map<List<Models.UOMMaster>>(_UOMMaster.GetAll().ToList().FindAll(p => p.UOMName.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                UOMMasters = AutoMapperConfig.Mapper().Map<List<Models.UOMMaster>>(_UOMMaster.GetAll().ToList().FindAll(p => p.UOMName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                UOMMasters = AutoMapperConfig.Mapper().Map<List<Models.UOMMaster>>(_UOMMaster.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "UOMName":
                    UOMMasters = UOMMasters.OrderByDescending(stu => stu.UOMName).ToList();
                    break;
                case "DateAsc":
                    UOMMasters = UOMMasters.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    UOMMasters = UOMMasters.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    UOMMasters = UOMMasters.OrderBy(stu => stu.UOMName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return UOMMasters.ToPagedList(No_Of_Page, Size_Of_Page);
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
