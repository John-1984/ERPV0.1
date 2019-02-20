using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Tax
    {

        private List<BusinessModels.Tax> Taxs = new List<BusinessModels.Tax>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.TaxDAL _dataLayer = null;
        private DataLayer.ItemMasterDAL _itedataLayer = null;
        

        public Tax()
        {
            _dataLayer = new DataLayer.TaxDAL();
            _itedataLayer = new DataLayer.ItemMasterDAL();
            
        }

        public BusinessModels.Tax GetTax(Int32 identity)
        {
            return _dataLayer.GetTax(identity);
        }
        public IEnumerable<BusinessModels.ItemMaster> GetAllitemMasters()
        {
            //TestRegionData();
            return _itedataLayer.GetAll();
        }
       
        public IEnumerable<BusinessModels.Tax> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Tax Tax)
        {
            return _dataLayer.Update(Tax);
        }

        public Boolean Insert(BusinessModels.Tax Tax)
        {
            return _dataLayer.Insert(Tax);
        }



    }


}
