using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class SalesRoleTypeController : Controller
    {
        private BusinessLayer.SalesRoleType _SalesRoleType = new BusinessLayer.SalesRoleType();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _SalesRoleTypeAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.SalesRoleType>>(_SalesRoleType.GetAll()));
        }

        public PartialViewResult _SalesRoleTypeEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.SalesRoleType());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.SalesRoleType>(_SalesRoleType.GetSalesRoleType(identity)));
        }

        public PartialViewResult _SalesRoleTypeView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.SalesRoleType>(_SalesRoleType.GetSalesRoleType(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _SalesRoleType.Delete(identity);
            return RedirectToAction("_SalesRoleTypeAll");
        }

        [HttpPost]
        public ActionResult Update(Models.SalesRoleType SalesRoleType)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (SalesRoleType.Identity.Equals(-1))
            {
                SalesRoleType.Identity = GetRandomNumber();
                _SalesRoleType.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.SalesRoleType>(SalesRoleType));
            }
            else
                _SalesRoleType.Update(AutoMapperConfig.Mapper().Map<BusinessModels.SalesRoleType>(SalesRoleType));
            return RedirectToAction("_SalesRoleTypeAll");
        }

        [HttpPost]
        public PartialViewResult SalesRoleTypeSearch(string searchString)
        {
            return PartialView("_SalesRoleTypeAll", AutoMapperConfig.Mapper().Map<List<Models.SalesRoleType>>(_SalesRoleType.GetAll().ToList().FindAll(p => p.TypeName.ToLower().Contains(searchString.ToLower()))));
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
