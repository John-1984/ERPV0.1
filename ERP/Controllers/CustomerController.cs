using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class CustomerController : Controller
    {
        private BusinessLayer.Customer _customer = new BusinessLayer.Customer();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _CustomerAll()
        {
            return PartialView(AutoMapperConfig.Mapper().Map<List<Models.Customer>>(_customer.GetAll()));
        }

        public PartialViewResult _CustomerEdit(int identity)
        {
            if (identity.Equals(-1))
                return PartialView(new Models.Customer());
            else
                return PartialView(AutoMapperConfig.Mapper().Map<Models.Customer>(_customer.GetCustomer(identity)));
            }

        public PartialViewResult _CustomerView(int identity)
        {
            return PartialView(AutoMapperConfig.Mapper().Map<Models.Customer>(_customer.GetCustomer(identity)));
        }

        [HttpPost]
        public ActionResult Delete(int identity)
        {
            _customer.Delete(identity);
            return RedirectToAction("_CustomerAll");
        }  

        [HttpPost]
        public ActionResult Update(Models.Customer customer){
            //IF success resturn grid view
            //IF Failure return json value
            if (customer.Identity.Equals(-1))
            {
                customer.Identity = GetRandomNumber();
                _customer.Insert(AutoMapperConfig.Mapper().Map<BusinessModels.Customer>(customer));
            }
            else
                _customer.Update(AutoMapperConfig.Mapper().Map<BusinessModels.Customer>(customer));
            return RedirectToAction("_CustomerAll");
        }

        [HttpPost]
        public PartialViewResult CustomerSearch(string searchString){
            return PartialView("_CustomerAll", AutoMapperConfig.Mapper().Map<List<Models.Customer>>(_customer.GetAll().ToList().FindAll(p => p.CustomerName.ToLower().Contains(searchString.ToLower()))));
        }

        //Function to get random number
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min=0, int max=1000)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

    }
}
