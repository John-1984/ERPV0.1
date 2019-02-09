using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class StateController : Controller
    {
        private BusinessLayer.State _State = new BusinessLayer.State();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _StateAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.State>>(_State.GetAll()));
        }

        public PartialViewResult _StateEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.State());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.State>(_State.GetState(identity)));
        }

        public PartialViewResult _StateView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.State>(_State.GetState(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _State.Delete(identity);
            return RedirectToAction("_StateAll");
        }

        [HttpPost]
        public ActionResult Update(Models.State State)
        {
            //IF success resturn grid view
            //IF Failure return json value
            if (State.Identity.Equals(-1))
            {
                State.Identity = GetRandomNumber();
                _State.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.State>(State));
            }
            else
                _State.Update(AutoMapperConfig.Mapper().Map<BusinessModels.State>(State));
            return RedirectToAction("_StateAll");
        }

        [HttpPost]
        public PartialViewResult StateSearch(string searchString)
        {
            return PartialView("_StateAll", AutoMapperConfig.Mapper().Map<List<Models.State>>(_State.GetAll().ToList().FindAll(p => p.StateName.ToLower().Contains(searchString.ToLower()))));
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
