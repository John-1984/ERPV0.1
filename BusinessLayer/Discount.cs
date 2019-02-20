using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Discount
    {

        private List<BusinessModels.Discount> Discounts = new List<BusinessModels.Discount>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.DiscountDAL _dataLayer = null;
        private DataLayer.ItemMasterDAL _itemdataLayer = null;
       

        public Discount()
        {
            _dataLayer = new DataLayer.DiscountDAL();
            _itemdataLayer = new DataLayer.ItemMasterDAL();
           
        }

        public BusinessModels.Discount GetDiscount(Int32 identity)
        {
            return _dataLayer.GetDiscount(identity);
        }
        public IEnumerable<BusinessModels.ItemMaster> GetAllItemMaster()
        {
            //TestRegionData();
            return _itemdataLayer.GetAll();
        }
       
        public IEnumerable<BusinessModels.Discount> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Discount Discount)
        {
            return _dataLayer.Update(Discount);
        }

        public Boolean Insert(BusinessModels.Discount Discount)
        {
            return _dataLayer.Insert(Discount);
        }



    }


}
