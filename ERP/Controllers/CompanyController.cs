using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class CompanyController : Controller
    {
        private BusinessLayer.Company _Company = new BusinessLayer.Company();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _CompanyAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.Company>>(_Company.GetAll()));
        }

        public PartialViewResult _CompanyEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.Company());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Company>(_Company.GetCompany(identity)));
        }

        public PartialViewResult _CompanyView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Company>(_Company.GetCompany(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Company.Delete(identity);
            return RedirectToAction("_CompanyAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Company Company)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (Company.Identity.Equals(-1))
            {
                Company.Identity = GetRandomNumber();
                _Company.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Company>(Company));
            }
            else
                _Company.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Company>(Company));
            return RedirectToAction("_CompanyAll");
        }

        [HttpPost]
        public PartialViewResult CompanySearch(string searchString)
        {
            return PartialView("_CompanyAll", AutoMapperConfig.Mapper().Map<List<Models.Company>>(_Company.GetAll().ToList().FindAll(p => p.StoreName.ToLower().Contains(searchString.ToLower()))));
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
