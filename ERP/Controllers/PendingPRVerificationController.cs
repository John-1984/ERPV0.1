﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;
using System.Runtime;
using System.Globalization;

namespace ERP.Controllers
{
    public class PendingPRVerificationController : Controller
    {
        private BusinessLayer.PendingPRVerification _PurchaseRequest = new BusinessLayer.PendingPRVerification();
        private BusinessLayer.PurchaseRequestDetails _PurchaseRequestDetails = new BusinessLayer.PurchaseRequestDetails();
        private BusinessLayer.Employee _Employeee = new BusinessLayer.Employee();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _PendingPRVerificationAll()
        {
            return PartialView(GetPurchaseRequests("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _PendingPRVerificationEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.PurchaseRequest mdPurchaseRequest = new Models.PurchaseRequest();

                mdPurchaseRequest.ProductMasterList = null;
                mdPurchaseRequest.ProductMasterList = new SelectList(_PurchaseRequestDetails.GetAllProductMasters(), "Identity", "ProductName");

                mdPurchaseRequest.VendorList = null;
                mdPurchaseRequest.VendorList = new SelectList(_PurchaseRequestDetails.GetAllVendors(), "Identity", "VendorName");

                mdPurchaseRequest.BrandList = null;
                mdPurchaseRequest.BrandList = new SelectList(_PurchaseRequestDetails.GetAllBrands(), "Identity", "BrandName");

                mdPurchaseRequest.ItemList = null;
                mdPurchaseRequest.ItemList = new SelectList(_PurchaseRequestDetails.GetAllItems(), "Identity", "ItemName");

                TempData["PageInfo"] = "Add PurchaseRequest Info";
                return PartialView(mdPurchaseRequest);
            }
            else
            {
                // Models.PurchaseRequest mdPurchaseRequest = AutoMapperConfig.Mapper().Map<Models.PurchaseRequest>(_PurchaseRequest.GetPurchaseRequest(identity));
                Models.PurchaseRequest mdPurchaseRequest = new Models.PurchaseRequest();
                mdPurchaseRequest.ProductMasterList = null;
                mdPurchaseRequest.ProductMasterList = new SelectList(_PurchaseRequestDetails.GetAllProductMasters(), "Identity", "ProductName");

                mdPurchaseRequest.VendorList = null;
                mdPurchaseRequest.VendorList = new SelectList(_PurchaseRequestDetails.GetAllVendors(), "Identity", "VendorName");

                mdPurchaseRequest.BrandList = null;
                mdPurchaseRequest.BrandList = new SelectList(_PurchaseRequestDetails.GetAllBrands(), "Identity", "BrandName");

                mdPurchaseRequest.ItemList = null;
                mdPurchaseRequest.ItemList = new SelectList(_PurchaseRequestDetails.GetAllItems(), "Identity", "ItemName");

                mdPurchaseRequest.Identity = identity;
                TempData["PageInfo"] = "Edit PurchaseRequest Info";
                TempData.Keep();
                return PartialView(mdPurchaseRequest);
            }
        }

        [HttpGet]
        public PartialViewResult _PendingPRVerificationAdd(int identity)
        {


            if (identity.Equals(-1))
            {
                Models.PurchaseRequest mdPurchaseRequest = new Models.PurchaseRequest();
                mdPurchaseRequest.PurchaseRequestTypeList = null;
                mdPurchaseRequest.PurchaseRequestTypeList = new SelectList(_PurchaseRequest.GetAllPurchaseRequestType(), "Identity", "Name");

                mdPurchaseRequest.EnquiryLevelList = null;
                mdPurchaseRequest.EnquiryLevelList = new SelectList(_PurchaseRequest.GetAllEnquiryLevels(), "Identity", "EnquiryLevelName");

                return PartialView(mdPurchaseRequest);
            }
            else
            {
                Models.PurchaseRequest mdPurchaseRequest = AutoMapperConfig.Mapper().Map<Models.PurchaseRequest>(_PurchaseRequest.GetPurchaseRequest(identity));

                mdPurchaseRequest.PurchaseRequestTypeList = null;
                mdPurchaseRequest.PurchaseRequestTypeList = new SelectList(_PurchaseRequest.GetAllPurchaseRequestType(), "Identity", "Name", mdPurchaseRequest.PurchaseRequestTypeID);

                mdPurchaseRequest.EnquiryLevelList = null;
                mdPurchaseRequest.EnquiryLevelList = new SelectList(_PurchaseRequest.GetAllEnquiryLevels(), "Identity", "EnquiryLevelName", mdPurchaseRequest.EnquiryLevelID);

                return PartialView(mdPurchaseRequest);
            }



        }
        [HttpPost]
        public JsonResult Brand(string identity)
        {
            return Json(new SelectList(_PurchaseRequest.GetAllBrands(identity), "Identity", "BrandName"));
        }

        [HttpPost]
        public JsonResult Vendor(string identity)
        {
            return Json(new SelectList(_PurchaseRequest.GetAllVendors(identity), "Identity", "VendorName"));
        }

        [HttpPost]
        public JsonResult Item(string identity)
        {
            return Json(_PurchaseRequest.GetItemDetails(identity));
        }
        [HttpGet]
        public PartialViewResult _PendingPRVerificationDetailsAdd(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.PurchaseRequest mdPurchaseRequestDetails = new Models.PurchaseRequest();

                mdPurchaseRequestDetails.ProductMasterList = null;
                mdPurchaseRequestDetails.ProductMasterList = new SelectList(_PurchaseRequest.GetAllProductMasters(), "Identity", "ProductName");

                mdPurchaseRequestDetails.VendorList = null;
                mdPurchaseRequestDetails.VendorList = new SelectList(_PurchaseRequest.GetAllVendors(), "Identity", "VendorName");

                mdPurchaseRequestDetails.BrandList = null;
                mdPurchaseRequestDetails.BrandList = new SelectList(_PurchaseRequest.GetAllBrands(), "Identity", "BrandName");

                mdPurchaseRequestDetails.ItemList = null;
                mdPurchaseRequestDetails.ItemList = new SelectList(_PurchaseRequest.GetAllItems(), "Identity", "ItemName");


                TempData["PageInfo"] = "Add PurchaseRequest Info";
                return PartialView(mdPurchaseRequestDetails);
            }
            else
            {
                Models.PurchaseRequest mdPurchaseRequestDetails = new Models.PurchaseRequest();
                           

                mdPurchaseRequestDetails.ProductMasterList = null;
                mdPurchaseRequestDetails.ProductMasterList = new SelectList(_PurchaseRequest.GetAllProductMasters(), "Identity", "ProductName");

                mdPurchaseRequestDetails.VendorList = null;
                mdPurchaseRequestDetails.VendorList = new SelectList(_PurchaseRequest.GetAllVendors(), "Identity", "VendorName");

                mdPurchaseRequestDetails.BrandList = null;
                mdPurchaseRequestDetails.BrandList = new SelectList(_PurchaseRequest.GetAllBrands(), "Identity", "BrandName");

                mdPurchaseRequestDetails.ItemList = null;
                mdPurchaseRequestDetails.ItemList = new SelectList(_PurchaseRequest.GetAllItems(), "Identity", "ItemName");

                // mdPurchaseRequestDetails.PurchaseRequestID = identity;

                TempData["PageInfo"] = "Edit PurchaseRequest Info";
                TempData.Keep();
                return PartialView(mdPurchaseRequestDetails);
            }
        }

