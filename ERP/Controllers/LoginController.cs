using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace ERP.Controllers
{
    [AllowAnonymous]
    [HandleError]
    [ERP.CustomeFilters.LoggingFilter]
    public class LoginController : Controller
    {
        private BusinessLayer.Employee _Employee = new BusinessLayer.Employee();

        public ActionResult Index()
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            var result = false;
            BusinessModels.Login bsUserLogin = new BusinessModels.Login();
            var _loginModule = new LoginModule.Login();
            if (ModelState.IsValid)
                bsUserLogin = _loginModule.AuthenticateUser(formCollection["UserName"], formCollection["Password"]);

            if (bsUserLogin!=null)
            {
                FormsAuthentication.SetAuthCookie(formCollection["UserName"], false);
                BusinessModels.Employee bsEmployee = _Employee.GetEmployeeLoginDetails(bsUserLogin.Identity);

                Session["EmployeeID"] = bsEmployee.Identity;
                Session["LocationID"] = bsUserLogin.LocationID;
                Session["UserName"] = formCollection["UserName"];
                Session["EmployeeCompanyTypeID"] = bsEmployee.CompanyTypeID;
                Session["RoleType"] = bsEmployee.RoleMaster.RoleType;
                Session["CompanyID"] = bsEmployee.CompanyID;
                if (bsEmployee.FloorMaster!=null)
                Session["FloorID"] = bsEmployee.FloorMaster.Identity;

                Session["RoleAccess"] = bsEmployee.RoleMaster.RoleType.RoleAccessID;
                // TempData.Keep();
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }
    }
}
