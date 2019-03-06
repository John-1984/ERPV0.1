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
    public class SalesQuotationController : Controller
    {
        private BusinessLayer.SalesQuotation _SalesQuotation = new BusinessLayer.SalesQuotation();
        private BusinessLayer.SalesQuotationDetails _SalesQuotationDetails = new BusinessLayer.SalesQuotationDetails();
        private BusinessLayer.Employee _Employeee = new BusinessLayer.Employee();
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

                //mdSalesQuotation.ProductMasterList = null;
                //mdSalesQuotation.ProductMasterList = new SelectList(_SalesQuotationDetails.GetAllProductMasters(), "Identity", "ProductName");

                //mdSalesQuotation.VendorList = null;
                //mdSalesQuotation.VendorList = new SelectList(_SalesQuotationDetails.GetAllVendors(), "Identity", "VendorName");

                //mdSalesQuotation.BrandList = null;
                //mdSalesQuotation.BrandList = new SelectList(_SalesQuotationDetails.GetAllBrands(), "Identity", "BrandName");

                //mdSalesQuotation.ItemList = null;
                //mdSalesQuotation.ItemList = new SelectList(_SalesQuotationDetails.GetAllItems(), "Identity", "ItemName");

                TempData["PageInfo"] = "Add SalesQuotation Info";
                return PartialView(mdSalesQuotation);
            }
            else
            {
                // Models.SalesQuotation mdSalesQuotation = AutoMapperConfig.Mapper().Map<Models.SalesQuotation>(_SalesQuotation.GetSalesQuotation(identity));
                Models.SalesQuotation mdSalesQuotation = new Models.SalesQuotation();
                //mdSalesQuotation.ProductMasterList = null;
                //mdSalesQuotation.ProductMasterList = new SelectList(_SalesQuotationDetails.GetAllProductMasters(), "Identity", "ProductName");

                //mdSalesQuotation.VendorList = null;
                //mdSalesQuotation.VendorList = new SelectList(_SalesQuotationDetails.GetAllVendors(), "Identity", "VendorName");

                //mdSalesQuotation.BrandList = null;
                //mdSalesQuotation.BrandList = new SelectList(_SalesQuotationDetails.GetAllBrands(), "Identity", "BrandName");

                //mdSalesQuotation.ItemList = null;
                //mdSalesQuotation.ItemList = new SelectList(_SalesQuotationDetails.GetAllItems(), "Identity", "ItemName");

                mdSalesQuotation.Identity = identity;
                TempData["PageInfo"] = "Edit SalesQuotation Info";
                TempData.Keep();
                return PartialView(mdSalesQuotation);
            }
        }

        [HttpGet]
        public PartialViewResult _SalesQuotationAdd(int identity)
        {


            if (identity.Equals(-1))
            {
                Models.SalesQuotation mdSalesQuotation = new Models.SalesQuotation();
                //mdSalesQuotation.SalesQuotationTypeList = null;
                //mdSalesQuotation.SalesQuotationTypeList = new SelectList(_SalesQuotation.GetAllSalesQuotationType(), "Identity", "Name");

                //mdSalesQuotation.EnquiryLevelList = null;
                //mdSalesQuotation.EnquiryLevelList = new SelectList(_SalesQuotation.GetAllEnquiryLevels(), "Identity", "EnquiryLevelName");

                return PartialView(mdSalesQuotation);
            }
            else
            {
                Models.SalesQuotation mdSalesQuotation = AutoMapperConfig.Mapper().Map<Models.SalesQuotation>(_SalesQuotation.GetSalesQuotation(identity));

                //mdSalesQuotation.SalesQuotationTypeList = null;
                //mdSalesQuotation.SalesQuotationTypeList = new SelectList(_SalesQuotation.GetAllSalesQuotationType(), "Identity", "Name", mdSalesQuotation.SalesQuotationTypeID);

                //mdSalesQuotation.EnquiryLevelList = null;
                //mdSalesQuotation.EnquiryLevelList = new SelectList(_SalesQuotation.GetAllEnquiryLevels(), "Identity", "EnquiryLevelName", mdSalesQuotation.EnquiryLevelID);

                return PartialView(mdSalesQuotation);
            }



        }
        [HttpPost]
        public JsonResult Brand(string identity)
        {
            return Json(new SelectList(_SalesQuotation.GetAllBrands(identity), "Identity", "BrandName"));
        }

        [HttpPost]
        public JsonResult Vendor(string identity)
        {
            return Json(new SelectList(_SalesQuotation.GetAllVendors(identity), "Identity", "VendorName"));
        }

        [HttpPost]
        public JsonResult Item(string identity)
        {
            return Json(_SalesQuotation.GetItemDetails(identity));
        }
        [HttpGet]
        public PartialViewResult _SalesQuotationDetailsAdd(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.SalesQuotation mdSalesQuotationDetails = new Models.SalesQuotation();

                //mdSalesQuotationDetails.ProductMasterList = null;
                //mdSalesQuotationDetails.ProductMasterList = new SelectList(_SalesQuotation.GetAllProductMasters(), "Identity", "ProductName");

                //mdSalesQuotationDetails.VendorList = null;
                //mdSalesQuotationDetails.VendorList = new SelectList(_SalesQuotation.GetAllVendors(), "Identity", "VendorName");

                //mdSalesQuotationDetails.BrandList = null;
                //mdSalesQuotationDetails.BrandList = new SelectList(_SalesQuotation.GetAllBrands(), "Identity", "BrandName");

                //mdSalesQuotationDetails.ItemList = null;
                //mdSalesQuotationDetails.ItemList = new SelectList(_SalesQuotation.GetAllItems(), "Identity", "ItemName");


                TempData["PageInfo"] = "Add SalesQuotation Info";
                return PartialView(mdSalesQuotationDetails);
            }
            else
            {
                Models.SalesQuotation mdSalesQuotationDetails = new Models.SalesQuotation();

                //Models.SalesQuotationDetails mdSalesQuotationDetails = AutoMapperConfig.Mapper().Map<Models.SalesQuotationDetails>(_SalesQuotation.GetSalesQuotationDetails(identity));

                //mdSalesQuotationDetails.ProductMasterList = null;
                //mdSalesQuotationDetails.ProductMasterList = new SelectList(_SalesQuotation.GetAllProductMasters(), "Identity", "ProductName", mdSalesQuotationDetails.ItemMaster.Brand.Vendor.ProductMasterID);

                //mdSalesQuotationDetails.VendorList = null;
                //mdSalesQuotationDetails.VendorList = new SelectList(_SalesQuotation.GetAllVendors(Convert.ToString(mdSalesQuotationDetails.ItemMaster.Brand.Vendor.ProductMasterID)), "Identity", "VendorName", mdSalesQuotationDetails.ItemMaster.Brand.VendorID) ;

                //mdSalesQuotationDetails.BrandList = null;
                //mdSalesQuotationDetails.BrandList = new SelectList(_SalesQuotation.GetAllBrands(Convert.ToString(mdSalesQuotationDetails.ItemMaster.Brand.VendorID)), "Identity", "BrandName", mdSalesQuotationDetails.ItemMaster.BrandID);

                //mdSalesQuotationDetails.ItemList = null;
                //mdSalesQuotationDetails.ItemList = new SelectList(_SalesQuotation.GetItemMasters(Convert.ToString(mdSalesQuotationDetails.ItemMaster.BrandID)), "Identity", "ItemName",mdSalesQuotationDetails.ItemID);

                //mdSalesQuotationDetails.ProductMasterList = null;
                //mdSalesQuotationDetails.ProductMasterList = new SelectList(_SalesQuotation.GetAllProductMasters(), "Identity", "ProductName");

                //mdSalesQuotationDetails.VendorList = null;
                //mdSalesQuotationDetails.VendorList = new SelectList(_SalesQuotation.GetAllVendors(), "Identity", "VendorName");

                //mdSalesQuotationDetails.BrandList = null;
                //mdSalesQuotationDetails.BrandList = new SelectList(_SalesQuotation.GetAllBrands(), "Identity", "BrandName");

                //mdSalesQuotationDetails.ItemList = null;
                //mdSalesQuotationDetails.ItemList = new SelectList(_SalesQuotation.GetAllItems(), "Identity", "ItemName");

                // mdSalesQuotationDetails.SalesQuotationID = identity;

                TempData["PageInfo"] = "Edit SalesQuotation Info";
                TempData.Keep();
                return PartialView(mdSalesQuotationDetails);
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
            BusinessModels.SalesQuotation bsSalesQuotation = _SalesQuotation.GetSalesQuotation(identity);
            Models.SalesQuotation mdSalesQuotation = AutoMapperConfig.Mapper().Map<Models.SalesQuotation>(bsSalesQuotation);
          //  // mdSalesQuotation.SalesQuotationDetails = bsSalesQuotation.SalesQuotationDetails;
          //  // BusinessModels.SalesQuotation.SalesQuotationDetails mdDet = new BusinessModels.SalesQuotation.SalesQuotationDetails();

          //  List<Models.SalesQuotationDetails> lstSalesQuotationDetails = new List<Models.SalesQuotationDetails>();
          //  foreach (BusinessModels.SalesQuotationDetails item in bsSalesQuotation.SalesQuotationDetails)
          //  {
          //      Models.SalesQuotationDetails mdSalesQuotation1 = AutoMapperConfig.Mapper().Map<Models.SalesQuotationDetails>(item);
          //      BusinessModels.ItemMaster bmItem = _SalesQuotation.GetItemDetails(Convert.ToString(mdSalesQuotation1.ItemID));
          //      Models.ItemMaster mdItem = AutoMapperConfig.Mapper().Map<Models.ItemMaster>(bmItem);
          //    //  mdSalesQuotation1.ItemMaster = mdItem;
          //      lstSalesQuotationDetails.Add(mdSalesQuotation1);
          //  }

          ////  mdSalesQuotation.SalesQuotationDetails = lstSalesQuotationDetails;

           return PartialView(mdSalesQuotation);
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
        public ActionResult _SalesQuotationProcessVerification(int identity)
        {
            BusinessModels.SalesQuotation mdProductenq = _SalesQuotation.GetSalesQuotation(identity);

            BusinessModels.Employee mdemployee = _Employeee.GetSupervisorOnWareHouseCompanyType(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["CompanyID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeCompanyTypeID"])));
            if (mdemployee != null)
            {
                mdProductenq.AssignedTo = mdemployee.Identity;
                mdProductenq.Employee = mdemployee;
                //coded
                mdProductenq.StatusID = 15;
                BusinessModels.Status mdstatus = _status.GetStatus(15);
                mdProductenq.Status = mdstatus;
            }

            _SalesQuotation.UpdateSalesQuotationAssignedandStatus(mdemployee.Identity, 15, identity);
            //_SalesQuotation.Delete(identity);
            return RedirectToAction("_SalesQuotationAll");
        }

        [HttpPost]
        public ActionResult Update(Models.SalesQuotation SalesQuotation, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value

            BusinessModels.SalesQuotationDetails mdSalesQuotationdetails = new BusinessModels.SalesQuotationDetails();
            var itemvalue = frmFields["hdnItem"];
            var itemQty = frmFields["Quantity"];
            var purpose = frmFields["Purpose"];

            //if (!String.IsNullOrEmpty(itemvalue))
            //    mdSalesQuotationdetails.ItemID = int.Parse(itemvalue);

            //mdSalesQuotationdetails.SalesQuotationID = Convert.ToInt32(frmFields["Identity"]);
            //mdSalesQuotationdetails.Quantity = Convert.ToInt32(itemQty);
            //mdSalesQuotationdetails.Purpose = Convert.ToString(purpose);

            _SalesQuotationDetails.Insert(mdSalesQuotationdetails);
            //if (mdSalesQuotationdetails.Identity.Equals(-1))
            //{

            //   // mdSalesQuotationdetails.ItemID = Convert.ToInt32(itemvalue);

            //}
            //else
            //{

            //  //  _SalesQuotationDetails.Update(mdSalesQuotationdetails);
            //}
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
                case "POCode":
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