        [HttpGet]
        public ActionResult _PendingPRVerificationCancel(int identity)
        {
            return RedirectToAction("_PendingPRVerificationAll");
        }
        [HttpGet]
        public PartialViewResult _PendingPRVerificationView(int identity)
        {
            BusinessModels.PurchaseRequest bsPurchaseRequest = _PurchaseRequest.GetPurchaseRequest(identity);
            Models.PurchaseRequest mdPurchaseRequest = AutoMapperConfig.Mapper().Map<Models.PurchaseRequest>(bsPurchaseRequest);
           
            List<Models.PurchaseRequestDetails> lstpurchaseRequestDetails = new List<Models.PurchaseRequestDetails>();
            foreach (BusinessModels.PurchaseRequestDetails item in bsPurchaseRequest.PurchaseRequestDetails)
            {
                Models.PurchaseRequestDetails mdPurchaseRequest1 = AutoMapperConfig.Mapper().Map<Models.PurchaseRequestDetails>(item);
                BusinessModels.ItemMaster bmItem = _PurchaseRequest.GetItemDetails(Convert.ToString(mdPurchaseRequest1.ItemID));
                Models.ItemMaster mdItem = AutoMapperConfig.Mapper().Map<Models.ItemMaster>(bmItem);
                mdPurchaseRequest1.ItemMaster = mdItem;
                lstpurchaseRequestDetails.Add(mdPurchaseRequest1);
            }

            mdPurchaseRequest.PurchaseRequestDetails = lstpurchaseRequestDetails;

            return PartialView(mdPurchaseRequest);
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            BusinessModels.PurchaseRequest mdRequest = _PurchaseRequest.GetPurchaseRequest(identity);
            mdRequest.IsActive = false;
            _PurchaseRequest.Update(mdRequest);
            return RedirectToAction("_PendingPRVerificationAll");
        }

