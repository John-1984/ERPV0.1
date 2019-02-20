using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class LocalSupplier
    {

        private List<BusinessModels.LocalSupplier> LocalSuppliers = new List<BusinessModels.LocalSupplier>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.LocalSupplierDAL _dataLayer = null;
        private DataLayer.ItemMasterDAL _itemdataLayer = null;
        private DataLayer.LocationDAL _locdataLayer = null;       

        public LocalSupplier()
        {
            _dataLayer = new DataLayer.LocalSupplierDAL();
            _itemdataLayer = new DataLayer.ItemMasterDAL();
            _locdataLayer = new DataLayer.LocationDAL();
           
        }

        public BusinessModels.LocalSupplier GetLocalSupplier(Int32 identity)
        {
            return _dataLayer.GetLocalSupplier(identity);
        }
        public IEnumerable<BusinessModels.ItemMaster> GetAllItemMaster()
        {
            //TestRegionData();
            return _itemdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Location> GetAlllocations()
        {
            //TestRegionData();
            return _locdataLayer.GetAll();
        }
       
        public IEnumerable<BusinessModels.LocalSupplier> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.LocalSupplier LocalSupplier)
        {
            return _dataLayer.Update(LocalSupplier);
        }

        public Boolean Insert(BusinessModels.LocalSupplier LocalSupplier)
        {
            return _dataLayer.Insert(LocalSupplier);
        }



    }


}
