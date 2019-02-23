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
    public class DiscountController : Controller
    {
        private BusinessLayer.Discount _Discount = new BusinessLayer.Discount();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _DiscountAll()
        {
            return PartialView(GetDiscounts("", 1, "", ""));
        }

        [HttpGet]
        public PartialViewResult _DiscountEdit(int identity)
        {
            if (identity.Equals(-1))
            {
                Models.Discount mdDiscount = new Models.Discount();

                mdDiscount.itemList = null;
                mdDiscount.itemList = new SelectList(_Discount.GetAllItemMaster(), "Identity", "ItemName");

               

                TempData["PageInfo"] = "Add Discount Info";
                return PartialView(mdDiscount);
            }
            else
            {
                Models.Discount mdDiscount = AutoMapperConfig.Mapper().Map<Models.Discount>(_Discount.GetDiscount(identity));
                mdDiscount.itemList = null;
                mdDiscount.itemList = new SelectList(_Discount.GetAllItemMaster(), "Identity", "ItemName" , mdDiscount.ItemID);

                TempData["PageInfo"] = "Edit Discount Info";
                TempData.Keep();
                return PartialView(mdDiscount);
            }
        }

        [HttpGet]
        public PartialViewResult _DiscountView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Discount>(_Discount.GetDiscount(identity)));
        }

        [HttpGet]
        public ActionResult _DiscountCancel(int identity)
        {
            return RedirectToAction("_DiscountAll");
        }
        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Discount.Delete(identity);
            return RedirectToAction("_DiscountAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Discount Discount, FormCollection frmFields)
        {
            //IF success resturn grid view
            //IF Failure return json value
            BusinessModels.Discount mdDiscount = AutoMapperConfig.Mapper().Map<BusinessModels.Discount>(Discount);

            var itemvalue = frmFields["hdnItemMaster"];

            if (!String.IsNullOrEmpty(itemvalue))
                mdDiscount.ItemID = int.Parse(itemvalue);

            if (Discount.Identity.Equals(-1))
            {
                mdDiscount.CreatedDate = DateTime.Now;
                _Discount.Insert(mdDiscount);
            }
            else
            {
                mdDiscount.ModifiedDate = DateTime.Now;
                _Discount.Update(mdDiscount);
            }
            return RedirectToAction("_DiscountAll");
        }

        [HttpPost]
        public PartialViewResult DiscountSearch(string searchString, string createdDate = "")
        {
            return PartialView("_DiscountAll", GetDiscounts("", 1, createdDate, searchString));
        }

        public PartialViewResult Sorting(int? page, string sortOrder = "", string createdDate = "", string searchString = "")
        {
            return PartialView("_DiscountAll", GetDiscounts(sortOrder, page, createdDate, searchString));
        }

        private IPagedList<Models.Discount> GetDiscounts(string sortOrder, int? page, string createdDate = "", string searchString = "")
        {

            ViewBag.CreatedDate = string.IsNullOrEmpty(createdDate) ? "" : createdDate;
            ViewBag.SearchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.CurrentSort = string.IsNullOrEmpty(sortOrder) ? "ItemName" : "";

            var Discounts = AutoMapperConfig.Mapper().Map<List<Models.Discount>>(_Discount.GetAll());
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(createdDate))
                Discounts = AutoMapperConfig.Mapper().Map<List<Models.Discount>>(_Discount.GetAll().ToList().FindAll(p => p.ItemMaster.ItemName.ToLower().Contains(searchString.ToLower()) && ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));
            else if (!string.IsNullOrEmpty(searchString))
                Discounts = AutoMapperConfig.Mapper().Map<List<Models.Discount>>(_Discount.GetAll().ToList().FindAll(p => p.ItemMaster.ItemName.ToLower().Contains(searchString.ToLower())));
            else if (!string.IsNullOrEmpty(createdDate))
                Discounts = AutoMapperConfig.Mapper().Map<List<Models.Discount>>(_Discount.GetAll().ToList().FindAll(p => ((DateTime)p.CreatedDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).Equals(createdDate)));

            switch (sortOrder)
            {
                case "ItemName":
                    Discounts = Discounts.OrderByDescending(stu => stu.ItemMaster.ItemName).ToList();
                    break;
                case "DateAsc":
                    Discounts = Discounts.OrderBy(stu => stu.CreatedDate).ToList();
                    break;
                case "DateDesc":
                    Discounts = Discounts.OrderByDescending(stu => stu.CreatedDate).ToList();
                    break;
                default:
                    Discounts = Discounts.OrderBy(stu => stu.ItemMaster.ItemName).ToList();
                    break;
            }

            int Size_Of_Page = 8;  //Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["GridPageSize"].ToString());
            int No_Of_Page = (page ?? 1);
            return Discounts.ToPagedList(No_Of_Page, Size_Of_Page);
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
