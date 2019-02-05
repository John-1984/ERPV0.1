using System.Web.Mvc;
using System.Web.Security;

namespace ERP.Controllers
{
    [AllowAnonymous]
    [HandleError]  
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            var result = false;
            var _loginModule = new LoginModule.Login();
            if (ModelState.IsValid)
                result = _loginModule.AuthenticateUser(formCollection["UserName"], formCollection["Password"]);

            if (result)
            {
                FormsAuthentication.SetAuthCookie(formCollection["UserName"], false);
                TempData["UserName"] = formCollection["UserName"];
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }
    }
}