        [HttpPost]
        public ActionResult DeleteItem(int identity)
        {

            _PurchaseRequestDetails.Delete(identity);
            return RedirectToAction("_PendingPRVerificationAll");
        }


        [HttpPost]
        public ActionResult _PendingPRVerificationProcessVerification(int identity)
        {
            BusinessModels.PurchaseRequest mdProductenq = _PurchaseRequest.GetPurchaseRequest(identity);

            BusinessModels.Employee mdemployee = _Employeee.GetSupervisorOnWareHouseCompanyType(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["CompanyID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeCompanyTypeID"])));
            if (mdemployee != null)
            {
                mdProductenq.AssignedTo = mdemployee.Identity;
                //coded
                mdProductenq.POStatus = 15;
            }
            //_PurchaseRequest.Delete(identity);
            return RedirectToAction("_PendingPRVerificationAll");
        }

        [HttpPost]
        public ActionResult Update(Models.PurchaseRequest PurchaseRequest, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value

            BusinessModels.PurchaseRequestDetails mdPurchaseRequestdetails = new BusinessModels.PurchaseRequestDetails();
            var itemvalue = frmFields["hdnItem"];
            var itemQty = frmFields["Quantity"];
            var purpose = frmFields["Purpose"];

            if (!String.IsNullOrEmpty(itemvalue))
                mdPurchaseRequestdetails.ItemID = int.Parse(itemvalue);

            mdPurchaseRequestdetails.PurchaseRequestID = Convert.ToInt32(frmFields["Identity"]);
            mdPurchaseRequestdetails.Quantity = Convert.ToInt32(itemQty);
            mdPurchaseRequestdetails.Purpose = Convert.ToString(purpose);

            _PurchaseRequestDetails.Insert(mdPurchaseRequestdetails);
           
            return RedirectToAction("_PendingPRVerificationAll");
        }

        [HttpPost]
        public ActionResult ManagePendingPRVerification(Models.PurchaseRequest PurchaseRequest, FormCollection frmFields)
        {
            //Code for purchase request edit
            BusinessModels.PurchaseRequest mdPurchaseRequest = AutoMapperConfig.Mapper().Map<BusinessModels.PurchaseRequest>(PurchaseRequest);

            //coded
            mdPurchaseRequest.LocationID = Convert.ToInt32(Convert.ToString(Session["LocationID"]));
            mdPurchaseRequest.CompanyTypeID = Convert.ToInt32(Convert.ToString(Session["EmployeeCompanyTypeID"]));
            mdPurchaseRequest.POStatus = 1;
            mdPurchaseRequest.IsActive = true;
            mdPurchaseRequest.IsVerified = false;

            var hdnPurchaseType = frmFields["hdnpurReqType"];
            if (!String.IsNullOrEmpty(hdnPurchaseType))
                mdPurchaseRequest.PurchaseRequestTypeID = Convert.ToInt32(hdnPurchaseType);

            var hdnenqlvel = frmFields["hdnporequestenqlvel"];
            if (!String.IsNullOrEmpty(hdnenqlvel))
                mdPurchaseRequest.EnquiryLevelID = Convert.ToInt32(hdnenqlvel);

            if (PurchaseRequest.Identity.Equals(-1))
            {
                mdPurchaseRequest.IsVerified = false;
                mdPurchaseRequest.IsApproved = false;
                mdPurchaseRequest.CreatedDate = DateTime.Now;
                mdPurchaseRequest.CreatedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
                mdPurchaseRequest.AssignedTo = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
                mdPurchaseRequest.OriginatorID = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
                _PurchaseRequest.Insert(mdPurchaseRequest);
            }
            else
            {
                mdPurchaseRequest.ModifiedBy = Convert.ToInt32(Convert.ToString(Session["EmployeeID"]));
                mdPurchaseRequest.ModifiedDate = DateTime.Now;
                _PurchaseRequest.Update(mdPurchaseRequest);
            }
            return RedirectToAction("_PendingPRVerificationAll");
        }

        [HttpPost]
        public PartialViewResult PendingPRVerificationSearch(string searchString, string createdDate = "")
        {
            return PartialView("_PendingPRVerificationAll", GetPurchaseRequests("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_PendingPRVerificationAll", GetPurchaseRequests(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.PurchaseRequest> GetPurchaseRequests(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "POCode" : "";

            var PurchaseRequests = new List<Models.PurchaseRequest>();

            //coded
            if (Convert.ToString(Session["RoleAccess"]) == "1")
                PurchaseRequests = AutoMapperConfig.Mapper().Map<List<Models.PurchaseRequest>>(_PurchaseRequest.GetAllPendingVerificationPR());
            else if (Convert.ToString(Session["RoleAccess"]) == "2")
                PurchaseRequests = AutoMapperConfig.Mapper().Map<List<Models.PurchaseRequest>>(_PurchaseRequest.GetAllPendingVerificationPR(Convert.ToInt32(Convert.ToString(Session["LocationID"]))));
            else if (Convert.ToString(Session["RoleAccess"]) == "3")
                PurchaseRequests = AutoMapperConfig.Mapper().Map<List<Models.PurchaseRequest>>(_PurchaseRequest.GetAllPendingVerificationPR(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeID"]))));


            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                PurchaseRequests = AutoMapperConfig.Mapper().Map<List<Models.PurchaseRequest>>(_PurchaseRequest.GetAllPendingVerificationPR().ToList().FindAll(p => p.POCode.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                PurchaseRequests = AutoMapperConfig.Mapper().Map<List<Models.PurchaseRequest>>(_PurchaseRequest.GetAllPendingVerificationPR().ToList().FindAll(p => p.POCode.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                PurchaseRequests = AutoMapperConfig.Mapper().Map<List<Models.PurchaseRequest>>(_PurchaseRequest.GetAllPendingVerificationPR().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "POCode":
                    PurchaseRequests = PurchaseRequests.OrderByDescending(stu => stu.POCode).ToList();
                    break;
                case "DateAsc":
                    PurchaseRequests = PurchaseRequests.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    PurchaseRequests = PurchaseRequests.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    PurchaseRequests = PurchaseRequests.OrderBy(stu => stu.POCode).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return PurchaseRequests.ToPagedList(No_Of_Page, Size_Of_Page);
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
