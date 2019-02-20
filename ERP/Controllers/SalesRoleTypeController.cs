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
    public class SalesRoleTypeController : Controller
    {
        private BusinessLayer.SalesRoleType _SalesRoleType = new BusinessLayer.SalesRoleType();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _SalesRoleTypeAll()
        {
            return PartialView(GetSalesRoleTypes("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _SalesRoleTypeEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.SalesRoleType());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.SalesRoleType>(_SalesRoleType.GetSalesRoleType(identity)));
        }

        [HttpGet]
        public PartialViewResult _SalesRoleTypeView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.SalesRoleType>(_SalesRoleType.GetSalesRoleType(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _SalesRoleType.Delete(identity);
            return RedirectToAction("_SalesRoleTypeAll");
        }

        [HttpPost]
        public ActionResult Update(Models.SalesRoleType SalesRoleType)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (SalesRoleType.Identity.Equals(-1))
            {
                _SalesRoleType.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.SalesRoleType>(SalesRoleType));
            }
            else
                _SalesRoleType.Update(AutoMapperConfig.Mapper().Map<BusinessModels.SalesRoleType>(SalesRoleType));
            return RedirectToAction("_SalesRoleTypeAll");
        }

        [HttpPost]
        public PartialViewResult SalesRoleTypeSearch(string searchString, string createdDate = "")
        {
            return PartialView("_SalesRoleTypeAll", GetSalesRoleTypes("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_SalesRoleTypeAll", GetSalesRoleTypes(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.SalesRoleType> GetSalesRoleTypes(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "TypeName" : "";

            var SalesRoleTypes = AutoMapperConfig.Mapper().Map<List<Models.SalesRoleType>>(_SalesRoleType.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                SalesRoleTypes = AutoMapperConfig.Mapper().Map<List<Models.SalesRoleType>>(_SalesRoleType.GetAll().ToList().FindAll(p => p.TypeName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                SalesRoleTypes = AutoMapperConfig.Mapper().Map<List<Models.SalesRoleType>>(_SalesRoleType.GetAll().ToList().FindAll(p => p.TypeName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                SalesRoleTypes = AutoMapperConfig.Mapper().Map<List<Models.SalesRoleType>>(_SalesRoleType.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "TypeName":
                    SalesRoleTypes = SalesRoleTypes.OrderByDescending(stu => stu.TypeName).ToList();
                    break;
                case "DateAsc":
                    SalesRoleTypes = SalesRoleTypes.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    SalesRoleTypes = SalesRoleTypes.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    SalesRoleTypes = SalesRoleTypes.OrderBy(stu => stu.TypeName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return SalesRoleTypes.ToPagedList(No_Of_Page, Size_Of_Page);
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
