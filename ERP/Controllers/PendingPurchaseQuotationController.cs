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
    public class PendingPurchaseQuotationController : Controller
    {
        private BusinessLayer.PurchaseQuotation _PurchaseQuotation = new BusinessLayer.PurchaseQuotation();
        private BusinessLayer.PurchaseRequest _PrEnquiry = new BusinessLayer.PurchaseRequest();
        private BusinessLayer.PurchaseQuotationDetails _PurchaseQuotationDetails = new BusinessLayer.PurchaseQuotationDetails();
        private BusinessLayer.Employee _Employeee = new BusinessLayer.Employee();
        private BusinessLayer.Status _status = new BusinessLayer.Status();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _PendingPurchaseQuotationAll()
        {
            return PartialView(GetPurchaseQuotations("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _PendingPurchaseQuotationEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.PurchaseQuotation mdPurchaseQuotation = new Models.PurchaseQuotation();

                TempData["PageInfo"] = "Add PurchaseQuotation Info";
                return PartialView(mdPurchaseQuotation);
            }
            else
            {
                // Models.PurchaseQuotation mdPurchaseQuotation = AutoMapperConfig.Mapper().Map<Models.PurchaseQuotation>(_PurchaseQuotation.GetPurchaseQuotation(identity));
                Models.PurchaseQuotation mdPurchaseQuotation = new Models.PurchaseQuotation();

                //mdPurchaseQuotation.ItemList = null;
                //mdPurchaseQuotation.ItemList = new SelectList(_PurchaseQuotationDetails.GetAllItems(), "Identity", "ItemName");

                mdPurchaseQuotation.Identity = identity;
                TempData["PageInfo"] = "Edit PurchaseQuotation Info";
                TempData.Keep();
                return PartialView(mdPurchaseQuotation);
            }
        }


        [HttpGet]
        public ActionResult _PendingPurchaseQuotationCancel(int identity)
        {
            return RedirectToAction("_PendingPurchaseQuotationAll");
        }
        [HttpGet]
        public PartialViewResult _PendingPurchaseQuotationView(int identity)
        {

            BusinessModels.PurchaseQuotation mdpurchase = _PurchaseQuotation.GetPurchaseQuotationDetails(identity);
            BusinessModels.PurchaseRequest bmpurchaseRequest = _PrEnquiry.GetPurchaseRequest(mdpurchase.PurchaseRequestID);
            Models.PurchaseRequest mdPurchaseRequest = AutoMapperConfig.Mapper().Map<Models.PurchaseRequest>(bmpurchaseRequest);

            Decimal totalPrice = 0;
            List<Models.PurchaseRequestDetails> lstpurchaseReqDetails = new List<Models.PurchaseRequestDetails>();
            foreach (BusinessModels.PurchaseRequestDetails item in bmpurchaseRequest.PurchaseRequestDetails)
            {
                Models.PurchaseRequestDetails mdPurchaserequest1 = AutoMapperConfig.Mapper().Map<Models.PurchaseRequestDetails>(item);
                BusinessModels.ItemMaster bmItem = _PrEnquiry.GetItemDetails(Convert.ToString(mdPurchaserequest1.ItemID));
                Models.ItemMaster mdItem = AutoMapperConfig.Mapper().Map<Models.ItemMaster>(bmItem);
                mdPurchaserequest1.ItemMaster = mdItem;
                totalPrice += mdItem.RetailPrice * mdPurchaserequest1.Quantity;
                lstpurchaseReqDetails.Add(mdPurchaserequest1);
            }
            Models.PurchaseQuotation mdpurchaseMode = AutoMapperConfig.Mapper().Map<Models.PurchaseQuotation>(mdpurchase);
            mdpurchaseMode.PurchaseRequestDetails = lstpurchaseReqDetails;
            mdpurchaseMode.TotalCost = totalPrice;

            //Get all finance executives on the location and companytype
            mdpurchaseMode.EmployeeList = null;
            mdpurchaseMode.EmployeeList = new SelectList(_Employeee.GetAllFinanceExecutivesOnCompanyType(Convert.ToInt32(Session["EmployeeCompanyTypeID"].ToString()), Convert.ToInt32(Session["LocationID"].ToString())), "Identity", "EmployeeName");
            return PartialView(mdpurchaseMode);
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            BusinessModels.PurchaseQuotation mdRequest = _PurchaseQuotation.GetPurchaseQuotation(identity);
            mdRequest.IsActive = false;
            _PurchaseQuotation.Update(mdRequest);
            return RedirectToAction("_PendingPurchaseQuotationAll");
        }

        [HttpPost]
        public ActionResult DeleteItem(int identity)
        {

            _PurchaseQuotationDetails.Delete(identity);
            return RedirectToAction("_PendingPurchaseQuotationAll");
        }

        [HttpPost]
        public ActionResult Update(Models.PurchaseQuotation PendingPurchaseQuotation, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value          
            var empid = frmFields["hdnPendingPurchaseQuotationEmployee"];
            if (!String.IsNullOrEmpty(empid))
                PendingPurchaseQuotation.AssignedTo = int.Parse(empid);

            var identity = frmFields["Identity"];
            if (!String.IsNullOrEmpty(identity))
                PendingPurchaseQuotation.Identity = int.Parse(identity);

            _PurchaseQuotation.UpdatePurchaseQuotationAssigned(int.Parse(empid), PendingPurchaseQuotation.Identity);

            return RedirectToAction("_PendingPurchaseQuotationAll");
        }

        [HttpPost]
        public PartialViewResult PendingPurchaseQuotationSearch(string searchString, string createdDate = "")
        {
            return PartialView("_PendingPurchaseQuotationAll", GetPurchaseQuotations("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_PendingPurchaseQuotationAll", GetPurchaseQuotations(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.PurchaseQuotation> GetPurchaseQuotations(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "PQCode" : "";

            var PendingPurchaseQuotations = new List<Models.PurchaseQuotation>();

            if (Convert.ToString(Session["RoleAccess"]) == "1")
                PendingPurchaseQuotations = AutoMapperConfig.Mapper().Map<List<Models.PurchaseQuotation>>(_PurchaseQuotation.GetAllPendingApporvalPQ());
            else if (Convert.ToString(Session["RoleAccess"]) == "2")
                PendingPurchaseQuotations = AutoMapperConfig.Mapper().Map<List<Models.PurchaseQuotation>>(_PurchaseQuotation.GetAllPendingApporvalPQ(Convert.ToInt32(Convert.ToString(Session["LocationID"]))));
            else if (Convert.ToString(Session["RoleAccess"]) == "3")
                PendingPurchaseQuotations = AutoMapperConfig.Mapper().Map<List<Models.PurchaseQuotation>>(_PurchaseQuotation.GetAllPendingApporvalPQ(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeID"]))));


            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                PendingPurchaseQuotations = AutoMapperConfig.Mapper().Map<List<Models.PurchaseQuotation>>(_PurchaseQuotation.GetAllPendingApporvalPQ().ToList().FindAll(p => p.PQCode.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                PendingPurchaseQuotations = AutoMapperConfig.Mapper().Map<List<Models.PurchaseQuotation>>(_PurchaseQuotation.GetAllPendingApporvalPQ().ToList().FindAll(p => p.PQCode.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                PendingPurchaseQuotations = AutoMapperConfig.Mapper().Map<List<Models.PurchaseQuotation>>(_PurchaseQuotation.GetAllPendingApporvalPQ().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "PQCode":
                    PendingPurchaseQuotations = PendingPurchaseQuotations.OrderByDescending(stu => stu.PQCode).ToList();
                    break;
                case "DateAsc":
                    PendingPurchaseQuotations = PendingPurchaseQuotations.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    PendingPurchaseQuotations = PendingPurchaseQuotations.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    PendingPurchaseQuotations = PendingPurchaseQuotations.OrderBy(stu => stu.PQCode).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return PendingPurchaseQuotations.ToPagedList(No_Of_Page, Size_Of_Page);
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
