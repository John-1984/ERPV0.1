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
    public class OfficeExpenseController : Controller
    {
        private BusinessLayer.OfficeExpense _OfficeExpense = new BusinessLayer.OfficeExpense();
        private BusinessLayer.Employee _Employeee = new BusinessLayer.Employee();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _OfficeExpenseAll()
        {
            return PartialView(GetOfficeExpenses("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _OfficeExpenseEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.OfficeExpense mdOfficeExpense = new Models.OfficeExpense();

                mdOfficeExpense.ExpenseTypeList = null;
                mdOfficeExpense.ExpenseTypeList = new SelectList(_OfficeExpense.GetAllExpenseTpe(), "Identity", "TypeName");

               
                TempData["PageInfo"] = "Add Office Expense Info";
                return PartialView(mdOfficeExpense);
            }
            else
            {
                Models.OfficeExpense mdOfficeExpense = AutoMapperConfig.Mapper().Map<Models.OfficeExpense>(_OfficeExpense.GetOfficeExpense(identity));
                mdOfficeExpense.ExpenseTypeList = null;
                mdOfficeExpense.ExpenseTypeList = new SelectList(_OfficeExpense.GetAllExpenseTpe(), "Identity", "TypeName", mdOfficeExpense.ExpenseID);
                TempData["PageInfo"] = "Edit Office Expense Info";
                TempData.Keep();
                return PartialView(mdOfficeExpense);
            }
        }
        
        [HttpGet]
        public ActionResult _OfficeExpenseCancel(int identity)
        {
            return RedirectToAction("_OfficeExpenseAll");
        }
        [HttpGet]
        public PartialViewResult _OfficeExpenseView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.OfficeExpense>(_OfficeExpense.GetOfficeExpense(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _OfficeExpense.Delete(identity);
            return RedirectToAction("_OfficeExpenseAll");
        }

        [HttpPost]
        public ActionResult _OfficeExpenseProcessVerification(int identity)
        {
            
            return RedirectToAction("_OfficeExpenseAll");
        }

        [HttpPost]
        public ActionResult Update(Models.OfficeExpense OfficeExpense, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.OfficeExpense mdOfficeExpense = AutoMapperConfig.Mapper().Map<BusinessModels.OfficeExpense>(OfficeExpense);
            var itemvalue = frmFields["hdnOfficeexpensetype"];
           

            if (!String.IsNullOrEmpty(itemvalue))
                mdOfficeExpense.ExpenseID = int.Parse(itemvalue);


            mdOfficeExpense.IsActive = true;
            if (OfficeExpense.Identity.Equals(-1))
            {
                mdOfficeExpense.LocationID = Convert.ToInt32(Convert.ToString(Session["LocationID"]));
               
                mdOfficeExpense.CompanyTypeID = Convert.ToInt32(Convert.ToString(Session["EmployeeCompanyTypeID"]));
                mdOfficeExpense.CreatedDate = DateTime.Now;
                mdOfficeExpense.CreatedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
                _OfficeExpense.Insert(mdOfficeExpense);
            }
            else
            {
                OfficeExpense.ModifiedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
                OfficeExpense.ModifiedDate = DateTime.Now;
                _OfficeExpense.Update(mdOfficeExpense);
            }
            return RedirectToAction("_OfficeExpenseAll");
        }

        [HttpPost]
        public PartialViewResult OfficeExpenseSearch(string searchString, string createdDate = "")
        {
            return PartialView("_OfficeExpenseAll", GetOfficeExpenses("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_OfficeExpenseAll", GetOfficeExpenses(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.OfficeExpense> GetOfficeExpenses(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "TypeName" : "";

            var OfficeExpenses = new List<Models.OfficeExpense>();

            if (Convert.ToString(Session["RoleAccess"]) == "1")
                OfficeExpenses = AutoMapperConfig.Mapper().Map<List<Models.OfficeExpense>>(_OfficeExpense.GetAll());
            else if (Convert.ToString(Session["RoleAccess"]) == "2")
                OfficeExpenses = AutoMapperConfig.Mapper().Map<List<Models.OfficeExpense>>(_OfficeExpense.GetAll(Convert.ToInt32(Convert.ToString(Session["LocationID"]))));
            else if (Convert.ToString(Session["RoleAccess"]) == "3")
                OfficeExpenses = AutoMapperConfig.Mapper().Map<List<Models.OfficeExpense>>(_OfficeExpense.GetAll(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeID"]))));


            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                OfficeExpenses = AutoMapperConfig.Mapper().Map<List<Models.OfficeExpense>>(_OfficeExpense.GetAll().ToList().FindAll(p => p.ExpenseType.TypeName.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                OfficeExpenses = AutoMapperConfig.Mapper().Map<List<Models.OfficeExpense>>(_OfficeExpense.GetAll().ToList().FindAll(p => p.ExpenseType.TypeName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                OfficeExpenses = AutoMapperConfig.Mapper().Map<List<Models.OfficeExpense>>(_OfficeExpense.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "TypeName":
                    OfficeExpenses = OfficeExpenses.OrderByDescending(stu => stu.ExpenseType.TypeName).ToList();
                    break;
                case "DateAsc":
                    OfficeExpenses = OfficeExpenses.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    OfficeExpenses = OfficeExpenses.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    OfficeExpenses = OfficeExpenses.OrderBy(stu => stu.ExpenseType.TypeName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return OfficeExpenses.ToPagedList(No_Of_Page, Size_Of_Page);
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
