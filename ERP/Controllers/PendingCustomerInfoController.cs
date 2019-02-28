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
    [ERP.CustomeFilters.LoggingFilter]
    [ERP.CustomeFilters.ExceptionFilter]
    public class PendingCustomerInfoController : Controller
    {
        private BusinessLayer.PendingCustomerInfo _customer = new BusinessLayer.PendingCustomerInfo();
        private BusinessLayer.CommonFunctions _commonfunc = new BusinessLayer.CommonFunctions();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult _PendingCustomerInfoCancel(int identity)
        {
            return RedirectToAction("_PendingCustomerInfoAll");
        }
        public PartialViewResult _PendingCustomerInfoAll()
        {
            return PartialView(GetCustomers("", 1, "", ""));
        }

        public PartialViewResult _PendingCustomerInfoEdit(int identity)
        {
            int? compTypeID = (int)Session["EmployeeCompanyTypeID"];

            if (identity.Equals(-1))
            {

                Models.Customer mdCustomer = new Models.Customer();
                mdCustomer.EmployeeList = null;
                mdCustomer.EmployeeList = new SelectList(_customer.GetAllFloorExecutivesOnFloor( Convert.ToInt32(Convert.ToString(Session["FloorID"])), Convert.ToInt32(Convert.ToString(Session["LocationID"])), compTypeID), "Identity", "EmployeeName");

                mdCustomer.PurposeList = null;
                mdCustomer.PurposeList = new SelectList(_customer.GetAllPurpose(), "Identity", "Description");

                mdCustomer.StatusList = null;
                mdCustomer.StatusList = new SelectList(_customer.GetAllStatus(), "Identity", "StatusName");

                mdCustomer.EnquiryLevelList = null;
                mdCustomer.EnquiryLevelList = new SelectList(_customer.GetAllEnquiryLevels(), "Identity", "EnquiryLevelName");

                return PartialView(mdCustomer);
            }
            else
            {
                Models.Customer mdCustomer = AutoMapperConfig.Mapper().Map<Models.Customer>(_customer.GetCustomer(identity));
                mdCustomer.EmployeeList = null;
                mdCustomer.EmployeeList = new SelectList(_customer.GetAllFloorExecutivesOnFloor(Convert.ToInt32(Convert.ToString(Session["FloorID"])), Convert.ToInt32(Convert.ToString(Session["LocationID"])), compTypeID), "Identity", "EmployeeName", mdCustomer.AssignedTo);

                mdCustomer.PurposeList = null;
                mdCustomer.PurposeList = new SelectList(_customer.GetAllPurpose(), "Identity", "Description", mdCustomer.PurposeID);

                mdCustomer.StatusList = null;
                mdCustomer.StatusList = new SelectList(_customer.GetAllStatus(), "Identity", "StatusName", mdCustomer.StatusID);

                mdCustomer.EnquiryLevelList = new SelectList(_customer.GetAllEnquiryLevels(), "Identity", "EnquiryLevelName", mdCustomer.EnquiryLevelID);

                return PartialView(mdCustomer);
            }
        }

        public PartialViewResult _PendingCustomerInfoView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Customer>(_customer.GetCustomer(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _customer.Delete(identity);
            return RedirectToAction("_PendingCustomerInfoAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Customer customer, FormCollection frmFields)
        {

            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.Customer mdCustomer = AutoMapperConfig.Mapper().Map<BusinessModels.Customer>(customer);

            var value = frmFields["hdnemployee"];

            if (!String.IsNullOrEmpty(value))
            {
                if (value != "0")
                    mdCustomer.AssignedTo = int.Parse(value);
                else
                    mdCustomer.AssignedTo = null;
            }


            var valuepurpose = frmFields["hdncuspupose"];

            if (!String.IsNullOrEmpty(valuepurpose))
            {
                if (valuepurpose != "0")
                    mdCustomer.PurposeID = int.Parse(valuepurpose);
                else
                    mdCustomer.PurposeID = null;

            }

            var valuestatus = frmFields["hdncuststatus"];

            if (!String.IsNullOrEmpty(valuestatus))
            {
                if (valuestatus != "0")
                    mdCustomer.StatusID = int.Parse(valuestatus);
                else
                    mdCustomer.StatusID = null;
            }

            var valueenquirylevel = frmFields["hdncustenquirylevel"];

            if (!String.IsNullOrEmpty(valueenquirylevel))
            {
                if (valueenquirylevel != "0")
                    mdCustomer.EnquiryLevelID = int.Parse(valueenquirylevel);
                else
                    mdCustomer.EnquiryLevelID = null;
            }

            mdCustomer.LocationID = Convert.ToInt32(Convert.ToString(Session["LocationID"]));

            if (customer.Identity.Equals(-1))
            {
                //mdCustomer.CreatedDate = DateTime.Now;
                //mdCustomer.CreatedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
                //_customer.Insert(mdCustomer);
            }
            else
            {
                mdCustomer.IsActive = false;
                mdCustomer.ModifiedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
                mdCustomer.ModifiedDate = DateTime.Now;
                _customer.Update(mdCustomer);
            }
            return RedirectToAction("_PendingCustomerInfoAll");
        }

        [HttpPost]
        public PartialViewResult PendingCustomerInfoSearch(string searchString, string createdDate = "")
        {
            return PartialView("_PendingCustomerInfoAll", GetCustomers("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_PendingCustomerInfoAll", GetCustomers(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Customer> GetCustomers(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "CustomerName" : "";

            // String strFullAccess = Configuration.AppSettings["jhh"];
            var customers = new List<Models.Customer>();

            if (Convert.ToString(Session["RoleAccess"]) == "1")
                customers = AutoMapperConfig.Mapper().Map<List<Models.Customer>>(_customer.GetAll());
            else if (Convert.ToString(Session["RoleAccess"]) == "2")
                customers = AutoMapperConfig.Mapper().Map<List<Models.Customer>>(_customer.GetAll(Convert.ToInt32(Convert.ToString(Session["LocationID"]))));
            else if (Convert.ToString(Session["RoleAccess"]) == "3")
                customers = AutoMapperConfig.Mapper().Map<List<Models.Customer>>(_customer.GetAll(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeID"]))));

            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                customers = AutoMapperConfig.Mapper().Map<List<Models.Customer>>(_customer.GetAll().ToList().FindAll(p => p.CustomerName.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                customers = AutoMapperConfig.Mapper().Map<List<Models.Customer>>(_customer.GetAll().ToList().FindAll(p => p.CustomerName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                customers = AutoMapperConfig.Mapper().Map<List<Models.Customer>>(_customer.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "CustomerName":
                    customers = customers.OrderByDescending(stu => stu.CustomerName).ToList();
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

        public static int GetRandomNumber(int min = 0, int max = 1000)
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
