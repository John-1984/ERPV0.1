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
    public class IdentificationsTypeController : Controller
    {
        private BusinessLayer.IdentificationsType _IdentificationsType = new BusinessLayer.IdentificationsType();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _IdentificationsTypeAll()
        {
            return PartialView(GetIdentificationsTypes("", 1, "", ""));
        }

        [HttpGet]
        public ActionResult _IdentificationsTypeCancel(int identity)
        {
            return RedirectToAction("_IdentificationsTypeAll");
        }

        [HttpGet]
        public PartialViewResult _IdentificationsTypeEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.IdentificationsType());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.IdentificationsType>(_IdentificationsType.GetIdentificationsType(identity)));
        }

        [HttpGet]
        public PartialViewResult _IdentificationsTypeView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.IdentificationsType>(_IdentificationsType.GetIdentificationsType(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _IdentificationsType.Delete(identity);
            return RedirectToAction("_IdentificationsTypeAll");
        }

        [HttpPost]
        public ActionResult Update(Models.IdentificationsType identificationsType, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.IdentificationsType mdidentificaton = AutoMapperConfig.Mapper().Map<BusinessModels.IdentificationsType>(identificationsType);
            if (identificationsType.Identity.Equals(-1))
            {
                mdidentificaton.CreatedDate = DateTime.Now;
                _IdentificationsType.Insert(mdidentificaton);
            }
            else
            {
                mdidentificaton.ModifiedDate = DateTime.Now;
                _IdentificationsType.Update(mdidentificaton);
            }
            return RedirectToAction("_IdentificationsTypeAll");
        }

        [HttpPost]
        public PartialViewResult IdentificationsTypeSearch(string searchString, string createdDate = "")
        {
            return PartialView("_IdentificationsTypeAll", GetIdentificationsTypes("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_IdentificationsTypeAll", GetIdentificationsTypes(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.IdentificationsType> GetIdentificationsTypes(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "IdentificationName" : "";

            var IdentificationsTypes = AutoMapperConfig.Mapper().Map<List<Models.IdentificationsType>>(_IdentificationsType.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                IdentificationsTypes = AutoMapperConfig.Mapper().Map<List<Models.IdentificationsType>>(_IdentificationsType.GetAll().ToList().FindAll(p => p.IdentificationName.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                IdentificationsTypes = AutoMapperConfig.Mapper().Map<List<Models.IdentificationsType>>(_IdentificationsType.GetAll().ToList().FindAll(p => p.IdentificationName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                IdentificationsTypes = AutoMapperConfig.Mapper().Map<List<Models.IdentificationsType>>(_IdentificationsType.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "IdentificationName":
                    IdentificationsTypes = IdentificationsTypes.OrderByDescending(stu => stu.IdentificationName).ToList();
                    break;
                case "DateAsc":
                    IdentificationsTypes = IdentificationsTypes.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    IdentificationsTypes = IdentificationsTypes.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    IdentificationsTypes = IdentificationsTypes.OrderBy(stu => stu.IdentificationName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return IdentificationsTypes.ToPagedList(No_Of_Page, Size_Of_Page);
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
