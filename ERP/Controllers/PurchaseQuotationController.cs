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
    public class PurchaseQuotationController : Controller
    {
        private BusinessLayer.PurchaseQuotation _PurchaseQuotation = new BusinessLayer.PurchaseQuotation();
        private BusinessLayer.PurchaseRequest _PrRequest = new BusinessLayer.PurchaseRequest();
        private BusinessLayer.PurchaseQuotationDetails _PurchaseQuotationDetails = new BusinessLayer.PurchaseQuotationDetails();
        private BusinessLayer.PQAdvanceDetails _PurchaseQAdvanceDetails = new BusinessLayer.PQAdvanceDetails();
        private BusinessLayer.Employee _Employeee = new BusinessLayer.Employee();
        private BusinessLayer.PaymentMode _PaymentMode = new BusinessLayer.PaymentMode();
        private BusinessLayer.PaymentType _PaymentType = new BusinessLayer.PaymentType();
        private BusinessLayer.Status _status = new BusinessLayer.Status();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _PurchaseQuotationAll()
        {
            return PartialView(GetPurchaseQuotations("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _PurchaseQuotationEdit(int identity)
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
        public ActionResult _PurchaseQuotationCancel(int identity)
        {
            return RedirectToAction("_PurchaseQuotationAll");
        }
        [HttpGet]
        public PartialViewResult _PurchaseQuotationView(int identity)
        {

            BusinessModels.PurchaseQuotation mdPurchase = _PurchaseQuotation.GetPurchaseQuotationDetails(identity);
            BusinessModels.PurchaseRequest bmPurchaseRequest = _PrRequest.GetPurchaseRequest(mdPurchase.PurchaseRequestID);
            Models.PurchaseRequest mdpurchaseRequest = AutoMapperConfig.Mapper().Map<Models.PurchaseRequest>(bmPurchaseRequest);

            Decimal totalPrice = 0;
            List<Models.PurchaseRequestDetails> lstPurchaseRequestDetails = new List<Models.PurchaseRequestDetails>();
            foreach (BusinessModels.PurchaseRequestDetails item in bmPurchaseRequest.PurchaseRequestDetails)
            {
                Models.PurchaseRequestDetails mdPurchasereq1 = AutoMapperConfig.Mapper().Map<Models.PurchaseRequestDetails>(item);
                BusinessModels.ItemMaster bmItem = _PrRequest.GetItemDetails(Convert.ToString(mdPurchasereq1.ItemID));
                Models.ItemMaster mdItem = AutoMapperConfig.Mapper().Map<Models.ItemMaster>(bmItem);
                mdPurchasereq1.ItemMaster = mdItem;
                totalPrice += mdItem.RetailPrice * mdPurchasereq1.Quantity;
                lstPurchaseRequestDetails.Add(mdPurchasereq1);
            }
            Models.PurchaseQuotation mdpurchasequote = AutoMapperConfig.Mapper().Map<Models.PurchaseQuotation>(mdPurchase);
            mdpurchasequote.PurchaseRequestDetails = lstPurchaseRequestDetails;
            mdpurchasequote.TotalCost = totalPrice;

            //Get all finance executives on the location and companytype
            //mdsalesMode.EmployeeList = null;
            //mdsalesMode.EmployeeList = new SelectList(_Employeee.GetAllFinanceExecutivesOnCompanyType(Convert.ToInt32(Session["CompanyID"].ToString()), Convert.ToInt32(Session["LocationID"].ToString())), "Identity", "EmployeeName");

            mdpurchasequote.PaymentTypeList = null;
            mdpurchasequote.PaymentTypeList = new SelectList(_PaymentType.GetAll(), "Identity", "Name");

            mdpurchasequote.PaymentModeList = null;
            mdpurchasequote.PaymentModeList = new SelectList(_PaymentMode.GetAll(), "Identity", "Name");

            //Invoice and other details
            BusinessModels.PurchaseQuotationDetails bspurchaseQuoteationdet = _PurchaseQuotationDetails.GetAllByPurchaseQuotation(identity);
            Models.PurchaseQuotationDetails mdpuchasequotedet = AutoMapperConfig.Mapper().Map<Models.PurchaseQuotationDetails>(bspurchaseQuoteationdet);

            if (mdpuchasequotedet != null)
            {
                mdpurchasequote.PurchaseQuotationDetails = mdpuchasequotedet;
                mdpurchasequote.InvoiceNo = mdpuchasequotedet.InvoiceNo;
                mdpurchasequote.PaymentType = mdpuchasequotedet.PaymentTypeID;
                mdpurchasequote.PaymentMode = mdpuchasequotedet.PaymentModeID;
                mdpurchasequote.CheckNo = mdpuchasequotedet.CheckNo;
                //Advanjce Details
                List<Models.PQAdvanceDetails> lstAdvanceDet = new List<Models.PQAdvanceDetails>();
                decimal dAmt = 0;
                foreach (BusinessModels.PQAdvanceDetails item in _PurchaseQAdvanceDetails.GetAllAdvanceByPQ(identity))
                {
                    Models.PQAdvanceDetails mdadvance = AutoMapperConfig.Mapper().Map<Models.PQAdvanceDetails>(item);
                    lstAdvanceDet.Add(mdadvance);
                    dAmt = dAmt + mdadvance.Amount;
                }
                mdpurchasequote.TotalAdvanceAmount = dAmt;
                mdpurchasequote.PQAdvanceDetails = lstAdvanceDet;
            }
            else { List<Models.PQAdvanceDetails> lstAdvanceDet = new List<Models.PQAdvanceDetails>(); mdpurchasequote.PQAdvanceDetails = lstAdvanceDet; }

            return PartialView(mdpurchasequote);
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            BusinessModels.PurchaseQuotation mdRequest = _PurchaseQuotation.GetPurchaseQuotation(identity);
            mdRequest.IsActive = false;
            _PurchaseQuotation.Update(mdRequest);
            return RedirectToAction("_PurchaseQuotationAll");
        }

        [HttpPost]
        public ActionResult DeleteItem(int identity)
        {

            _PurchaseQuotationDetails.Delete(identity);
            return RedirectToAction("_PurchaseQuotationAll");
        }

        [HttpPost]
        public ActionResult Update(Models.PurchaseQuotation PurchaseQuotation, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value

            var empid = frmFields["hdnPurchaseQuotationEmployee"];
            if (!String.IsNullOrEmpty(empid))
                PurchaseQuotation.AssignedTo = int.Parse(empid);

            var mode = frmFields["hdnPurchaseQuotationPaymentMode"];
            if (!String.IsNullOrEmpty(mode))
                PurchaseQuotation.PaymentMode = int.Parse(mode);

            var type = frmFields["hdnPurchaseQuotationPaymentType"];
            if (!String.IsNullOrEmpty(type))
                PurchaseQuotation.PaymentType = int.Parse(type);

            var identity = frmFields["Identity"];
            if (!String.IsNullOrEmpty(identity))
                PurchaseQuotation.Identity = int.Parse(identity);

            //if (!String.IsNullOrEmpty(PurchaseQuotation.InvoiceNo))
            //{
            //coded
            BusinessModels.PurchaseQuotationDetails Purchasedet = new BusinessModels.PurchaseQuotationDetails();
            Purchasedet.PQID = int.Parse(identity);

            BusinessModels.PurchaseQuotationDetails bspurchaseQuotationdet = _PurchaseQuotationDetails.GetAllByPurchaseQuotation(int.Parse(identity));
            if (bspurchaseQuotationdet != null)
            {
                //salesdet.Identity = bssalesQuoteationdet.Identity;
                if (PurchaseQuotation.PaymentType == 7 || ((PurchaseQuotation.AdvanceAmount + PurchaseQuotation.TotalAdvanceAmount) == PurchaseQuotation.TotalCost))
                {
                    bspurchaseQuotationdet.InvoiceNo = PurchaseQuotation.InvoiceNo;

                    bspurchaseQuotationdet.PaymentTypeID = PurchaseQuotation.PaymentType;
                    bspurchaseQuotationdet.PaymentModeID = PurchaseQuotation.PaymentMode;
                    bspurchaseQuotationdet.CheckNo = PurchaseQuotation.CheckNo;
                }
                else
                {

                    Purchasedet.PaymentTypeID = null;
                    Purchasedet.PaymentModeID = null;
                }
                bspurchaseQuotationdet.IsActive = true;
                bspurchaseQuotationdet.ModifiedDate = DateTime.Now;
                bspurchaseQuotationdet.ModifiedBy = Convert.ToInt32(Session["EmployeeID"].ToString());
                _PurchaseQuotationDetails.Update(bspurchaseQuotationdet);
            }
            else
            {
                if (PurchaseQuotation.PaymentType == 7 || ((PurchaseQuotation.AdvanceAmount + PurchaseQuotation.TotalAdvanceAmount) == PurchaseQuotation.TotalCost))
                {
                    Purchasedet.InvoiceNo = PurchaseQuotation.InvoiceNo;
                    Purchasedet.PaymentTypeID = PurchaseQuotation.PaymentType;
                    Purchasedet.PaymentModeID = PurchaseQuotation.PaymentMode;
                    Purchasedet.CheckNo = PurchaseQuotation.CheckNo;
                }               
                else
                {

                    Purchasedet.PaymentTypeID = null;
                    Purchasedet.PaymentModeID = null;
                }
                Purchasedet.IsActive = true;
                Purchasedet.CreatedDate = DateTime.Now;
                Purchasedet.CreatedBy = Convert.ToInt32(Session["EmployeeID"].ToString());
                _PurchaseQuotationDetails.Insert(Purchasedet);
            }

            // }

            //coded add advance details else if paid change status to invoice generated and assign for approval
            if (PurchaseQuotation.PaymentType == 8)
            {
                //Need to do = Add payment mode to advance
                BusinessModels.PQAdvanceDetails purchaseadvancedet = new BusinessModels.PQAdvanceDetails();
                purchaseadvancedet.PQID = int.Parse(identity);
                purchaseadvancedet.Amount = PurchaseQuotation.AdvanceAmount;
                purchaseadvancedet.CreatedDate = DateTime.Now;
                purchaseadvancedet.CreatedBy = Convert.ToInt32(Session["EmployeeID"].ToString());
                purchaseadvancedet.CheckNo = PurchaseQuotation.CheckNo;
                _PurchaseQAdvanceDetails.Insert(purchaseadvancedet);
                if (((PurchaseQuotation.AdvanceAmount + PurchaseQuotation.TotalAdvanceAmount) == PurchaseQuotation.TotalCost) && !String.IsNullOrEmpty(PurchaseQuotation.InvoiceNo))
                {
                    // Get Finance Manager on the location and company
                    BusinessModels.Employee mdemployee = _Employeee.GetFinanceManagerOnCompanyType(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["CompanyID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeCompanyTypeID"])));

                    //Set the workflow
                    _PurchaseQuotation.InitiateinvoiceApprovalWOrkFlow(int.Parse(identity), mdemployee.Identity, Convert.ToInt32(Convert.ToString(Session["LocationID"])));

                    //update status to invoice generated if all payment done
                    _PurchaseQuotation.UpdatePurchaseQuotationStatus(5, int.Parse(identity));

                }
                else
                {
                    //update status to payment pending
                    _PurchaseQuotation.UpdatePurchaseQuotationStatus(9, int.Parse(identity));
                }

            }
            else if (PurchaseQuotation.PaymentType == 7 && !String.IsNullOrEmpty(PurchaseQuotation.InvoiceNo))
            {
                //update status to invoice generated and if full payment
                _PurchaseQuotation.UpdatePurchaseQuotationStatus(5, int.Parse(identity));

                //Initiate Invoice APproval work flow

                // Get Finance Manager on the location and company
                BusinessModels.Employee mdemployee = _Employeee.GetFinanceManagerOnCompanyType(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["CompanyID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeCompanyTypeID"])));

                //Set the workflow
                _PurchaseQuotation.InitiateinvoiceApprovalWOrkFlow(int.Parse(identity), mdemployee.Identity, Convert.ToInt32(Convert.ToString(Session["LocationID"])));
            }


            // _PurchaseQuotation.UpdatePurchaseQuotationAssigned(int.Parse(empid), PendingPurchaseQuotation.Identity);


            return RedirectToAction("_PurchaseQuotationAll");
        }

        //[HttpPost]
        //public ActionResult ManagePurchaseQuotation(Models.PurchaseQuotation PurchaseQuotation, FormCollection frmFields)
        //{
        //    ////Code for purchase request edit
        //    //BusinessModels.PurchaseQuotation mdPurchaseQuotation = AutoMapperConfig.Mapper().Map<BusinessModels.PurchaseQuotation>(PurchaseQuotation);

        //    ////coded
        //    //mdPurchaseQuotation.LocationID = Convert.ToInt32(Convert.ToString(Session["LocationID"]));
        //    //mdPurchaseQuotation.CompanyTypeID = Convert.ToInt32(Convert.ToString(Session["EmployeeCompanyTypeID"]));
        //    //mdPurchaseQuotation.POStatus = 1;
        //    //mdPurchaseQuotation.IsActive = true;

        //    //var hdnPurchaseType = frmFields["hdnpurReqType"];
        //    //if (!String.IsNullOrEmpty(hdnPurchaseType))
        //    //    mdPurchaseQuotation.PurchaseQuotationTypeID = Convert.ToInt32(hdnPurchaseType);

        //    //var hdnenqlvel = frmFields["hdnporequestenqlvel"];
        //    //if (!String.IsNullOrEmpty(hdnenqlvel))
        //    //    mdPurchaseQuotation.EnquiryLevelID = Convert.ToInt32(hdnenqlvel);

        //    //if (PurchaseQuotation.Identity.Equals(-1))
        //    //{
        //    //    mdPurchaseQuotation.IsVerified = false;
        //    //    mdPurchaseQuotation.IsApproved = false;
        //    //    mdPurchaseQuotation.CreatedDate = DateTime.Now;
        //    //    mdPurchaseQuotation.CreatedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
        //    //    mdPurchaseQuotation.AssignedTo = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
        //    //    mdPurchaseQuotation.OriginatorID = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
        //    //    _PurchaseQuotation.Insert(mdPurchaseQuotation);
        //    //}
        //    //else
        //    //{
        //    //    mdPurchaseQuotation.ModifiedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
        //    //    mdPurchaseQuotation.ModifiedDate = DateTime.Now;
        //    //    _PurchaseQuotation.Update(mdPurchaseQuotation);
        //    //}
        //    //return RedirectToAction("_PurchaseQuotationAll");
        //}

        [HttpPost]
        public PartialViewResult PurchaseQuotationSearch(string searchString, string createdDate = "")
        {
            return PartialView("_PurchaseQuotationAll", GetPurchaseQuotations("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_PurchaseQuotationAll", GetPurchaseQuotations(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.PurchaseQuotation> GetPurchaseQuotations(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "PQCode" : "";

            var PurchaseQuotations = new List<Models.PurchaseQuotation>();

            if (Convert.ToString(Session["RoleAccess"]) == "1")
                PurchaseQuotations = AutoMapperConfig.Mapper().Map<List<Models.PurchaseQuotation>>(_PurchaseQuotation.GetAll());
            else if (Convert.ToString(Session["RoleAccess"]) == "2")
                PurchaseQuotations = AutoMapperConfig.Mapper().Map<List<Models.PurchaseQuotation>>(_PurchaseQuotation.GetAll(Convert.ToInt32(Convert.ToString(Session["LocationID"]))));
            else if (Convert.ToString(Session["RoleAccess"]) == "3")
                PurchaseQuotations = AutoMapperConfig.Mapper().Map<List<Models.PurchaseQuotation>>(_PurchaseQuotation.GetAll(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeID"]))));


            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                PurchaseQuotations = AutoMapperConfig.Mapper().Map<List<Models.PurchaseQuotation>>(_PurchaseQuotation.GetAll().ToList().FindAll(p => p.PQCode.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                PurchaseQuotations = AutoMapperConfig.Mapper().Map<List<Models.PurchaseQuotation>>(_PurchaseQuotation.GetAll().ToList().FindAll(p => p.PQCode.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                PurchaseQuotations = AutoMapperConfig.Mapper().Map<List<Models.PurchaseQuotation>>(_PurchaseQuotation.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "PQCode":
                    PurchaseQuotations = PurchaseQuotations.OrderByDescending(stu => stu.PQCode).ToList();
                    break;
                case "DateAsc":
                    PurchaseQuotations = PurchaseQuotations.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    PurchaseQuotations = PurchaseQuotations.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    PurchaseQuotations = PurchaseQuotations.OrderBy(stu => stu.PQCode).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return PurchaseQuotations.ToPagedList(No_Of_Page, Size_Of_Page);
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
