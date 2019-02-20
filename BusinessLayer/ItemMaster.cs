using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class ItemMaster
    {

        private List<BusinessModels.ItemMaster> ItemMasters = new List<BusinessModels.ItemMaster>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.ItemMasterDAL _dataLayer = null;
        private DataLayer.VendorDAL _venddataLayer = null;
        private DataLayer.BrandDAL _branddataLayer = null;
        private DataLayer.UOMMasterDAL _uomdataLayer = null;

        public ItemMaster()
        {
            _dataLayer = new DataLayer.ItemMasterDAL();
            _venddataLayer = new DataLayer.VendorDAL();
            _branddataLayer = new DataLayer.BrandDAL();
            _uomdataLayer = new DataLayer.UOMMasterDAL();
        }

        public BusinessModels.ItemMaster GetItemMaster(Int32 identity)
        {
            return _dataLayer.GetItemMaster(identity);
        }
        public IEnumerable<BusinessModels.Vendor> GetAllVendors()
        {
            //TestRegionData();
            return _venddataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Brand> GetAllBrands()
        {
            //TestRegionData();
            return _branddataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.UOMMaster> GetAllUOMs()
        {
            //TestRegionData();
            return _uomdataLayer.GetAll();
        }
       
        public IEnumerable<BusinessModels.ItemMaster> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.ItemMaster ItemMaster)
        {
            return _dataLayer.Update(ItemMaster);
        }

        public Boolean Insert(BusinessModels.ItemMaster ItemMaster)
        {
            return _dataLayer.Insert(ItemMaster);
        }



    }


}
