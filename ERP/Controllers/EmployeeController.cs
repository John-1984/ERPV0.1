using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;
using System.Runtime;
using System.Globalization;
using System.Configuration;

namespace ERP.Controllers
{
    public class EmployeeController : Controller
    {
        private BusinessLayer.Employee _Employee = new BusinessLayer.Employee();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _EmployeeAll()
        {
            return PartialView(GetEmployees("", 1, "", ""));
        }

        public PartialViewResult _EmployeeEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.Employee());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Employee>(_Employee.GetEmployee(identity)));
        }

        public PartialViewResult _EmployeeView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Employee>(_Employee.GetEmployee(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Employee.Delete(identity);
            return RedirectToAction("_EmployeeAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Employee Employee)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (Employee.Identity.Equals(-1))
            {
                Employee.Identity = GetRandomNumber();
                _Employee.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Employee>(Employee));
            }
            else
                _Employee.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Employee>(Employee));
            return RedirectToAction("_EmployeeAll");
        }

        [HttpPost]
        public PartialViewResult EmployeeSearch(string searchString, string createdDate = "")
        {
            return PartialView("_EmployeeAll", GetEmployees("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_EmployeeAll", GetEmployees(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Employee> GetEmployees(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "EmployeeName" : "";

            var Employees = AutoMapperConfig.Mapper().Map<List<Models.Employee>>(_Employee.GetAll());
            //if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
            //  //  Employees = AutoMapperConfig.Mapper().Map<List<Models.Employee>>(_Employee.GetAll().ToList().FindAll(p => p.EmployeeName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            //else if (!string.IsNullOrEmpty(searchString))
            //    Employees = AutoMapperConfig.Mapper().Map<List<Models.Employee>>(_Employee.GetAll().ToList().FindAll(p => p.EmployeeName.ToLower().Contains(searchString.ToLower())));
           

            switch (sortOrder)
            {
                case "EmployeeName":
                    Employees = Employees.OrderByDescending(stu => stu.EmployeeName).ToList();
                    break;
                case "DateAsc":
//Employees = Employees.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                  //  Employees = Employees.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    Employees = Employees.OrderBy(stu => stu.EmployeeName).ToList();
                    break;
            }


            int Size_Of_Page = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return Employees.ToPagedList(No_Of_Page, Size_Of_Page);
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
