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
    public class SalesQuotationController : Controller
    {
        private BusinessLayer.SalesQuotation _SalesQuotation = new BusinessLayer.SalesQuotation();
        private BusinessLayer.ProductEnquiry _ProductEnquiry = new BusinessLayer.ProductEnquiry();
        private BusinessLayer.SalesQuotationDetails _SalesQuotationDetails = new BusinessLayer.SalesQuotationDetails();
        private BusinessLayer.SQAdvanceDetails _SalesQAdvanceDetails = new BusinessLayer.SQAdvanceDetails();
        private BusinessLayer.Employee _Employeee = new BusinessLayer.Employee();
        private BusinessLayer.PaymentMode _PaymentMode = new BusinessLayer.PaymentMode();
        private BusinessLayer.PaymentType _PaymentType = new BusinessLayer.PaymentType();
        private BusinessLayer.Status _status = new BusinessLayer.Status();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _SalesQuotationAll()
        {
            return PartialView(GetSalesQuotations("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _SalesQuotationEdit(int identity)
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
        public ActionResult _SalesQuotationCancel(int identity)
        {
            return RedirectToAction("_SalesQuotationAll");
        }
        [HttpGet]
        public PartialViewResult _SalesQuotationView(int identity)
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
                totalPrice += mdItem.RetailPrice * mdProductEnquiry1.Quantity;
                lstProductEnquiryDetails.Add(mdProductEnquiry1);
            }
            Models.SalesQuotation mdsalesMode = AutoMapperConfig.Mapper().Map<Models.SalesQuotation>(mdsales);
            mdsalesMode.ProductEnquiryDetails = lstProductEnquiryDetails;
            mdsalesMode.TotalCost = totalPrice;

            //Get all finance executives on the location and companytype
            //mdsalesMode.EmployeeList = null;
            //mdsalesMode.EmployeeList = new SelectList(_Employeee.GetAllFinanceExecutivesOnCompanyType(Convert.ToInt32(Session["CompanyID"].ToString()), Convert.ToInt32(Session["LocationID"].ToString())), "Identity", "EmployeeName");

            mdsalesMode.PaymentTypeList = null;
            mdsalesMode.PaymentTypeList = new SelectList(_PaymentType.GetAll(), "Identity", "Name");

            mdsalesMode.PaymentModeList = null;
            mdsalesMode.PaymentModeList = new SelectList(_PaymentMode.GetAll(), "Identity", "Name");

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

            return PartialView(mdsalesMode);
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            BusinessModels.SalesQuotation mdRequest = _SalesQuotation.GetSalesQuotation(identity);
            mdRequest.IsActive = false;
            _SalesQuotation.Update(mdRequest);
            return RedirectToAction("_SalesQuotationAll");
        }

        [HttpPost]
        public ActionResult DeleteItem(int identity)
        {

            _SalesQuotationDetails.Delete(identity);
            return RedirectToAction("_SalesQuotationAll");
        }
       
        [HttpPost]
        public ActionResult Update(Models.SalesQuotation SalesQuotation, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value

            var empid = frmFields["hdnSalesQuotationEmployee"];
            if (!String.IsNullOrEmpty(empid))
                SalesQuotation.AssignedTo = int.Parse(empid);

            var mode = frmFields["hdnSalesQuotationPaymentMode"];
            if (!String.IsNullOrEmpty(mode))
                SalesQuotation.PaymentMode = int.Parse(mode);

            var type = frmFields["hdnSalesQuotationPaymentType"];
            if (!String.IsNullOrEmpty(type))
                SalesQuotation.PaymentType = int.Parse(type);

            var identity = frmFields["Identity"];
            if (!String.IsNullOrEmpty(identity))
                SalesQuotation.Identity = int.Parse(identity);

            //if (!String.IsNullOrEmpty(SalesQuotation.InvoiceNo))
            //{
                //coded
                BusinessModels.SalesQuotationDetails salesdet = new BusinessModels.SalesQuotationDetails();
                salesdet.SQID = int.Parse(identity);
                
                BusinessModels.SalesQuotationDetails bssalesQuoteationdet = _SalesQuotationDetails.GetAllBySalesQuotation(int.Parse(identity));
                if (bssalesQuoteationdet != null)
                {
                //salesdet.Identity = bssalesQuoteationdet.Identity;
                if (SalesQuotation.PaymentType == 7)
                {
                    bssalesQuoteationdet.InvoiceNo = SalesQuotation.InvoiceNo;

                    bssalesQuoteationdet.PaymentTypeID = SalesQuotation.PaymentType;
                    bssalesQuoteationdet.PaymentModeID = SalesQuotation.PaymentMode;
                    bssalesQuoteationdet.CheckNo = SalesQuotation.CheckNo;
                }
                    bssalesQuoteationdet.IsActive = true;
                    bssalesQuoteationdet.ModifiedDate = DateTime.Now;
                    bssalesQuoteationdet.ModifiedBy = Convert.ToInt32(Session["EmployeeID"].ToString());
                    _SalesQuotationDetails.Update(bssalesQuoteationdet);
                }
                else
                {
                if (SalesQuotation.PaymentType == 7)
                {
                    salesdet.InvoiceNo = SalesQuotation.InvoiceNo;
                    salesdet.PaymentTypeID = SalesQuotation.PaymentType;
                    salesdet.PaymentModeID = SalesQuotation.PaymentMode;
                    salesdet.CheckNo = SalesQuotation.CheckNo;
                }
                salesdet.IsActive = true;
                    salesdet.CreatedDate = DateTime.Now;
                    salesdet.CreatedBy  = Convert.ToInt32(Session["EmployeeID"].ToString());
                    _SalesQuotationDetails.Insert(salesdet);
                }
                
           // }

            //coded add advance details else if paid change status to invoice generated and assign for approval
            if (SalesQuotation.PaymentType == 8)
            {
                //Need to do = Add payment mode to advance
                BusinessModels.SQAdvanceDetails salesadvancedet = new BusinessModels.SQAdvanceDetails();
                salesadvancedet.SQID = int.Parse(identity);
                salesadvancedet.Amount = SalesQuotation.AdvanceAmount;
                salesadvancedet.CreatedDate = DateTime.Now;
                salesadvancedet.CreatedBy = Convert.ToInt32(Session["EmployeeID"].ToString());
                salesadvancedet.CheckNo = SalesQuotation.CheckNo;
                _SalesQAdvanceDetails.Insert(salesadvancedet);
                if (((SalesQuotation.AdvanceAmount + SalesQuotation.TotalAdvanceAmount) == SalesQuotation.TotalCost) && !String.IsNullOrEmpty(SalesQuotation.InvoiceNo))
                {
                    // Get Finance Manager on the location and company
                    BusinessModels.Employee mdemployee = _Employeee.GetFinanceManagerOnCompanyType(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["CompanyID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeCompanyTypeID"])));

                    //Set the workflow
                    _SalesQuotation.InitiateinvoiceApprovalWOrkFlow(int.Parse(identity), mdemployee.Identity, Convert.ToInt32(Convert.ToString(Session["LocationID"])));

                    //update status to invoice generated if all payment done
                    _SalesQuotation.UpdateSalesQuotationStatus(5, int.Parse(identity));

                }
                else
                {
                    //update status to payment pending
                    _SalesQuotation.UpdateSalesQuotationStatus(9, int.Parse(identity));
                }

            }
            else if (SalesQuotation.PaymentType == 7 && !String.IsNullOrEmpty(SalesQuotation.InvoiceNo))
            {
                //update status to invoice generated and if full payment
                _SalesQuotation.UpdateSalesQuotationStatus(5, int.Parse(identity));

                //Initiate Invoice APproval work flow

                // Get Finance Manager on the location and company
                BusinessModels.Employee mdemployee = _Employeee.GetFinanceManagerOnCompanyType(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["CompanyID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeCompanyTypeID"])));

                //Set the workflow
                _SalesQuotation.InitiateinvoiceApprovalWOrkFlow(int.Parse(identity), mdemployee.Identity, Convert.ToInt32(Convert.ToString(Session["LocationID"])));
            }

           
            // _SalesQuotation.UpdateSalesQuotationAssigned(int.Parse(empid), PendingSalesQuotation.Identity);

           
            return RedirectToAction("_SalesQuotationAll");
        }

        //[HttpPost]
        //public ActionResult ManageSalesQuotation(Models.SalesQuotation SalesQuotation, FormCollection frmFields)
        //{
        //    ////Code for purchase request edit
        //    //BusinessModels.SalesQuotation mdSalesQuotation = AutoMapperConfig.Mapper().Map<BusinessModels.SalesQuotation>(SalesQuotation);

        //    ////coded
        //    //mdSalesQuotation.LocationID = Convert.ToInt32(Convert.ToString(Session["LocationID"]));
        //    //mdSalesQuotation.CompanyTypeID = Convert.ToInt32(Convert.ToString(Session["EmployeeCompanyTypeID"]));
        //    //mdSalesQuotation.POStatus = 1;
        //    //mdSalesQuotation.IsActive = true;

        //    //var hdnPurchaseType = frmFields["hdnpurReqType"];
        //    //if (!String.IsNullOrEmpty(hdnPurchaseType))
        //    //    mdSalesQuotation.SalesQuotationTypeID = Convert.ToInt32(hdnPurchaseType);

        //    //var hdnenqlvel = frmFields["hdnporequestenqlvel"];
        //    //if (!String.IsNullOrEmpty(hdnenqlvel))
        //    //    mdSalesQuotation.EnquiryLevelID = Convert.ToInt32(hdnenqlvel);

        //    //if (SalesQuotation.Identity.Equals(-1))
        //    //{
        //    //    mdSalesQuotation.IsVerified = false;
        //    //    mdSalesQuotation.IsApproved = false;
        //    //    mdSalesQuotation.CreatedDate = DateTime.Now;
        //    //    mdSalesQuotation.CreatedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
        //    //    mdSalesQuotation.AssignedTo = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
        //    //    mdSalesQuotation.OriginatorID = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
        //    //    _SalesQuotation.Insert(mdSalesQuotation);
        //    //}
        //    //else
        //    //{
        //    //    mdSalesQuotation.ModifiedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
        //    //    mdSalesQuotation.ModifiedDate = DateTime.Now;
        //    //    _SalesQuotation.Update(mdSalesQuotation);
        //    //}
        //    //return RedirectToAction("_SalesQuotationAll");
        //}

        [HttpPost]
        public PartialViewResult SalesQuotationSearch(string searchString, string createdDate = "")
        {
            return PartialView("_SalesQuotationAll", GetSalesQuotations("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_SalesQuotationAll", GetSalesQuotations(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.SalesQuotation> GetSalesQuotations(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "SQCode" : "";

            var SalesQuotations = new List<Models.SalesQuotation>();

            if (Convert.ToString(Session["RoleAccess"]) == "1")
                SalesQuotations = AutoMapperConfig.Mapper().Map<List<Models.SalesQuotation>>(_SalesQuotation.GetAll());
            else if (Convert.ToString(Session["RoleAccess"]) == "2")
                SalesQuotations = AutoMapperConfig.Mapper().Map<List<Models.SalesQuotation>>(_SalesQuotation.GetAll(Convert.ToInt32(Convert.ToString(Session["LocationID"]))));
            else if (Convert.ToString(Session["RoleAccess"]) == "3")
                SalesQuotations = AutoMapperConfig.Mapper().Map<List<Models.SalesQuotation>>(_SalesQuotation.GetAll(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeID"]))));


            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                SalesQuotations = AutoMapperConfig.Mapper().Map<List<Models.SalesQuotation>>(_SalesQuotation.GetAll().ToList().FindAll(p => p.SQCode.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                SalesQuotations = AutoMapperConfig.Mapper().Map<List<Models.SalesQuotation>>(_SalesQuotation.GetAll().ToList().FindAll(p => p.SQCode.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                SalesQuotations = AutoMapperConfig.Mapper().Map<List<Models.SalesQuotation>>(_SalesQuotation.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "SQCode":
                    SalesQuotations = SalesQuotations.OrderByDescending(stu => stu.SQCode).ToList();
                    break;
                case "DateAsc":
                    SalesQuotations = SalesQuotations.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    SalesQuotations = SalesQuotations.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    SalesQuotations = SalesQuotations.OrderBy(stu => stu.SQCode).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return SalesQuotations.ToPagedList(No_Of_Page, Size_Of_Page);
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
