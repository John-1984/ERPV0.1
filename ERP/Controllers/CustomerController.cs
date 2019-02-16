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
    [ERP.CustomeFilters.LoggingFilter]
    [ERP.CustomeFilters.ExceptionFilter]
    public class CustomerController : Controller
    {
        private BusinessLayer.Customer _customer = new BusinessLayer.Customer();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _CustomerAll()
        {
            return PartialView(GetCustomers("", 1, "", ""));
        }

        public PartialViewResult _CustomerEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.Customer());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Customer>(_customer.GetCustomer(identity)));
            }

        public PartialViewResult _CustomerView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Customer>(_customer.GetCustomer(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _customer.Delete(identity);
            return RedirectToAction("_CustomerAll");
        }  

        [HttpPost]
        public ActionResult Update(Models.Customer customer){
            //IF success resturn grid view
            //IF Failure return json value
            if (customer.Identity.Equals(-1))
            {
                _customer.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Customer>(customer));
            }
            else
                _customer.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Customer>(customer));
            return RedirectToAction("_CustomerAll");
        }

        [HttpPost]
        public PartialViewResult CustomerSearch(string searchString, string createdDate = ""){
            return PartialView("_CustomerAll", GetCustomers("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")  
        {
            return PartialView("_CustomerAll", GetCustomers(sortOrder, page, createdDate, searchString)); 
        } 

        private IPagedList<Models.Customer> GetCustomers(string sortOrder, int? page, string createdDate = "", string searchString = ""){

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "CustomerName" : "";

            var customers = AutoMapperConfig.Mapper().Map<List<Models.Customer>>(_customer.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                customers = AutoMapperConfig.Mapper().Map<List<Models.Customer>>(_customer.GetAll().ToList().FindAll(p => p.CustomerName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                customers = AutoMapperConfig.Mapper().Map<List<Models.Customer>>(_customer.GetAll().ToList().FindAll(p => p.CustomerName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                customers = AutoMapperConfig.Mapper().Map<List<Models.Customer>>(_customer.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            
            switch (sortOrder)  
            {  
                case "CustomerName":  
                    customers = customers.OrderByDescending(stu=> stu.CustomerName).ToList();  
                break;  
                case "DateAsc":  
                    customers = customers.OrderBy(stu => stu.CreatedDate).ToList();  
                break;  
                case "DateDesc":  
                    customers = customers.OrderByDescending(stu => stu.CreatedDate).ToList();  
                break;  
                default:  
                    customers = customers.OrderBy(stu => stu.CustomerName).ToList();  
                break;  
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return customers.ToPagedList(No_Of_Page, Size_Of_Page);
        }

        //Function to get random number
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min=0, int max=1000)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var customers = _customer.GetMatchingCustomers(prefix);

            return Json(customers);
        }

    }
}
