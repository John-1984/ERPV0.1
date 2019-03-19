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
    public class PendingSalesQuotationController : Controller
    {
        private BusinessLayer.SalesQuotation _SalesQuotation = new BusinessLayer.SalesQuotation();
        private BusinessLayer.ProductEnquiry _ProductEnquiry = new BusinessLayer.ProductEnquiry();
        private BusinessLayer.SalesQuotationDetails _SalesQuotationDetails = new BusinessLayer.SalesQuotationDetails();
        private BusinessLayer.Employee _Employeee = new BusinessLayer.Employee();
        private BusinessLayer.Status _status = new BusinessLayer.Status();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _PendingSalesQuotationAll()
        {
            return PartialView(GetSalesQuotations("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _PendingSalesQuotationEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.SalesQuotation mdSalesQuotation = new Models.SalesQuotation();

                TempData["PageInfo"] = "Add SalesQuotation Info";
                return PartialView(mdSalesQuotation);
            }
            else
            {
                // Models.SalesQuotation mdSalesQuotation = AutoMapperConfig.Mapper().Map<Models.SalesQuotation>(_SalesQuotation.GetSalesQuotation(identity));
                Models.SalesQuotation mdSalesQuotation = new Models.SalesQuotation();

                //mdSalesQuotation.ItemList = null;
                //mdSalesQuotation.ItemList = new SelectList(_SalesQuotationDetails.GetAllItems(), "Identity", "ItemName");

                mdSalesQuotation.Identity = identity;
                TempData["PageInfo"] = "Edit SalesQuotation Info";
                TempData.Keep();
                return PartialView(mdSalesQuotation);
            }
        }


        [HttpGet]
        public ActionResult _PendingSalesQuotationCancel(int identity)
        {
            return RedirectToAction("_PendingSalesQuotationAll");
        }
        [HttpGet]
        public PartialViewResult _PendingSalesQuotationView(int identity)
        {

            BusinessModels.SalesQuotation mdsales = _SalesQuotation.GetSalesQuotationDetails(identity);
            BusinessModels.ProductEnquiry bsProductEnquiry = _ProductEnquiry.GetProductEnquiry(mdsales.ProductEnquiryID);
            Models.ProductEnquiry mdProductEnquiry = AutoMapperConfig.Mapper().Map<Models.ProductEnquiry>(bsProductEnquiry);

            Decimal totalPrice = 0;
            List<Models.ProductEnquiryDetails> lstProductEnquiryDetails = new List<Models.ProductEnquiryDetails>();
            foreach (BusinessModels.ProductEnquiryDetails item in bsProductEnquiry.ProductEnquiryDetails)
            {
                Models.ProductEnquiryDetails mdProductEnquiry1 = AutoMapperConfig.Mapper().Map<Models.ProductEnquiryDetails>(item);
                BusinessModels.ItemMaster bmItem = _ProductEnquiry.GetItemDetails(Convert.ToString(mdProductEnquiry1.ItemID));
                Models.ItemMaster mdItem = AutoMapperConfig.Mapper().Map<Models.ItemMaster>(bmItem);
                mdProductEnquiry1.ItemMaster = mdItem;
                totalPrice += mdItem.RetailPrice;
                lstProductEnquiryDetails.Add(mdProductEnquiry1);
            }
            Models.SalesQuotation mdsalesMode = AutoMapperConfig.Mapper().Map<Models.SalesQuotation>(mdsales);
            mdsalesMode.ProductEnquiryDetails = lstProductEnquiryDetails;
            mdsalesMode.TotalCost = totalPrice;

            //Get all finance executives on the location and companytype
            mdsalesMode.EmployeeList = null;
            mdsalesMode.EmployeeList = new SelectList(_Employeee.GetAllFinanceExecutivesOnCompanyType(Convert.ToInt32(Session["EmployeeCompanyTypeID"].ToString()), Convert.ToInt32(Session["LocationID"].ToString())), "Identity", "EmployeeName");
            return PartialView(mdsalesMode);
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            BusinessModels.SalesQuotation mdRequest = _SalesQuotation.GetSalesQuotation(identity);
            mdRequest.IsActive = false;
            _SalesQuotation.Update(mdRequest);
            return RedirectToAction("_PendingSalesQuotationAll");
        }

        [HttpPost]
        public ActionResult DeleteItem(int identity)
        {

            _SalesQuotationDetails.Delete(identity);
            return RedirectToAction("_PendingSalesQuotationAll");
        }

        [HttpPost]
        public ActionResult Update(Models.SalesQuotation PendingSalesQuotation, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value          
            var empid = frmFields["hdnPendingSalesQuotationEmployee"];
            if (!String.IsNullOrEmpty(empid))
                PendingSalesQuotation.AssignedTo = int.Parse(empid);

            var identity = frmFields["Identity"];
            if (!String.IsNullOrEmpty(identity))
                PendingSalesQuotation.Identity = int.Parse(identity);

            _SalesQuotation.UpdateSalesQuotationAssigned(int.Parse(empid), PendingSalesQuotation.Identity);
           
            return RedirectToAction("_PendingSalesQuotationAll");
        }

        [HttpPost]
        public PartialViewResult PendingSalesQuotationSearch(string searchString, string createdDate = "")
        {
            return PartialView("_PendingSalesQuotationAll", GetSalesQuotations("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_PendingSalesQuotationAll", GetSalesQuotations(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.SalesQuotation> GetSalesQuotations(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "SQCode" : "";

            var PendingSalesQuotations = new List<Models.SalesQuotation>();

            if (Convert.ToString(Session["RoleAccess"]) == "1")
                PendingSalesQuotations = AutoMapperConfig.Mapper().Map<List<Models.SalesQuotation>>(_SalesQuotation.GetAllPendingApporvalSQ());
            else if (Convert.ToString(Session["RoleAccess"]) == "2")
                PendingSalesQuotations = AutoMapperConfig.Mapper().Map<List<Models.SalesQuotation>>(_SalesQuotation.GetAllPendingApporvalSQ(Convert.ToInt32(Convert.ToString(Session["LocationID"]))));
            else if (Convert.ToString(Session["RoleAccess"]) == "3")
                PendingSalesQuotations = AutoMapperConfig.Mapper().Map<List<Models.SalesQuotation>>(_SalesQuotation.GetAllPendingApporvalSQ(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeID"]))));


            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                PendingSalesQuotations = AutoMapperConfig.Mapper().Map<List<Models.SalesQuotation>>(_SalesQuotation.GetAllPendingApporvalSQ().ToList().FindAll(p => p.SQCode.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                PendingSalesQuotations = AutoMapperConfig.Mapper().Map<List<Models.SalesQuotation>>(_SalesQuotation.GetAllPendingApporvalSQ().ToList().FindAll(p => p.SQCode.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                PendingSalesQuotations = AutoMapperConfig.Mapper().Map<List<Models.SalesQuotation>>(_SalesQuotation.GetAllPendingApporvalSQ().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "SQCode":
                    PendingSalesQuotations = PendingSalesQuotations.OrderByDescending(stu => stu.SQCode).ToList();
                    break;
                case "DateAsc":
                    PendingSalesQuotations = PendingSalesQuotations.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    PendingSalesQuotations = PendingSalesQuotations.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    PendingSalesQuotations = PendingSalesQuotations.OrderBy(stu => stu.SQCode).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return PendingSalesQuotations.ToPagedList(No_Of_Page, Size_Of_Page);
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
