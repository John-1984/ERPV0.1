using System;
using System.Collections.Generic;
using System.Linq;

namespace MenuModule
{
    public class Menu
    {
        private BusinessLayer.Menu _menuBL = null;
        public Menu()
        {
            _menuBL = new BusinessLayer.Menu();
        }

        public List<BusinessModels.Menu> GetMenu()
        {
            return _menuBL.GetAll().ToList();
        }

        public List<BusinessModels.Menu> GetMenu(int roleID)
        {
            return _menuBL.GetAll(roleID).ToList();
        }
    }
}