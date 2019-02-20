using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Warranty
    {

        private List<BusinessModels.Warranty> Warrantys = new List<BusinessModels.Warranty>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.WarrantyDAL _dataLayer = null;
        private DataLayer.ItemMasterDAL _itedataLayer = null;


        public Warranty()
        {
            _dataLayer = new DataLayer.WarrantyDAL();
            _itedataLayer = new DataLayer.ItemMasterDAL();

        }

        public BusinessModels.Warranty GetWarranty(Int32 identity)
        {
            return _dataLayer.GetWarranty(identity);
        }
        public IEnumerable<BusinessModels.ItemMaster> GetAllitemMasters()
        {
            //TestRegionData();
            return _itedataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.Warranty> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Warranty Warranty)
        {
            return _dataLayer.Update(Warranty);
        }

        public Boolean Insert(BusinessModels.Warranty Warranty)
        {
            return _dataLayer.Insert(Warranty);
        }



    }


}
