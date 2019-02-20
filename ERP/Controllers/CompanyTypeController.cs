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
    public class CompanyTypeController : Controller
    {
        private BusinessLayer.CompanyType _CompanyType = new BusinessLayer.CompanyType();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _CompanyTypeAll()
        {
            return PartialView(GetCompanyTypes("", 1, "", ""));
        }

        public PartialViewResult _CompanyTypeEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.CompanyType mdCompanyType = new Models.CompanyType();
                mdCompanyType.CompanyList = null;
                mdCompanyType.CompanyList= new SelectList(_CompanyType.GetAllCompanys(), "Identity", "CompanyName");

                return PartialView(mdCompanyType);
            }
            else
            {
                Models.CompanyType mdCompanyType = AutoMapperConfig.Mapper().Map<Models.CompanyType>(_CompanyType.GetCompanyType(identity));
                mdCompanyType.CompanyList = null;
                mdCompanyType.CompanyList = new SelectList(_CompanyType.GetAllCompanys(), "Identity", "CompanyName");

                return PartialView(mdCompanyType);
            }
        }

        public PartialViewResult _CompanyTypeView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.CompanyType>(_CompanyType.GetCompanyType(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _CompanyType.Delete(identity);
            return RedirectToAction("_CompanyTypeAll");
        }

        [HttpPost]
        public ActionResult Update(Models.CompanyType CompanyType)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (CompanyType.Identity.Equals(-1))
            {
                _CompanyType.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.CompanyType>(CompanyType));
            }
            else
                _CompanyType.Update(AutoMapperConfig.Mapper().Map<BusinessModels.CompanyType>(CompanyType));
            return RedirectToAction("_CompanyTypeAll");
        }

        [HttpPost]
        public PartialViewResult CompanyTypeSearch(string searchString, string createdDate = "")
        {
            return PartialView("_CompanyTypeAll", GetCompanyTypes("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_CompanyTypeAll", GetCompanyTypes(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.CompanyType> GetCompanyTypes(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "CompanyName" : "";

            var CompanyTypes = AutoMapperConfig.Mapper().Map<List<Models.CompanyType>>(_CompanyType.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                CompanyTypes = AutoMapperConfig.Mapper().Map<List<Models.CompanyType>>(_CompanyType.GetAll().ToList().FindAll(p => p.CompanyName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                CompanyTypes = AutoMapperConfig.Mapper().Map<List<Models.CompanyType>>(_CompanyType.GetAll().ToList().FindAll(p => p.CompanyName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                CompanyTypes = AutoMapperConfig.Mapper().Map<List<Models.CompanyType>>(_CompanyType.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "CompanyName":
                    CompanyTypes = CompanyTypes.OrderByDescending(stu => stu.CompanyName).ToList();
                    break;
                case "DateAsc":
                    CompanyTypes = CompanyTypes.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    CompanyTypes = CompanyTypes.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    CompanyTypes = CompanyTypes.OrderBy(stu => stu.CompanyName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return CompanyTypes.ToPagedList(No_Of_Page, Size_Of_Page);
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
