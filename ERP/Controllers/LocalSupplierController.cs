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
    public class LocalSupplierController : Controller
    {
        private BusinessLayer.LocalSupplier _LocalSupplier = new BusinessLayer.LocalSupplier();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _LocalSupplierAll()
        {
            return PartialView(GetLocalSuppliers("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _LocalSupplierEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.LocalSupplier mdLocalSupplier = new Models.LocalSupplier();
                mdLocalSupplier.ItemList = null;
                mdLocalSupplier.ItemList = new SelectList(_LocalSupplier.GetAllItemMaster(), "Identity", "ItemName");

                mdLocalSupplier.LocationList = null;
                mdLocalSupplier.LocationList = new SelectList(_LocalSupplier.GetAlllocations(), "Identity", "LocationName");


                TempData["PageInfo"] = "Add LocalSupplier Info";
                return PartialView(mdLocalSupplier);
            }
            else
            {
                Models.LocalSupplier mdLocalSupplier = AutoMapperConfig.Mapper().Map<Models.LocalSupplier>(_LocalSupplier.GetLocalSupplier(identity));
                mdLocalSupplier.ItemList = null;
                mdLocalSupplier.ItemList = new SelectList(_LocalSupplier.GetAllItemMaster(), "Identity", "ItemName");

                mdLocalSupplier.LocationList = null;
                mdLocalSupplier.LocationList = new SelectList(_LocalSupplier.GetAlllocations(), "Identity", "LocationName");


                TempData["PageInfo"] = "Edit LocalSupplier Info";
                TempData.Keep();
                return PartialView(mdLocalSupplier);
            }
        }

        [HttpGet]
        public PartialViewResult _LocalSupplierView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.LocalSupplier>(_LocalSupplier.GetLocalSupplier(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _LocalSupplier.Delete(identity);
            return RedirectToAction("_LocalSupplierAll");
        }

        [HttpPost]
        public ActionResult Update(Models.LocalSupplier LocalSupplier)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (LocalSupplier.Identity.Equals(-1))
            {
                _LocalSupplier.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.LocalSupplier>(LocalSupplier));
            }
            else
                _LocalSupplier.Update(AutoMapperConfig.Mapper().Map<BusinessModels.LocalSupplier>(LocalSupplier));
            return RedirectToAction("_LocalSupplierAll");
        }

        [HttpPost]
        public PartialViewResult LocalSupplierSearch(string searchString, string createdDate = "")
        {
            return PartialView("_LocalSupplierAll", GetLocalSuppliers("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_LocalSupplierAll", GetLocalSuppliers(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.LocalSupplier> GetLocalSuppliers(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "SupplierName" : "";

            var LocalSuppliers = AutoMapperConfig.Mapper().Map<List<Models.LocalSupplier>>(_LocalSupplier.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                LocalSuppliers = AutoMapperConfig.Mapper().Map<List<Models.LocalSupplier>>(_LocalSupplier.GetAll().ToList().FindAll(p => p.SupplierName.ToLower().Contains(searchString.ToLower()) && p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                LocalSuppliers = AutoMapperConfig.Mapper().Map<List<Models.LocalSupplier>>(_LocalSupplier.GetAll().ToList().FindAll(p => p.SupplierName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                LocalSuppliers = AutoMapperConfig.Mapper().Map<List<Models.LocalSupplier>>(_LocalSupplier.GetAll().ToList().FindAll(p => p.CreatedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "SupplierName":
                    LocalSuppliers = LocalSuppliers.OrderByDescending(stu => stu.SupplierName).ToList();
                    break;
                case "DateAsc":
                    LocalSuppliers = LocalSuppliers.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    LocalSuppliers = LocalSuppliers.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    LocalSuppliers = LocalSuppliers.OrderBy(stu => stu.SupplierName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return LocalSuppliers.ToPagedList(No_Of_Page, Size_Of_Page);
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
