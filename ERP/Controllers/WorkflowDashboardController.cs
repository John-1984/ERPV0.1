using System;
using System.Collections.Generic;

using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace ERP.Controllers
{

    [ERP.CustomeFilters.LoggingFilter]
    [ERP.CustomeFilters.ExceptionFilter]
    public class WorkflowDashboardController : Controller
    {
        private readonly WorkflowManager.WorkflowEngine _workflowEngine = new WorkflowManager.WorkflowEngine();

        private BusinessLayer.ProductEnquiry _ProductEnquiry = new BusinessLayer.ProductEnquiry();
        private BusinessLayer.SalesQuotation _salesQuotation = new BusinessLayer.SalesQuotation();
        private BusinessLayer.SalesQuotationDetails _SalesQuotationDetails = new BusinessLayer.SalesQuotationDetails();
        private BusinessLayer.SQAdvanceDetails _SalesQAdvanceDetails = new BusinessLayer.SQAdvanceDetails();
        private BusinessLayer.PurchaseRequest _PurchaseRequest = new BusinessLayer.PurchaseRequest();
        private BusinessLayer.PurchaseRequestDetails _PurchaseRequestDetails = new BusinessLayer.PurchaseRequestDetails();
        private BusinessLayer.PurchaseQuotation _purchaseQuotation = new BusinessLayer.PurchaseQuotation();
        private BusinessLayer.PurchaseQuotationDetails _purchaseQuotationDetails = new BusinessLayer.PurchaseQuotationDetails();
        private BusinessLayer.PQAdvanceDetails _pqadvancedetails = new BusinessLayer.PQAdvanceDetails();

        private BusinessLayer.ExpenseType _expenseType = new BusinessLayer.ExpenseType();

        private BusinessLayer.StockOutDetails _StockOutDetails = new BusinessLayer.StockOutDetails();
        private BusinessLayer.StockOutExpenseDetails _StockOutExpenseDetails = new BusinessLayer.StockOutExpenseDetails();

        private BusinessLayer.Status _status= new BusinessLayer.Status();

        public ActionResult Inbox()
        {
            return View("Inbox", GetActiveWorkflows("", 1, "", ""));
        }

        public ActionResult WorkflowAction(int purchaseID, int activeStepID, int activeWorkflowID, int workflowid)
        {
            BusinessModels.Workflow.ActiveWorkflow mdworkflow = _workflowEngine.GetActiveWorkflowsDetails(activeWorkflowID);
            BusinessModels.Workflow.Workflow bswrkflow = _workflowEngine.GetWorkflowsDetails(workflowid);
            Models.Workflow.Workflow mdwrkflow = AutoMapperConfig.Mapper().Map<Models.Workflow.Workflow>(bswrkflow);

            //coded
            if (mdwrkflow.Menu.Name.Contains("Sales Quotation"))
            {
                List<Models.ProductEnquiryDetails> lstProductEnquiryDetails = new List<Models.ProductEnquiryDetails>();
                BusinessModels.SalesQuotation mdsales = _salesQuotation.GetSalesQuotationDetails(mdworkflow.PurchaseID);
                BusinessModels.ProductEnquiry bsProductEnquiry = _ProductEnquiry.GetProductEnquiry(mdsales.ProductEnquiryID);
                Models.ProductEnquiry mdProductEnquiry = AutoMapperConfig.Mapper().Map<Models.ProductEnquiry>(bsProductEnquiry);

                Decimal totalPrice = 0;
                foreach (BusinessModels.ProductEnquiryDetails item in bsProductEnquiry.ProductEnquiryDetails)
                {
                    Models.ProductEnquiryDetails mdProductEnquiry1 = AutoMapperConfig.Mapper().Map<Models.ProductEnquiryDetails>(item);
                    BusinessModels.ItemMaster bmItem = _ProductEnquiry.GetItemDetails(Convert.ToString(mdProductEnquiry1.ItemID));
                    Models.ItemMaster mdItem = AutoMapperConfig.Mapper().Map<Models.ItemMaster>(bmItem);
                    mdProductEnquiry1.ItemMaster = mdItem;
                    totalPrice += mdItem.RetailPrice * mdProductEnquiry1.Quantity;
                    lstProductEnquiryDetails.Add(mdProductEnquiry1);
                }

                mdwrkflow.ProductEnquiryDetails = lstProductEnquiryDetails;
                mdwrkflow.TotalCost = totalPrice;
                mdwrkflow.ItemTypeName = mdwrkflow.Menu.Name;
            }

            if (mdwrkflow.Menu.Name.Contains("Sales Invoice Generated"))
            {
                List<Models.ProductEnquiryDetails> lstProductEnquiryDetails = new List<Models.ProductEnquiryDetails>();
                BusinessModels.SalesQuotation mdsales = _salesQuotation.GetSalesQuotationDetails(mdworkflow.PurchaseID);
                mdwrkflow.SQCode = mdsales.SQCode;
                mdwrkflow.EnquiryLevelName = mdsales.EnquiryLevel.EnquiryLevelName;
                mdwrkflow.StatusName = mdsales.Status.StatusName;
                mdwrkflow.SQCreatedDate = Convert.ToDateTime(mdsales.CreatedDate).ToString("dd/MMM/yyyy");


                BusinessModels.ProductEnquiry bsProductEnquiry = _ProductEnquiry.GetProductEnquiry(mdsales.ProductEnquiryID);
                Models.ProductEnquiry mdProductEnquiry = AutoMapperConfig.Mapper().Map<Models.ProductEnquiry>(bsProductEnquiry);

                Decimal totalPrice = 0;
                foreach (BusinessModels.ProductEnquiryDetails item in bsProductEnquiry.ProductEnquiryDetails)
                {
                    Models.ProductEnquiryDetails mdProductEnquiry1 = AutoMapperConfig.Mapper().Map<Models.ProductEnquiryDetails>(item);
                    BusinessModels.ItemMaster bmItem = _ProductEnquiry.GetItemDetails(Convert.ToString(mdProductEnquiry1.ItemID));
                    Models.ItemMaster mdItem = AutoMapperConfig.Mapper().Map<Models.ItemMaster>(bmItem);
                    mdProductEnquiry1.ItemMaster = mdItem;
                    totalPrice += mdItem.RetailPrice * mdProductEnquiry1.Quantity;
                    lstProductEnquiryDetails.Add(mdProductEnquiry1);
                }

                mdwrkflow.ProductEnquiryDetails = lstProductEnquiryDetails;
                mdwrkflow.TotalCost = totalPrice;
                mdwrkflow.ItemTypeName = mdwrkflow.Menu.Name;

                //Get Sales quotation Details
                BusinessModels.SalesQuotationDetails bmsalesQuoteationdet = _SalesQuotationDetails.GetAllBySalesQuotation(mdsales.Identity);
                Models.SalesQuotationDetails mdsalesQuoteationdet = AutoMapperConfig.Mapper().Map<Models.SalesQuotationDetails>(bmsalesQuoteationdet);
                mdwrkflow.SQDetails = mdsalesQuoteationdet;

                mdwrkflow.InvoiceNo = mdsalesQuoteationdet.InvoiceNo;

                if (mdsalesQuoteationdet.PaymentTypeID == 7)
                {
                    mdwrkflow.PaymerMode = mdsalesQuoteationdet.PaymentMode.Name;
                    mdwrkflow.CheckNo = mdsalesQuoteationdet.CheckNo;
                }
                //Get Advance Details
                List<Models.SQAdvanceDetails> lstAdvanceDet = new List<Models.SQAdvanceDetails>();
                decimal dAmt = 0;
                foreach (BusinessModels.SQAdvanceDetails item in _SalesQAdvanceDetails.GetAllAdvanceBySQ(mdsales.Identity))
                {
                    Models.SQAdvanceDetails mdadvance = AutoMapperConfig.Mapper().Map<Models.SQAdvanceDetails>(item);
                    lstAdvanceDet.Add(mdadvance);
                    dAmt = dAmt + mdadvance.Amount;
                }
                mdwrkflow.SQAdvanceDetails = lstAdvanceDet;
                mdwrkflow.TotalAdvanceAmount = dAmt;
            }
            else if (mdwrkflow.Menu.Name.Contains("Purchase Request"))
            {
                List<Models.PurchaseRequestDetails> lstPurchaseRequestDetails = new List<Models.PurchaseRequestDetails>();
                BusinessModels.PurchaseRequest bspurchaserequest = _PurchaseRequest.GetPurchaseRequest(mdworkflow.PurchaseID);
                Models.PurchaseRequest mdPurchaseRequest = AutoMapperConfig.Mapper().Map<Models.PurchaseRequest>(bspurchaserequest);

                Decimal totalPrice = 0;
                foreach (BusinessModels.PurchaseRequestDetails item in bspurchaserequest.PurchaseRequestDetails)
                {
                    Models.PurchaseRequestDetails mdpurchaserequest1 = AutoMapperConfig.Mapper().Map<Models.PurchaseRequestDetails>(item);
                    BusinessModels.ItemMaster bmItem = _ProductEnquiry.GetItemDetails(Convert.ToString(mdpurchaserequest1.ItemID));
                    Models.ItemMaster mdItem = AutoMapperConfig.Mapper().Map<Models.ItemMaster>(bmItem);
                    mdpurchaserequest1.ItemMaster = mdItem;
                    totalPrice += mdItem.RetailPrice * mdpurchaserequest1.Quantity;
                    lstPurchaseRequestDetails.Add(mdpurchaserequest1);
                }

                mdwrkflow.PurchaseRequestDetails = lstPurchaseRequestDetails;
                mdwrkflow.TotalCost = totalPrice;
                mdwrkflow.ItemTypeName = mdwrkflow.Menu.Name;
            }
            else if (mdwrkflow.Menu.Name.Contains("PR Invoice Generated"))
            {
                List<Models.PurchaseRequestDetails> lstPurchaseRequestDetails = new List<Models.PurchaseRequestDetails>();
                BusinessModels.PurchaseQuotation mdPurchase = _purchaseQuotation.GetPurchaseQuotationDetails(mdworkflow.PurchaseID);
                mdwrkflow.PQCode = mdPurchase.PQCode;
                mdwrkflow.EnquiryLevelName = mdPurchase.EnquiryLevel.EnquiryLevelName;
                mdwrkflow.StatusName = mdPurchase.Status.StatusName;
                mdwrkflow.PQCreatedDate = Convert.ToDateTime(mdPurchase.CreatedDate).ToString("dd/MMM/yyyy");


                BusinessModels.PurchaseRequest bmpurchaserequest = _PurchaseRequest.GetPurchaseRequest(mdPurchase.PurchaseRequestID);
                Models.PurchaseRequest mdpurchaserequest = AutoMapperConfig.Mapper().Map<Models.PurchaseRequest>(bmpurchaserequest);

                Decimal totalPrice = 0;
                foreach (BusinessModels.PurchaseRequestDetails item in bmpurchaserequest.PurchaseRequestDetails)
                {
                    Models.PurchaseRequestDetails mdPRReqDet1 = AutoMapperConfig.Mapper().Map<Models.PurchaseRequestDetails>(item);
                    BusinessModels.ItemMaster bmItem = _ProductEnquiry.GetItemDetails(Convert.ToString(mdPRReqDet1.ItemID));
                    Models.ItemMaster mdItem = AutoMapperConfig.Mapper().Map<Models.ItemMaster>(bmItem);
                    mdPRReqDet1.ItemMaster = mdItem;
                    totalPrice += mdItem.RetailPrice * mdPRReqDet1.Quantity;
                    lstPurchaseRequestDetails.Add(mdPRReqDet1);
                }

                mdwrkflow.PurchaseRequestDetails = lstPurchaseRequestDetails;
                mdwrkflow.TotalCost = totalPrice;
                mdwrkflow.ItemTypeName = mdwrkflow.Menu.Name;

                //Get Sales quotation Details
                BusinessModels.PurchaseQuotationDetails bmpurchasequotationdet = _purchaseQuotationDetails.GetAllByPurchaseQuotation(mdPurchase.Identity);
                Models.PurchaseQuotationDetails mdpurchasequotationdet = AutoMapperConfig.Mapper().Map<Models.PurchaseQuotationDetails>(bmpurchasequotationdet);
                mdwrkflow.PQDetails = mdpurchasequotationdet;

                mdwrkflow.InvoiceNo = mdpurchasequotationdet.InvoiceNo;

                if (mdpurchasequotationdet.PaymentTypeID == 7)
                {
                    mdwrkflow.PaymerMode = mdpurchasequotationdet.PaymentMode.Name;
                    mdwrkflow.CheckNo = mdpurchasequotationdet.CheckNo;
                }
                //Get Advance Details
                List<Models.PQAdvanceDetails> lstAdvanceDet = new List<Models.PQAdvanceDetails>();
                decimal dAmt = 0;
                foreach (BusinessModels.PQAdvanceDetails item in _pqadvancedetails.GetAllAdvanceByPQ(mdPurchase.Identity))
                {
                    Models.PQAdvanceDetails mdadvance = AutoMapperConfig.Mapper().Map<Models.PQAdvanceDetails>(item);
                    lstAdvanceDet.Add(mdadvance);
                    dAmt = dAmt + mdadvance.Amount;
                }
                mdwrkflow.PQAdvanceDetails = lstAdvanceDet;
                mdwrkflow.TotalAdvanceAmount = dAmt;
            }
            else if (mdwrkflow.Menu.Name.Contains("Stock Out"))
            {
                ERP.Models.SalesQuotation mdsalesQuote = GetQuotationModel(mdworkflow.PurchaseID);
                mdwrkflow.SQCode = mdsalesQuote.SQCode;
                mdwrkflow.StatusName = mdsalesQuote.Status.StatusName;
                mdwrkflow.EnquiryLevelName = mdsalesQuote.EnquiryLevel.EnquiryLevelName;
                mdwrkflow.CreatedDateString= mdsalesQuote.CreatedDateString;
                mdwrkflow.ProductEnquiryDetails = mdsalesQuote.ProductEnquiryDetails;
                mdwrkflow.TotalCost = mdsalesQuote.TotalCost;
               mdwrkflow.StockOutExpenseDetails = mdsalesQuote.StockOutExpenseDetails;
               mdwrkflow.TotalExpenseCost = mdsalesQuote.TotalExpenseCost;
                mdwrkflow.VehicleNo= mdsalesQuote.VehicleNo;
               mdwrkflow.ContainerNo = mdsalesQuote.ContainerNo;
                mdwrkflow.DriverName = mdsalesQuote.DriverName;
                mdwrkflow.StatusName = mdsalesQuote.Status.StatusName;
                mdwrkflow.DriverLicenceNumber= mdsalesQuote.DriverLicenceNumber;
                mdwrkflow.DisapatchTime = mdsalesQuote.DisapatchTime;
            }


            TempData["PurchaseID"] = ViewBag.PurchaseID = purchaseID;
            TempData["ActiveStepID"] = ViewBag.ActiveStepID = activeStepID;
            TempData["ActiveWorkflowID"] = ViewBag.ActiveWorkflowID = activeWorkflowID;
            TempData["ItemTypeID"] = ViewBag.ItemTypeID = mdwrkflow.Menu.ID;
            TempData["ItemTypeName"] = ViewBag.ItemTypeName = mdwrkflow.Menu.Name;

            return View(mdwrkflow);
        }

        public ERP.Models.SalesQuotation GetQuotationModel(int identity)
        {

            BusinessModels.SalesQuotation mdsales = _salesQuotation.GetSalesQuotationDetails(identity);
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
                totalPrice += mdItem.RetailPrice * mdProductEnquiry1.Quantity;
                lstProductEnquiryDetails.Add(mdProductEnquiry1);
            }
            Models.SalesQuotation mdsalesMode = AutoMapperConfig.Mapper().Map<Models.SalesQuotation>(mdsales);
            mdsalesMode.ProductEnquiryDetails = lstProductEnquiryDetails;
            mdsalesMode.TotalCost = totalPrice;

            //Get all finance executives on the location and companytype
            //mdsalesMode.EmployeeList = null;
            //mdsalesMode.EmployeeList = new SelectList(_Employeee.GetAllFinanceExecutivesOnCompanyType(Convert.ToInt32(Session["CompanyID"].ToString()), Convert.ToInt32(Session["LocationID"].ToString())), "Identity", "EmployeeName");

            mdsalesMode.StatusList = null;
            mdsalesMode.StatusList = new SelectList(_status.GetAll(), "Identity", "StatusName");

            mdsalesMode.ExpenseTypeList = null;
            mdsalesMode.ExpenseTypeList = new SelectList(_expenseType.GetAll(), "Identity", "TypeName");

            mdsalesMode.CreatedDateString = Convert.ToDateTime(mdsalesMode.CreatedDate).ToString("dd/MMM/yyyy");

            //Invoice and other details
            BusinessModels.SalesQuotationDetails bssalesQuoteationdet = _SalesQuotationDetails.GetAllBySalesQuotation(identity);
            Models.SalesQuotationDetails mdsalesquotedet = AutoMapperConfig.Mapper().Map<Models.SalesQuotationDetails>(bssalesQuoteationdet);

            if (mdsalesquotedet != null)
            {
                mdsalesMode.SalesQuotationDetails = mdsalesquotedet;
                mdsalesMode.InvoiceNo = mdsalesquotedet.InvoiceNo;
                mdsalesMode.PaymentType = mdsalesquotedet.PaymentTypeID;
                mdsalesMode.PaymentMode = mdsalesquotedet.PaymentModeID;
                mdsalesMode.CheckNo = mdsalesquotedet.CheckNo;
                //Advanjce Details
                List<Models.SQAdvanceDetails> lstAdvanceDet = new List<Models.SQAdvanceDetails>();
                decimal dAmt = 0;
                foreach (BusinessModels.SQAdvanceDetails item in _SalesQAdvanceDetails.GetAllAdvanceBySQ(identity))
                {
                    Models.SQAdvanceDetails mdadvance = AutoMapperConfig.Mapper().Map<Models.SQAdvanceDetails>(item);
                    lstAdvanceDet.Add(mdadvance);
                    dAmt = dAmt + mdadvance.Amount;
                }
                mdsalesMode.TotalAdvanceAmount = dAmt;
                mdsalesMode.SQAdvanceDetails = lstAdvanceDet;
            }
            else { List<Models.SQAdvanceDetails> lstAdvanceDet = new List<Models.SQAdvanceDetails>(); mdsalesMode.SQAdvanceDetails = lstAdvanceDet; }

            BusinessModels.StockOutDetails bsstockoutdet = _StockOutDetails.GetAllBySalesQuotation(identity);
            Models.StockOutDetails mdstockout = AutoMapperConfig.Mapper().Map<Models.StockOutDetails>(bsstockoutdet);

            if (mdstockout != null)
            {
                mdsalesMode.VehicleNo = mdstockout.VehicleNo;
                mdsalesMode.DriverName = mdstockout.DriverName;
                mdsalesMode.ContainerNo = mdstockout.ContainerNo;
                mdsalesMode.DriverLicenceNumber = mdstockout.DriverLicenceNumber;
                mdsalesMode.AdditionalAmountPaid = mdstockout.AdditionalAmountPaid;
                mdsalesMode.DisapatchTime = mdstockout.DisapatchTime;

            }


            //Expense Details
            List<Models.StockOutExpenseDetails> lstexpenseDet = new List<Models.StockOutExpenseDetails>();
            decimal dAmt1 = 0;
            foreach (BusinessModels.StockOutExpenseDetails item in _StockOutExpenseDetails.GetAllExpenseBySQ(identity))
            {
                Models.StockOutExpenseDetails mdexpense = AutoMapperConfig.Mapper().Map<Models.StockOutExpenseDetails>(item);
                lstexpenseDet.Add(mdexpense);
                dAmt1 = dAmt1 + mdexpense.Amount;
            }
            mdsalesMode.TotalExpenseCost = dAmt1;
            mdsalesMode.StockOutExpenseDetails = lstexpenseDet;

            return mdsalesMode;
        }
        [HttpPost]

        public ActionResult WorkflowActionHandler(FormCollection formCollection)
        {
            var action = formCollection["Action"];
            var comments = formCollection["Comments"];
            var purchaseID = formCollection["PurchaseID"];
            var activeStepID = formCollection["ActiveStepID"];
            var activeWorkflowID = formCollection["ActiveWorkflowID"];


            var itemtypeid= formCollection["ActiveWorkflowID"];
            var ItemTypeName = formCollection["ItemTypeName"];

            int compType = 0;

            //set company type value to 0 when login is head or higher roles
            if(Session["EmployeeCompanyTypeID"]!=null)
            compType = Convert.ToInt32(Session["EmployeeCompanyTypeID"].ToString());

            _workflowEngine.WorkflowActionHandler(Convert.ToInt32(activeStepID), action, comments, Convert.ToInt32(activeWorkflowID), Convert.ToInt32(purchaseID), Convert.ToInt32(itemtypeid), ItemTypeName,Convert.ToInt32(Session["LocationID"].ToString()), compType, Convert.ToInt32(Session["CompanyID"].ToString()));
            return View("Inbox", GetActiveWorkflows("", 1, "", ""));
        }

        public ActionResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return View("Inbox", GetActiveWorkflows(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Workflow.ActiveStep> GetActiveWorkflows(string sortOrder, int? page, string createdDate = "", string searchString = "")

        {
            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "WorkflowName" : "";


            var _activeSteps = AutoMapperConfig.Mapper().Map<List<Models.Workflow.ActiveStep>>(_workflowEngine.GetActiveWorkflows(Session["EmployeeID"].ToString()));
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                _activeSteps = _activeSteps.FindAll(p => p.ActiveWorkflow.Workflow.Name.ToLower().Contains(searchString.ToLower()) && (Convert.ToDateTime(p.ActiveWorkflow.CreatedDate)).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate));
            else if (!string.IsNullOrEmpty(searchString))
                _activeSteps = _activeSteps.FindAll(p => p.ActiveWorkflow.Workflow.Name.ToLower().Contains(searchString.ToLower()));
            else if (!string.IsNullOrEmpty(createdDate))
                _activeSteps = _activeSteps.FindAll(p => (Convert.ToDateTime(p.ActiveWorkflow.CreatedDate)).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate));

            switch (sortOrder)
            {
                case "WorkflowName":
                    _activeSteps = _activeSteps.OrderByDescending(st => st.ActiveWorkflow.Workflow.Name).ToList();
                    break;
                case "DateAsc":
                    _activeSteps = _activeSteps.OrderBy(st => st.ActiveWorkflow.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    _activeSteps = _activeSteps.OrderByDescending(st => st.ActiveWorkflow.CreatedDate).ToList();
                    break;
                default:
                    _activeSteps = _activeSteps.OrderBy(st => st.ActiveWorkflow.Workflow.Name).ToList();
                    break;

            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return _activeSteps.ToPagedList(No_Of_Page, Size_Of_Page);
        }
    }
}