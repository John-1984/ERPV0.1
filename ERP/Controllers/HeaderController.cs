using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    [ERP.CustomeFilters.AjaxModelValidatorFilter]
    [ERP.CustomeFilters.LoggingFilter]
    [ERP.CustomeFilters.ExceptionFilter]
    public class HeaderController : Controller
    {
        private BusinessLayer.Header _Header = new BusinessLayer.Header();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _HeaderAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.Header>>(_Header.GetAll()));
        }

        public PartialViewResult _HeaderEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.Header());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Header>(_Header.GetHeader(identity)));
        }

        public PartialViewResult _HeaderView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Header>(_Header.GetHeader(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _Header.Delete(identity);
            return RedirectToAction("_HeaderAll");
        }

        [HttpPost]
        public ActionResult Update(Models.Header Header)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (Header.Identity.Equals(-1))
            {
                Header.Identity = GetRandomNumber();
                _Header.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Header>(Header));
            }
            else
                _Header.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Header>(Header));
            return RedirectToAction("_HeaderAll");
        }

        [HttpPost]
        public PartialViewResult HeaderSearch(string searchString)
        {
            return PartialView("_HeaderAll", AutoMapperConfig.Mapper().Map<List<Models.Header>>(_Header.GetAll().ToList().FindAll(p => p.LogoURL.ToLower().Contains(searchString.ToLower()))));
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
