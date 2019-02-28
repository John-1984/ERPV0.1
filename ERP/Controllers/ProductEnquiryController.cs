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
    public class ProductEnquiryController : Controller
    {
        private BusinessLayer.ProductEnquiry _ProductEnquiry = new BusinessLayer.ProductEnquiry();
        private BusinessLayer.ProductEnquiryDetails _ProductEnquiryDetails = new BusinessLayer.ProductEnquiryDetails();
        private BusinessLayer.Employee _Employeee = new BusinessLayer.Employee();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _ProductEnquiryAll()
        {
            return PartialView(GetProductEnquirys("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _ProductEnquiryEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.ProductEnquiry mdProductEnquiry = new Models.ProductEnquiry();

                mdProductEnquiry.ProductMasterList = null;
                mdProductEnquiry.ProductMasterList = new SelectList(_ProductEnquiryDetails.GetAllProductMasters(), "Identity", "ProductName");

                mdProductEnquiry.VendorList = null;
                mdProductEnquiry.VendorList = new SelectList(_ProductEnquiryDetails.GetAllVendors(), "Identity", "VendorName");

                mdProductEnquiry.BrandList = null;
                mdProductEnquiry.BrandList = new SelectList(_ProductEnquiryDetails.GetAllBrands(), "Identity", "BrandName");

                mdProductEnquiry.ItemList = null;
                mdProductEnquiry.ItemList = new SelectList(_ProductEnquiryDetails.GetAllItems(), "Identity", "ItemName");

                TempData["PageInfo"] = "Add ProductEnquiry Info";
                return PartialView(mdProductEnquiry);
            }
            else
            {
                // Models.ProductEnquiry mdProductEnquiry = AutoMapperConfig.Mapper().Map<Models.ProductEnquiry>(_ProductEnquiry.GetProductEnquiry(identity));
                Models.ProductEnquiry mdProductEnquiry = new Models.ProductEnquiry();
                mdProductEnquiry.ProductMasterList = null;
                mdProductEnquiry.ProductMasterList = new SelectList(_ProductEnquiryDetails.GetAllProductMasters(), "Identity", "ProductName");

                mdProductEnquiry.VendorList = null;
                mdProductEnquiry.VendorList = new SelectList(_ProductEnquiryDetails.GetAllVendors(), "Identity", "VendorName");

                mdProductEnquiry.BrandList = null;
                mdProductEnquiry.BrandList = new SelectList(_ProductEnquiryDetails.GetAllBrands(), "Identity", "BrandName");

                mdProductEnquiry.ItemList = null;
                mdProductEnquiry.ItemList = new SelectList(_ProductEnquiryDetails.GetAllItems(), "Identity", "ItemName");
                mdProductEnquiry.Identity = identity;
                TempData["PageInfo"] = "Edit ProductEnquiry Info";
                TempData.Keep();
                return PartialView(mdProductEnquiry);
            }
        }
        [HttpPost]
        public JsonResult Brand(string identity)
        {
            return Json(new SelectList(_ProductEnquiry.GetAllBrands(identity), "Identity", "BrandName"));
        }

        [HttpPost]
        public JsonResult Vendor(string identity)
        {
            return Json(new SelectList(_ProductEnquiry.GetAllVendors(identity), "Identity", "VendorName"));
        }

        [HttpPost]
        public JsonResult Item(string identity)
        {
            return Json(_ProductEnquiry.GetItemDetails(identity));
        }
        [HttpGet]
        public PartialViewResult _ProductEnquiryDetailsAdd(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.ProductEnquiry mdProductEnquiryDetails = new Models.ProductEnquiry();

                mdProductEnquiryDetails.ProductMasterList = null;
                mdProductEnquiryDetails.ProductMasterList = new SelectList(_ProductEnquiry.GetAllProductMasters(), "Identity", "ProductName");

                mdProductEnquiryDetails.VendorList = null;
                mdProductEnquiryDetails.VendorList = new SelectList(_ProductEnquiry.GetAllVendors(), "Identity", "VendorName");

                mdProductEnquiryDetails.BrandList = null;
                mdProductEnquiryDetails.BrandList = new SelectList(_ProductEnquiry.GetAllBrands(), "Identity", "BrandName");

                mdProductEnquiryDetails.ItemList = null;
                mdProductEnquiryDetails.ItemList = new SelectList(_ProductEnquiry.GetAllItems(), "Identity", "ItemName");


                TempData["PageInfo"] = "Add ProductEnquiry Info";
                return PartialView(mdProductEnquiryDetails);
            }
            else
            {
                Models.ProductEnquiry mdProductEnquiryDetails = new Models.ProductEnquiry();

                //Models.ProductEnquiryDetails mdProductEnquiryDetails = AutoMapperConfig.Mapper().Map<Models.ProductEnquiryDetails>(_ProductEnquiry.GetProductEnquiryDetails(identity));

                //mdProductEnquiryDetails.ProductMasterList = null;
                //mdProductEnquiryDetails.ProductMasterList = new SelectList(_ProductEnquiry.GetAllProductMasters(), "Identity", "ProductName", mdProductEnquiryDetails.ItemMaster.Brand.Vendor.ProductMasterID);

                //mdProductEnquiryDetails.VendorList = null;
                //mdProductEnquiryDetails.VendorList = new SelectList(_ProductEnquiry.GetAllVendors(Convert.ToString(mdProductEnquiryDetails.ItemMaster.Brand.Vendor.ProductMasterID)), "Identity", "VendorName", mdProductEnquiryDetails.ItemMaster.Brand.VendorID) ;

                //mdProductEnquiryDetails.BrandList = null;
                //mdProductEnquiryDetails.BrandList = new SelectList(_ProductEnquiry.GetAllBrands(Convert.ToString(mdProductEnquiryDetails.ItemMaster.Brand.VendorID)), "Identity", "BrandName", mdProductEnquiryDetails.ItemMaster.BrandID);

                //mdProductEnquiryDetails.ItemList = null;
                //mdProductEnquiryDetails.ItemList = new SelectList(_ProductEnquiry.GetItemMasters(Convert.ToString(mdProductEnquiryDetails.ItemMaster.BrandID)), "Identity", "ItemName",mdProductEnquiryDetails.ItemID);

                mdProductEnquiryDetails.ProductMasterList = null;
                mdProductEnquiryDetails.ProductMasterList = new SelectList(_ProductEnquiry.GetAllProductMasters(), "Identity", "ProductName");

                mdProductEnquiryDetails.VendorList = null;
                mdProductEnquiryDetails.VendorList = new SelectList(_ProductEnquiry.GetAllVendors(), "Identity", "VendorName");

                mdProductEnquiryDetails.BrandList = null;
                mdProductEnquiryDetails.BrandList = new SelectList(_ProductEnquiry.GetAllBrands(), "Identity", "BrandName");

                mdProductEnquiryDetails.ItemList = null;
                mdProductEnquiryDetails.ItemList = new SelectList(_ProductEnquiry.GetAllItems(), "Identity", "ItemName");

               // mdProductEnquiryDetails.ProductEnquiryID = identity;

               TempData["PageInfo"] = "Edit ProductEnquiry Info";
                TempData.Keep();
                return PartialView(mdProductEnquiryDetails);
            }
        }

        [HttpGet]
        public ActionResult _ProductEnquiryCancel(int identity)
        {
            return RedirectToAction("_ProductEnquiryAll");
        }
        [HttpGet]
        public PartialViewResult _ProductEnquiryView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.ProductEnquiry>(_ProductEnquiry.GetProductEnquiry(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _ProductEnquiry.Delete(identity);
            return RedirectToAction("_ProductEnquiryAll");
        }

        [HttpPost]
        public ActionResult _ProductEnquiryProcessVerification(int identity)
        {
            BusinessModels.ProductEnquiry mdProductenq = _ProductEnquiry.GetProductEnquiry(identity);

            BusinessModels.Employee mdemployee = _Employeee.GetStoreRoomManagerOnCompanyType(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["CompanyID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeCompanyTypeID"])));
            if (mdemployee != null)
            {
                mdProductenq.AssignedTo = mdemployee.Identity;
                //coded
                mdProductenq.StatusID = 15;
            }
            //_ProductEnquiry.Delete(identity);
            return RedirectToAction("_ProductEnquiryAll");
        }

        [HttpPost]
        public ActionResult Update(Models.ProductEnquiry ProductEnquiry, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value

            BusinessModels.ProductEnquiryDetails mdProductEnquirydetails = new BusinessModels.ProductEnquiryDetails();
            var itemvalue = frmFields["hdnItem"];
            var itemQty = frmFields["Quantity"];
            var itemPrice = frmFields["ItemPrice"];
            var itemSize = frmFields["Size"];

            if (!String.IsNullOrEmpty(itemvalue))
                mdProductEnquirydetails.ItemID = int.Parse(itemvalue);

            mdProductEnquirydetails.ProductEnquiryID = Convert.ToInt32(frmFields["Identity"]);
            mdProductEnquirydetails.ItemPrice = Convert.ToDecimal(itemPrice);
            mdProductEnquirydetails.Quantity = Convert.ToInt32(itemQty);
            mdProductEnquirydetails.Size = Convert.ToString(itemSize);

            _ProductEnquiryDetails.Insert(mdProductEnquirydetails);
            //if (mdProductEnquirydetails.Identity.Equals(-1))
            //{
               
            //   // mdProductEnquirydetails.ItemID = Convert.ToInt32(itemvalue);
               
            //}
            //else
            //{

            //  //  _ProductEnquiryDetails.Update(mdProductEnquirydetails);
            //}
            return RedirectToAction("_ProductEnquiryAll");
        }

        [HttpPost]
        public PartialViewResult ProductEnquirySearch(string searchString, string createdDate = "")
        {
            return PartialView("_ProductEnquiryAll", GetProductEnquirys("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_ProductEnquiryAll", GetProductEnquirys(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.ProductEnquiry> GetProductEnquirys(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "CustomerName" : "";

            var ProductEnquirys = new List<Models.ProductEnquiry>();

            if (Convert.ToString(Session["RoleAccess"]) == "1")
                ProductEnquirys = AutoMapperConfig.Mapper().Map<List<Models.ProductEnquiry>>(_ProductEnquiry.GetAll());
            else if (Convert.ToString(Session["RoleAccess"]) == "2")
                ProductEnquirys = AutoMapperConfig.Mapper().Map<List<Models.ProductEnquiry>>(_ProductEnquiry.GetAll(Convert.ToInt32(Convert.ToString(Session["LocationID"]))));
            else if (Convert.ToString(Session["RoleAccess"]) == "3")
                ProductEnquirys = AutoMapperConfig.Mapper().Map<List<Models.ProductEnquiry>>(_ProductEnquiry.GetAll(Convert.ToInt32(Convert.ToString(Session["LocationID"])), Convert.ToInt32(Convert.ToString(Session["EmployeeID"]))));

            
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                ProductEnquirys = AutoMapperConfig.Mapper().Map<List<Models.ProductEnquiry>>(_ProductEnquiry.GetAll().ToList().FindAll(p => p.Customer.CustomerName.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                ProductEnquirys = AutoMapperConfig.Mapper().Map<List<Models.ProductEnquiry>>(_ProductEnquiry.GetAll().ToList().FindAll(p => p.Customer.CustomerName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                ProductEnquirys = AutoMapperConfig.Mapper().Map<List<Models.ProductEnquiry>>(_ProductEnquiry.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "CustomerName":
                    ProductEnquirys = ProductEnquirys.OrderByDescending(stu => stu.Customer.CustomerName).ToList();
                    break;
                case "DateAsc":
                    ProductEnquirys = ProductEnquirys.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    ProductEnquirys = ProductEnquirys.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    ProductEnquirys = ProductEnquirys.OrderBy(stu => stu.Customer.CustomerName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return ProductEnquirys.ToPagedList(No_Of_Page, Size_Of_Page);
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
