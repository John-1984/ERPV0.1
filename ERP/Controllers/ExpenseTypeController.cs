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
    public class ExpenseTypeController : Controller
    {
        private BusinessLayer.ExpenseType _ExpenseType = new BusinessLayer.ExpenseType();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _ExpenseTypeAll()
        {
            return PartialView(GetExpenseTypes("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _ExpenseTypeEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.ExpenseType());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.ExpenseType>(_ExpenseType.GetExpenseType(identity)));
        }

        [HttpGet]
        public PartialViewResult _ExpenseTypeView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.ExpenseType>(_ExpenseType.GetExpenseType(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _ExpenseType.Delete(identity);
            return RedirectToAction("_ExpenseTypeAll");
        }

        [HttpPost]
        public ActionResult Update(Models.ExpenseType ExpenseType)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.ExpenseType mdExpenseType = AutoMapperConfig.Mapper().Map<BusinessModels.ExpenseType>(ExpenseType);

            if (ExpenseType.Identity.Equals(-1))
            {
                mdExpenseType.CreatedDate = DateTime.Now;
                _ExpenseType.Insert(mdExpenseType);
            }
            else
            {
                mdExpenseType.ModifiedDate = DateTime.Now;
                _ExpenseType.Update(mdExpenseType);
            }
            return RedirectToAction("_ExpenseTypeAll");
        }


        [HttpGet]
        public ActionResult _ExpenseTypeCancel(int identity)
        {
            return RedirectToAction("_ExpenseTypeAll");
        }

        [HttpPost]
        public PartialViewResult ExpenseTypeSearch(string searchString, string createdDate = "")
        {
            return PartialView("_ExpenseTypeAll", GetExpenseTypes("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_ExpenseTypeAll", GetExpenseTypes(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.ExpenseType> GetExpenseTypes(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "TypeName" : "";

            var ExpenseTypes = AutoMapperConfig.Mapper().Map<List<Models.ExpenseType>>(_ExpenseType.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                ExpenseTypes = AutoMapperConfig.Mapper().Map<List<Models.ExpenseType>>(_ExpenseType.GetAll().ToList().FindAll(p => p.TypeName.ToLower().Contains(searchString.ToLower()) && Convert.ToDateTime(p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                ExpenseTypes = AutoMapperConfig.Mapper().Map<List<Models.ExpenseType>>(_ExpenseType.GetAll().ToList().FindAll(p => p.TypeName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                ExpenseTypes = AutoMapperConfig.Mapper().Map<List<Models.ExpenseType>>(_ExpenseType.GetAll().ToList().FindAll(p => Convert.ToDateTime(p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "TypeName":
                    ExpenseTypes = ExpenseTypes.OrderByDescending(stu => stu.TypeName).ToList();
                    break;
                case "DateAsc":
                    ExpenseTypes = ExpenseTypes.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    ExpenseTypes = ExpenseTypes.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    ExpenseTypes = ExpenseTypes.OrderBy(stu => stu.TypeName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return ExpenseTypes.ToPagedList(No_Of_Page, Size_Of_Page);
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
