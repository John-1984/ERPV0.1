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
    public class StockInController : Controller
    {
        private BusinessLayer.PurchaseOrder _PurchaseOrder = new BusinessLayer.PurchaseOrder();
        private BusinessLayer.PurchaseRequest _PrRequest = new BusinessLayer.PurchaseRequest();
        private BusinessLayer.PurchaseQuotation _Prquotation = new BusinessLayer.PurchaseQuotation();
        private BusinessLayer.PurchaseQuotationDetails _Prquotationdet = new BusinessLayer.PurchaseQuotationDetails();
        private BusinessLayer.PQAdvanceDetails _PurchaseQAdvanceDetails = new BusinessLayer.PQAdvanceDetails();
        // private BusinessLayer.PurchaseOrderDetails _PurchaseOrderDetails = new BusinessLayer.PurchaseOrderDetails();
        // private BusinessLayer.PQAdvanceDetails _PurchaseQAdvanceDetails = new BusinessLayer.PQAdvanceDetails();
        private BusinessLayer.Employee _Employeee = new BusinessLayer.Employee();
        private BusinessLayer.PaymentMode _PaymentMode = new BusinessLayer.PaymentMode();
        private BusinessLayer.PaymentType _PaymentType = new BusinessLayer.PaymentType();
        private BusinessLayer.Location _Location = new BusinessLayer.Location();
        private BusinessLayer.Status _status = new BusinessLayer.Status();

        private BusinessLayer.StockInExcessDetails _StockInExcessDetails = new BusinessLayer.StockInExcessDetails();
        private BusinessLayer.StockInDamagedDetails _StockInDamagedDetails = new BusinessLayer.StockInDamagedDetails();
        private BusinessLayer.StockInShortageDetails _StockInShortageDetails = new BusinessLayer.StockInShortageDetails();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _StockInAll()
        {
            return PartialView(GetPurchaseOrders("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _StockInEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.PurchaseOrder mdPurchaseOrder = new Models.PurchaseOrder();

                TempData["PageInfo"] = "Add PurchaseOrder Info";
                return PartialView(mdPurchaseOrder);
            }
            else
            {
                // Models.PurchaseOrder mdPurchaseOrder = AutoMapperConfig.Mapper().Map<Models.PurchaseOrder>(_PurchaseOrder.GetPurchaseOrder(identity));
                Models.PurchaseOrder mdPurchaseOrder = new Models.PurchaseOrder();

                //mdPurchaseOrder.ItemList = null;
                //mdPurchaseOrder.ItemList = new SelectList(_PurchaseOrderDetails.GetAllItems(), "Identity", "ItemName");

                mdPurchaseOrder.Identity = identity;
                TempData["PageInfo"] = "Edit PurchaseOrder Info";
                TempData.Keep();
                return PartialView(mdPurchaseOrder);
            }
        }

        public PartialViewResult _StockInExcess()
        {
            ERP.Models.PurchaseOrder mdpurchaseorder = GetOrder(int.Parse(Session["PurchaseOrderID"].ToString()));
           // mdpurchaseorder.Identity = Convert.ToInt32(Session["SalesQuoteID"].ToString());
            //mdsalesMode.ExpenseTypeList = null;
            //mdsalesMode.ExpenseTypeList = new SelectList(_expenseType.GetAll(), "Identity", "TypeName");
            //// mdsalesMode.StockOutExpenseDetails = new List<Models.StockOutExpenseDetails>();
            return PartialView("_StockInExcess", mdpurchaseorder);
        }


        [HttpPost]
        public ActionResult StockInExcessAdd(Models.PurchaseOrder PurchaseOrder, FormCollection frmFields)
        {           

            BusinessModels.StockInExcessDetails itemDet = new BusinessModels.StockInExcessDetails();

            var _itemid = frmFields["hdnstockinexcessitemid"];
            if (!String.IsNullOrEmpty(_itemid))
                itemDet.ItemID = int.Parse(_itemid);
            itemDet.POID = PurchaseOrder.Identity;
            itemDet.Quantity = PurchaseOrder.Quantity;
            itemDet.Size = PurchaseOrder.size;
            itemDet.itemprice = PurchaseOrder.itemprice;

            _StockInExcessDetails.Insert(itemDet);

            ERP.Models.PurchaseOrder mdpurchasseOrder = GetOrder(PurchaseOrder.Identity);
            //IF success resturn grid view
            //IF Failure return json value

            return PartialView("_StockInView", mdpurchasseOrder);
        }

        public PartialViewResult _StockInDamaged()
        {
            ERP.Models.PurchaseOrder mdpurchaseorder = GetOrder(int.Parse(Session["PurchaseOrderID"].ToString()));
          //  mdpurchaseorder.Identity = Convert.ToInt32(Session["SalesQuoteID"].ToString());
            //mdsalesMode.ExpenseTypeList = null;
            //mdsalesMode.ExpenseTypeList = new SelectList(_expenseType.GetAll(), "Identity", "TypeName");
            //// mdsalesMode.StockOutExpenseDetails = new List<Models.StockOutExpenseDetails>();
            return PartialView("_StockInDamaged", mdpurchaseorder);
        }


        [HttpPost]
        public ActionResult StockInDamagedAdd(Models.PurchaseOrder PurchaseOrder, FormCollection frmFields)
        {

            BusinessModels.StockInDamagedDetails itemDet = new BusinessModels.StockInDamagedDetails();

            var _itemid = frmFields["hdnStockInDamageditemid"];
            if (!String.IsNullOrEmpty(_itemid))
                itemDet.ItemID = int.Parse(_itemid);
            itemDet.POID = PurchaseOrder.Identity;
            itemDet.Quantity = PurchaseOrder.Quantity;
            itemDet.Size = PurchaseOrder.size;
            itemDet.itemprice = PurchaseOrder.itemprice;

            _StockInDamagedDetails.Insert(itemDet);

            ERP.Models.PurchaseOrder mdpurchasseOrder = GetOrder(PurchaseOrder.Identity);
            //IF success resturn grid view
            //IF Failure return json value

            return PartialView("_StockInView", mdpurchasseOrder);
        }

        public PartialViewResult _StockInShortage()
        {
            ERP.Models.PurchaseOrder mdpurchaseorder = GetOrder(int.Parse(Session["PurchaseOrderID"].ToString()));
          //  mdpurchaseorder.Identity = Convert.ToInt32(Session["SalesQuoteID"].ToString());
            //mdsalesMode.ExpenseTypeList = null;
            //mdsalesMode.ExpenseTypeList = new SelectList(_expenseType.GetAll(), "Identity", "TypeName");
            //// mdsalesMode.StockOutExpenseDetails = new List<Models.StockOutExpenseDetails>();
            return PartialView("_StockInShortage", mdpurchaseorder);
        }


        [HttpPost]
        public ActionResult StockInShortageAdd(Models.PurchaseOrder PurchaseOrder, FormCollection frmFields)
        {

            BusinessModels.StockInShortageDetails itemDet = new BusinessModels.StockInShortageDetails();

            var _itemid = frmFields["hdnstockinshortageitemid"];
            if (!String.IsNullOrEmpty(_itemid))
                itemDet.ItemID = int.Parse(_itemid);
            itemDet.POID = PurchaseOrder.Identity;
            itemDet.Quantity = PurchaseOrder.Quantity;
            itemDet.Size = PurchaseOrder.size;
            itemDet.itemprice = PurchaseOrder.itemprice;

            _StockInShortageDetails.Insert(itemDet);

            ERP.Models.PurchaseOrder mdpurchasseOrder = GetOrder(PurchaseOrder.Identity);
            //IF success resturn grid view
            //IF Failure return json value

            return PartialView("_StockInView", mdpurchasseOrder);
        }


        [HttpGet]
        public ActionResult _StockInCancel(int identity)
        {
            return RedirectToAction("_StockInAll");
        }
        [HttpPost]
        public JsonResult Employee(string identity)
        {

            return Json(new SelectList(_Employeee.GetAllWareHouseManagerOnLocation(int.Parse(identity)), "Identity", "EmployeeName"));
        }
        [HttpGet]
        public PartialViewResult _StockInView(int identity)
        {
            Session["PurchaseOrderID"] = identity;
            Models.PurchaseOrder mdpurchasequote = GetOrder(identity);
            return PartialView(mdpurchasequote);
        }

        [NonAction]
        public Models.PurchaseOrder GetOrder(int identity)
        {
            BusinessModels.PurchaseOrder mdPurchaseOrder = _PurchaseOrder.GetPurchaseOrderDetails(identity);
            Models.PurchaseOrder mdpurchaseOrder = AutoMapperConfig.Mapper().Map<Models.PurchaseOrder>(mdPurchaseOrder);

            BusinessModels.PurchaseQuotation bmPurchasequotation = _Prquotation.GetPurchaseQuotationDetails(mdPurchaseOrder.PurchaseQuotationID);

            BusinessModels.PurchaseRequest bmPurchaseRequest = _PrRequest.GetPurchaseRequest(bmPurchasequotation.PurchaseRequestID);

            Models.PurchaseRequest mdpurchaseRequest = AutoMapperConfig.Mapper().Map<Models.PurchaseRequest>(bmPurchaseRequest);

            Decimal totalPrice = 0;
            List<Models.PurchaseRequestDetails> lstPurchaseRequestDetails = new List<Models.PurchaseRequestDetails>();
            List<Models.ItemMaster> lstItems = new List<Models.ItemMaster>();
            foreach (BusinessModels.PurchaseRequestDetails item in bmPurchaseRequest.PurchaseRequestDetails)
            {
                Models.PurchaseRequestDetails mdPurchasereq1 = AutoMapperConfig.Mapper().Map<Models.PurchaseRequestDetails>(item);
                BusinessModels.ItemMaster bmItem = _PrRequest.GetItemDetails(Convert.ToString(mdPurchasereq1.ItemID));
                Models.ItemMaster mdItem = AutoMapperConfig.Mapper().Map<Models.ItemMaster>(bmItem);
                mdPurchasereq1.ItemMaster = mdItem;
                lstItems.Add(mdItem);
                totalPrice += mdItem.RetailPrice * mdPurchasereq1.Quantity;
                lstPurchaseRequestDetails.Add(mdPurchasereq1);
            }
            Models.PurchaseOrder mdpurchasequote = AutoMapperConfig.Mapper().Map<Models.PurchaseOrder>(mdPurchaseOrder);
            mdpurchasequote.PurchaseRequestDetails = lstPurchaseRequestDetails;
            mdpurchasequote.TotalCost = totalPrice;

            //Get all finance executives on the location and companytype
            //mdsalesMode.EmployeeList = null;
            //mdsalesMode.EmployeeList = new SelectList(_Employeee.GetAllFinanceExecutivesOnCompanyType(Convert.ToInt32(Session["CompanyID"].ToString()), Convert.ToInt32(Session["LocationID"].ToString())), "Identity", "EmployeeName");

            mdpurchasequote.PaymentTypeList = null;
            mdpurchasequote.PaymentTypeList = new SelectList(_PaymentType.GetAll(), "Identity", "Name");

            mdpurchasequote.PaymentModeList = null;
            mdpurchasequote.PaymentModeList = new SelectList(_PaymentMode.GetAll(), "Identity", "Name");

            mdpurchasequote.LocationList = null;
            mdpurchasequote.LocationList = new SelectList(_Location.GetAll(), "Identity", "LocationName");

            mdpurchasequote.EmployeeList = null;
            mdpurchasequote.EmployeeList = new SelectList(_Employeee.GetAllWareHouseSupervisors(), "Identity", "EmployeeName");

            //Invoice and other details
            BusinessModels.PurchaseQuotationDetails bspurchaseQuoteationdet = _Prquotationdet.GetAllByPurchaseQuotation(bmPurchasequotation.Identity);
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
                foreach (BusinessModels.PQAdvanceDetails item in _PurchaseQAdvanceDetails.GetAllAdvanceByPQ(bmPurchasequotation.Identity))
                {
                    Models.PQAdvanceDetails mdadvance = AutoMapperConfig.Mapper().Map<Models.PQAdvanceDetails>(item);
                    lstAdvanceDet.Add(mdadvance);
                    dAmt = dAmt + mdadvance.Amount;
                }
                mdpurchasequote.TotalAdvanceAmount = dAmt;
                mdpurchasequote.PQAdvanceDetails = lstAdvanceDet;
            }
            else { List<Models.PQAdvanceDetails> lstAdvanceDet = new List<Models.PQAdvanceDetails>(); mdpurchasequote.PQAdvanceDetails = lstAdvanceDet; }

            mdpurchasequote.CreatedDateString = Convert.ToDateTime(mdpurchasequote.CreatedDate).ToString("dd/MMM/yyyy");

            //Stock Excess Details
            List<Models.StockInExcessDetails> lstexcessDet = new List<Models.StockInExcessDetails>();
            int dAmt1 = 0;
            foreach (BusinessModels.StockInExcessDetails item in _StockInExcessDetails.GetAllByPurchaseOrder(identity))
            {
                Models.StockInExcessDetails mdxcess = AutoMapperConfig.Mapper().Map<Models.StockInExcessDetails>(item);
                lstexcessDet.Add(mdxcess);
                dAmt1 = dAmt1 + mdxcess.Quantity;
            }
            mdpurchasequote.TotalExcessItems = dAmt1;
            mdpurchasequote.StockInExcessDetails = lstexcessDet;


            //Stock damaged Details
            List<Models.StockInDamagedDetails> lstdamagedDet = new List<Models.StockInDamagedDetails>();
            int dAmt2 = 0;
            foreach (BusinessModels.StockInDamagedDetails item in _StockInDamagedDetails.GetAllByPurchaseOrder(identity))
            {
                Models.StockInDamagedDetails mddamaged = AutoMapperConfig.Mapper().Map<Models.StockInDamagedDetails>(item);
                lstdamagedDet.Add(mddamaged);
                dAmt2 = dAmt2 + mddamaged.Quantity;
            }
            mdpurchasequote.TotalExcessItems = dAmt2;
            mdpurchasequote.StockInDamagedDetails = lstdamagedDet;

            //Stock Shortage Details
            List<Models.StockInShortageDetails> lstshortageDet = new List<Models.StockInShortageDetails>();
            int dAmt3 = 0;
            foreach (BusinessModels.StockInShortageDetails item in _StockInShortageDetails.GetAllByPurchaseOrder(identity))
            {
                Models.StockInShortageDetails mdshortage= AutoMapperConfig.Mapper().Map<Models.StockInShortageDetails>(item);
                lstshortageDet.Add(mdshortage);
                dAmt3 = dAmt3 + mdshortage.Quantity;
            }
            mdpurchasequote.TotalShortageItems = dAmt3;
            mdpurchasequote.StockInShortageDetails = lstshortageDet;

            IEnumerable<Models.ItemMaster> lstItemsEnumerable = lstItems;
            mdpurchasequote.ItemList = new SelectList(lstItemsEnumerable,"Identity","ItemName");

            return mdpurchasequote;
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            BusinessModels.PurchaseOrder mdRequest = _PurchaseOrder.GetPurchaseOrder(identity);
            mdRequest.IsActive = false;
            _PurchaseOrder.Update(mdRequest);
            return RedirectToAction("_StockInAll");
        }

        [HttpPost]
        public ActionResult DeleteItem(int identity)
        {

            // _PurchaseOrderDetails.Delete(identity);
            return RedirectToAction("_StockInAll");
        }

        [HttpPost]
        public ActionResult Update(Models.PurchaseOrder PurchaseOrder, FormCollection frmFields)
        {
            ////IF success resturn grid view
            ////IF Failure return json value

            var empid = frmFields["hdnStockInEmployee"];
            if (!String.IsNullOrEmpty(empid))
                PurchaseOrder.AssignedTo = int.Parse(empid);

            _PurchaseOrder.UpdatePurchaseOrderAssigned(PurchaseOrder.AssignedTo, PurchaseOrder.Identity);

            return RedirectToAction("_StockInAll");
        }

      

        [HttpPost]
        public PartialViewResult StockInSearch(string searchString, string createdDate = "")
        {
            return PartialView("_StockInAll", GetPurchaseOrders("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_StockInAll", GetPurchaseOrders(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.PurchaseOrder> GetPurchaseOrders(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "POCode" : "";

            var PurchaseOrders = new List<Models.PurchaseOrder>();

            if (Convert.ToString(Session["RoleAccess"]) == "1")
                PurchaseOrders = AutoMapperConfig.Mapper().Map<List<Models.PurchaseOrder>>(_PurchaseOrder.GetAllWarehouseAssignedPO());
            else if (Convert.ToString(Session["RoleAccess"]) == "2")
                PurchaseOrders = AutoMapperConfig.Mapper().Map<List<Models.PurchaseOrder>>(_PurchaseOrder.GetAllWarehouseAssignedPO(Convert.ToInt32(Convert.ToString(Session["LocationID"]))));
            else if (Convert.ToString(Session["RoleAccess"]) == "3")
                PurchaseOrders = AutoMapperConfig.Mapper().Map<List<Models.PurchaseOrder>>(_PurchaseOrder.GetAllWarehouseAssignedPO(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeID"]))));


            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                PurchaseOrders = AutoMapperConfig.Mapper().Map<List<Models.PurchaseOrder>>(PurchaseOrders.ToList().FindAll(p => p.POCode.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                PurchaseOrders = AutoMapperConfig.Mapper().Map<List<Models.PurchaseOrder>>(PurchaseOrders.ToList().FindAll(p => p.POCode.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                PurchaseOrders = AutoMapperConfig.Mapper().Map<List<Models.PurchaseOrder>>(PurchaseOrders.ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "POCode":
                    PurchaseOrders = PurchaseOrders.OrderByDescending(stu => stu.POCode).ToList();
                    break;
                case "DateAsc":
                    PurchaseOrders = PurchaseOrders.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    PurchaseOrders = PurchaseOrders.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    PurchaseOrders = PurchaseOrders.OrderBy(stu => stu.POCode).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return PurchaseOrders.ToPagedList(No_Of_Page, Size_Of_Page);
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
