using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class RoleMasterController : Controller
    {
        private BusinessLayer.RoleMaster _RoleMaster = new BusinessLayer.RoleMaster();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _RoleMasterAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.RoleMaster>>(_RoleMaster.GetAll()));
        }

        public PartialViewResult _RoleMasterEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.RoleMaster());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.RoleMaster>(_RoleMaster.GetRoleMaster(identity)));
        }

        public PartialViewResult _RoleMasterView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.RoleMaster>(_RoleMaster.GetRoleMaster(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _RoleMaster.Delete(identity);
            return RedirectToAction("_RoleMasterAll");
        }

        [HttpPost]
        public ActionResult Update(Models.RoleMaster RoleMaster)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (RoleMaster.Identity.Equals(-1))
            {
                RoleMaster.Identity = GetRandomNumber();
                _RoleMaster.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.RoleMaster>(RoleMaster));
            }
            else
                _RoleMaster.Update(AutoMapperConfig.Mapper().Map<BusinessModels.RoleMaster>(RoleMaster));
            return RedirectToAction("_RoleMasterAll");
        }

        [HttpPost]
        public PartialViewResult RoleMasterSearch(string searchString)
        {
            return PartialView("_RoleMasterAll", AutoMapperConfig.Mapper().Map<List<Models.RoleMaster>>(_RoleMaster.GetAll().ToList().FindAll(p => p.RoleName.ToLower().Contains(searchString.ToLower()))));
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
