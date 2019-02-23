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
    public class TaxController : Controller
    {
        private BusinessLayer.Tax _Tax = new BusinessLayer.Tax();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _TaxAll()
        {
            return PartialView(GetTaxs("", 1, "", ""));
        }
        [HttpGet]
        public ActionResult _TaxCancel(int identity)
        {
            return RedirectToAction("_TaxAll");
        }
        [HttpGet]
        public PartialViewResult _TaxEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.Tax mdTax = new Models.Tax();
                mdTax.ItemList = null;
                mdTax.ItemList = new SelectList(_Tax.GetAllitemMasters(), "Identity", "ItemName");

                

                TempData["PageInfo"] = "Add Tax Info";
                return PartialView(mdTax);
            }
            else
            {
                Models.Tax mdTax = AutoMapperConfig.Mapper().Map<Models.Tax>(_Tax.GetTax(identity));
                mdTax.ItemList = null;
                mdTax.ItemList = new SelectList(_Tax.GetAllitemMasters(), "Identity", "ItemName" , mdTax.ItemID);

                TempData["PageInfo"] = "Edit Tax Info";
                TempData.Keep();
                return PartialView(mdTax);
            }
        }

        [HttpGet]
        public PartialViewResult _TaxView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Tax>(_Tax.GetTax(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Tax.Delete(identity);
            return RedirectToAction("_TaxAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Tax Tax, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.Tax mdTax= AutoMapperConfig.Mapper().Map<BusinessModels.Tax>(Tax);

            var itemvalue = frmFields["hdnItemMaster"];

            if (!String.IsNullOrEmpty(itemvalue))
                mdTax.ItemID = int.Parse(itemvalue);

            if (Tax.Identity.Equals(-1))
            {
                mdTax.CreatedDate = DateTime.Now;
                _Tax.Insert(mdTax);
            }
            else
            {
                mdTax.ModifiedDate = DateTime.Now;
                _Tax.Update(mdTax);
            }
            return RedirectToAction("_TaxAll");
        }

        [HttpPost]
        public PartialViewResult TaxSearch(string searchString, string createdDate = "")
        {
            return PartialView("_TaxAll", GetTaxs("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_TaxAll", GetTaxs(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Tax> GetTaxs(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "ItemName" : "";

            var Taxs = AutoMapperConfig.Mapper().Map<List<Models.Tax>>(_Tax.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                Taxs = AutoMapperConfig.Mapper().Map<List<Models.Tax>>(_Tax.GetAll().ToList().FindAll(p => p.ItemMaster.ItemName.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                Taxs = AutoMapperConfig.Mapper().Map<List<Models.Tax>>(_Tax.GetAll().ToList().FindAll(p => p.ItemMaster.ItemName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                Taxs = AutoMapperConfig.Mapper().Map<List<Models.Tax>>(_Tax.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "ItemName":
                    Taxs = Taxs.OrderByDescending(stu => stu.ItemMaster.ItemName).ToList();
                    break;
                case "DateAsc":
                    Taxs = Taxs.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    Taxs = Taxs.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    Taxs = Taxs.OrderBy(stu => stu.ItemMaster.ItemName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return Taxs.ToPagedList(No_Of_Page, Size_Of_Page);
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
