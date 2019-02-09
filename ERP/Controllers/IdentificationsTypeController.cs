using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class IdentificationsTypeController : Controller
    {
        private BusinessLayer.IdentificationsType _IdentificationsType = new BusinessLayer.IdentificationsType();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _IdentificationsTypeAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.IdentificationsType>>(_IdentificationsType.GetAll()));
        }

        public PartialViewResult _IdentificationsTypeEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.IdentificationsType());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.IdentificationsType>(_IdentificationsType.GetIdentificationsType(identity)));
        }

        public PartialViewResult _IdentificationsTypeView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.IdentificationsType>(_IdentificationsType.GetIdentificationsType(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _IdentificationsType.Delete(identity);
            return RedirectToAction("_IdentificationsTypeAll");
        }

        [HttpPost]
        public ActionResult Update(Models.IdentificationsType IdentificationsType)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (IdentificationsType.Identity.Equals(-1))
            {
                IdentificationsType.Identity = GetRandomNumber();
                _IdentificationsType.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.IdentificationsType>(IdentificationsType));
            }
            else
                _IdentificationsType.Update(AutoMapperConfig.Mapper().Map<BusinessModels.IdentificationsType>(IdentificationsType));
            return RedirectToAction("_IdentificationsTypeAll");
        }

        [HttpPost]
        public PartialViewResult IdentificationsTypeSearch(string searchString)
        {
            return PartialView("_IdentificationsTypeAll", AutoMapperConfig.Mapper().Map<List<Models.IdentificationsType>>(_IdentificationsType.GetAll().ToList().FindAll(p => p.IdentificationName.ToLower().Contains(searchString.ToLower()))));
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
