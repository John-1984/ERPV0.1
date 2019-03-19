using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        public PartialViewResult Index()
        {
            MenuModule.Menu menu = new MenuModule.Menu();

            var lstMenu =new List<Models.Menu>();

            if (Session["RoleID"]!=null)
            lstMenu = AutoMapperConfig.Mapper().Map<List<Models.Menu>>(menu.GetMenu(int.Parse(Session["RoleID"].ToString())));
            else
            lstMenu = AutoMapperConfig.Mapper().Map<List<Models.Menu>>(menu.GetMenu());


            var grouped = lstMenu.GroupBy(p => p.Modules.ModuleName).ToList();

            //To get menu based on Role, use the below overloaded method with roleID as parameter
            //var est = menu.GetMenu(1);
            return PartialView(grouped);
        }
    }
}