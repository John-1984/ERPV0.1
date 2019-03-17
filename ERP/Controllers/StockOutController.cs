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
    public class StockOutController : Controller
    {
        private BusinessLayer.SalesQuotation _SalesQuotation = new BusinessLayer.SalesQuotation();
        private BusinessLayer.ProductEnquiry _ProductEnquiry = new BusinessLayer.ProductEnquiry();
        private BusinessLayer.SalesQuotationDetails _SalesQuotationDetails = new BusinessLayer.SalesQuotationDetails();
        private BusinessLayer.StockOutDetails _StockOutDetails = new BusinessLayer.StockOutDetails();
        private BusinessLayer.SQAdvanceDetails _SalesQAdvanceDetails = new BusinessLayer.SQAdvanceDetails();
        private BusinessLayer.StockOutExpenseDetails _StockOutExpenseDetails = new BusinessLayer.StockOutExpenseDetails();
        private BusinessLayer.Employee _Employeee = new BusinessLayer.Employee();
        private BusinessLayer.PaymentMode _PaymentMode = new BusinessLayer.PaymentMode();
        private BusinessLayer.PaymentType _PaymentType = new BusinessLayer.PaymentType();
        private BusinessLayer.Status _status = new BusinessLayer.Status();
        private BusinessLayer.ExpenseType _expenseType = new BusinessLayer.ExpenseType();

        private BusinessLayer.Stocks _stocks= new BusinessLayer.Stocks();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _StockOutAll()
        {
            return PartialView(GetSalesQuotations("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _StockOutEdit(int identity)
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
        public ActionResult _StockOutCancel(int identity)
        {
            return RedirectToAction("_StockOutAll");
        }
        [HttpGet]
        public PartialViewResult _StockOutView(int identity)
        {
            Session["SalesQuoteID"] = identity;

            ERP.Models.SalesQuotation mdsalesMode = GetQuotationModel(identity);

            return PartialView(mdsalesMode);
        }

        [NonAction]
        public ERP.Models.SalesQuotation GetQuotationModel(int identity)
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
        public ActionResult Delete(int identity)
        {
            BusinessModels.SalesQuotation mdRequest = _SalesQuotation.GetSalesQuotation(identity);
            mdRequest.IsActive = false;
            _SalesQuotation.Update(mdRequest);
            return RedirectToAction("_StockOutAll");
        }

        [HttpPost]
        public ActionResult DeleteItem(int identity)
        {

            _SalesQuotationDetails.Delete(identity);
            return RedirectToAction("_StockOutAll");
        }

        public PartialViewResult _StockOutExpense()
        {
            ERP.Models.SalesQuotation mdsalesMode = GetQuotationModel(int.Parse(Session["SalesQuoteID"].ToString()));
            mdsalesMode.Identity = Convert.ToInt32(Session["SalesQuoteID"].ToString());
            mdsalesMode.ExpenseTypeList = null;
            mdsalesMode.ExpenseTypeList = new SelectList(_expenseType.GetAll(), "Identity", "TypeName");
           // mdsalesMode.StockOutExpenseDetails = new List<Models.StockOutExpenseDetails>();
            return PartialView("_StockOutExpense", mdsalesMode);
        }


        [HttpPost]
        public ActionResult StockOutExpenseAdd(Models.SalesQuotation SalesQuotation, FormCollection frmFields)
        {
            

            var _expensetype = frmFields["hdnstockoutexpensetype"];
            if (!String.IsNullOrEmpty(_expensetype))
                SalesQuotation.ExpenseTypeID = int.Parse(_expensetype);

            BusinessModels.StockOutExpenseDetails expenseDet = new BusinessModels.StockOutExpenseDetails();
            expenseDet.ExpenseTypeID = SalesQuotation.ExpenseTypeID;
            expenseDet.Amount = SalesQuotation.ExpenseTypeAmount;
            expenseDet.SQID = SalesQuotation.Identity;

            _StockOutExpenseDetails.Insert(expenseDet);

            ERP.Models.SalesQuotation mdsalesMode = GetQuotationModel(SalesQuotation.Identity);
            //IF success resturn grid view
            //IF Failure return json value

            return PartialView("_StockOutView", mdsalesMode);
        }
        [HttpPost]
        public ActionResult Update(Models.SalesQuotation SalesQuotation, FormCollection frmFields)
        {
            BusinessModels.SalesQuotation  _salesdet = _SalesQuotation.GetSalesQuotationDetails(SalesQuotation.Identity);
            //IF success resturn grid view
            //IF Failure return json value

            var _statusVsal = frmFields["hdnstockoutstatus"];
            if (!String.IsNullOrEmpty(_statusVsal))
                SalesQuotation.StatusID = int.Parse(_statusVsal);
          
            //if (!String.IsNullOrEmpty(SalesQuotation.InvoiceNo))
            //{
            //coded
            BusinessModels.SalesQuotationDetails salesdet = new BusinessModels.SalesQuotationDetails();
            salesdet.SQID = SalesQuotation.Identity;

            BusinessModels.StockOutDetails bsstockoutdet = _StockOutDetails.GetAllBySalesQuotation(SalesQuotation.Identity);
            if (bsstockoutdet != null)
            {
                bsstockoutdet.VehicleNo = SalesQuotation.VehicleNo;
                bsstockoutdet.DriverName = SalesQuotation.DriverName;
                bsstockoutdet.ContainerNo = SalesQuotation.ContainerNo;
                bsstockoutdet.DriverLicenceNumber = SalesQuotation.DriverLicenceNumber;
                bsstockoutdet.AdditionalAmountPaid = SalesQuotation.AdditionalAmountPaid;
                bsstockoutdet.DisapatchTime = SalesQuotation.DisapatchTime;

                bsstockoutdet.IsActive = true;
                bsstockoutdet.ModifiedDate = DateTime.Now;
                bsstockoutdet.ModifiedBy = Convert.ToInt32(Session["EmployeeID"].ToString());
                _StockOutDetails.Update(bsstockoutdet);
            }
            else
            {
                bsstockoutdet.VehicleNo = SalesQuotation.VehicleNo;
                bsstockoutdet.DriverName = SalesQuotation.DriverName;
                bsstockoutdet.ContainerNo = SalesQuotation.ContainerNo;
                bsstockoutdet.DriverLicenceNumber = SalesQuotation.DriverLicenceNumber;
                bsstockoutdet.AdditionalAmountPaid = SalesQuotation.AdditionalAmountPaid;
                bsstockoutdet.DisapatchTime = SalesQuotation.DisapatchTime;
                bsstockoutdet.IsActive = true;
                bsstockoutdet.CreatedDate = DateTime.Now;
                bsstockoutdet.CreatedBy = Convert.ToInt32(Session["EmployeeID"].ToString());
                _StockOutDetails.Insert(bsstockoutdet);
            }

            // }

            //coded if approval done and status changed to items shipped
            if (_salesdet.IsDispatchApproved && SalesQuotation.StatusID==14 )
            {

                // Get Finance Manager on the location and company
                //  BusinessModels.Employee mdemployee = _Employeee.GetFinanceManagerOnCompanyType(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["CompanyID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeCompanyTypeID"])));

                //Set the workflow
                //  _SalesQuotation.InitiateinvoiceApprovalWOrkFlow(int.Parse(identity), mdemployee.Identity, Convert.ToInt32(Convert.ToString(Session["LocationID"])));

                //update status to invoice generated if all payment done
                if (!string.IsNullOrEmpty(SalesQuotation.VehicleNo))
                {                

                    //Update Stocks                   
                    BusinessModels.ProductEnquiry bsProductEnquiry = _ProductEnquiry.GetProductEnquiry(_salesdet.ProductEnquiryID);
                    Models.ProductEnquiry mdProductEnquiry = AutoMapperConfig.Mapper().Map<Models.ProductEnquiry>(bsProductEnquiry);

                    List<Models.ProductEnquiryDetails> lstProductEnquiryDetails = new List<Models.ProductEnquiryDetails>();
                    foreach (BusinessModels.ProductEnquiryDetails item in bsProductEnquiry.ProductEnquiryDetails)
                    {
                        Models.ProductEnquiryDetails mdProductEnquiry1 = AutoMapperConfig.Mapper().Map<Models.ProductEnquiryDetails>(item);
                        BusinessModels.ItemMaster bmItem = _ProductEnquiry.GetItemDetails(Convert.ToString(mdProductEnquiry1.ItemID));
                        Models.ItemMaster mdItem = AutoMapperConfig.Mapper().Map<Models.ItemMaster>(bmItem);
                        mdProductEnquiry1.ItemMaster = mdItem;

                        //Update stocks when items is shipped
                        BusinessModels.Stocks bsStocks = _stocks.GetStocks(mdItem.Identity, mdItem.ItemSize);
                        bsStocks.Quantity = bsStocks.Quantity - mdProductEnquiry1.Quantity;
                        _stocks.Update(bsStocks);
                    }

                    //Update status to item shipped;
                }
                else
                {
                    //Need to do model validation
                }

               
            }
            else 
            {
               
                //Set the workflow for approval from managers
               _SalesQuotation.InitiateStockOutApprovalWOrkFlow(SalesQuotation.Identity, int.Parse(Session["EmployeeID"].ToString()), Convert.ToInt32(Convert.ToString(Session["LocationID"])));
            }


            // _SalesQuotation.UpdateSalesQuotationAssigned(int.Parse(empid), PendingSalesQuotation.Identity);


            return RedirectToAction("_StockOutAll");
        }

      

        [HttpPost]
        public PartialViewResult StockOutSearch(string searchString, string createdDate = "")
        {
            return PartialView("_StockOutAll", GetSalesQuotations("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_StockOutAll", GetSalesQuotations(sortOrder, page, createdDate, searchString));
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
