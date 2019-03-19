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
    public class WarrantyController : Controller
    {
        private BusinessLayer.Warranty _Warranty = new BusinessLayer.Warranty();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _WarrantyAll()
        {
            return PartialView(GetWarrantys("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _WarrantyEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.Warranty mdWarranty = new Models.Warranty();
                mdWarranty.ItemList = null;
                mdWarranty.ItemList = new SelectList(_Warranty.GetAllitemMasters(), "Identity", "ItemName");



                TempData["PageInfo"] = "Add Warranty Info";
                return PartialView(mdWarranty);
            }
            else
            {
                Models.Warranty mdWarranty = AutoMapperConfig.Mapper().Map<Models.Warranty>(_Warranty.GetWarranty(identity));
                mdWarranty.ItemList = null;
                mdWarranty.ItemList = new SelectList(_Warranty.GetAllitemMasters(), "Identity", "ItemName");

                TempData["PageInfo"] = "Edit Warranty Info";
                TempData.Keep();
                return PartialView(mdWarranty);
            }
        }

        [HttpGet]
        public PartialViewResult _WarrantyView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Warranty>(_Warranty.GetWarranty(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Warranty.Delete(identity);
            return RedirectToAction("_WarrantyAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Warranty Warranty)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (Warranty.Identity.Equals(-1))
            {
                _Warranty.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Warranty>(Warranty));
            }
            else
                _Warranty.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Warranty>(Warranty));
            return RedirectToAction("_WarrantyAll");
        }

        [HttpPost]
        public PartialViewResult WarrantySearch(string searchString, string createdDate = "")
        {
            return PartialView("_WarrantyAll", GetWarrantys("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_WarrantyAll", GetWarrantys(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Warranty> GetWarrantys(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "ItemName" : "";

            var Warrantys = AutoMapperConfig.Mapper().Map<List<Models.Warranty>>(_Warranty.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                Warrantys = AutoMapperConfig.Mapper().Map<List<Models.Warranty>>(_Warranty.GetAll().ToList().FindAll(p => p.ItemName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                Warrantys = AutoMapperConfig.Mapper().Map<List<Models.Warranty>>(_Warranty.GetAll().ToList().FindAll(p => p.ItemName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                Warrantys = AutoMapperConfig.Mapper().Map<List<Models.Warranty>>(_Warranty.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "ItemName":
                    Warrantys = Warrantys.OrderByDescending(stu => stu.ItemName).ToList();
                    break;
                case "DateAsc":
                    Warrantys = Warrantys.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    Warrantys = Warrantys.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    Warrantys = Warrantys.OrderBy(stu => stu.ItemName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return Warrantys.ToPagedList(No_Of_Page, Size_Of_Page);
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
