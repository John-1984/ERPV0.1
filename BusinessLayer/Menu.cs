using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Menu
    {
        private List<BusinessModels.Menu> Menus = new List<BusinessModels.Menu>();
        private DataLayer.MenuDAL _dataLayer = null;

        public Menu()
        {
            _dataLayer = new DataLayer.MenuDAL();
        }

        public BusinessModels.Menu GetMenu(Int32 identity)
        {
            return _dataLayer.GetMenu(identity);
        }
        public BusinessModels.Menu GetMenuByName(String strName)
        {
            return _dataLayer.GetMenuByName(strName);
        }
        public IEnumerable<BusinessModels.Menu> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.Menu> GetAll(int roleID)
        {
            return _dataLayer.GetAll(roleID);
        }

        public IEnumerable<BusinessModels.Menu> GetAllApprovalNeededItems()
        {
            return _dataLayer.GetAllApprovalNeededItems();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Menu Menu)
        {
            return _dataLayer.Update(Menu);
        }

        public Boolean Insert(BusinessModels.Menu Menu)
        {
            return _dataLayer.Insert(Menu);
        }

      

    }


}
