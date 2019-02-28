using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class ProductEnquiry
    {

        private List<BusinessModels.ProductEnquiry> ProductEnquirys = new List<BusinessModels.ProductEnquiry>();
        private DataLayer.ProductEnquiryDAL _dataLayer = null;
        private DataLayer.LocationDAL _locddataLayer = null;
        private DataLayer.CustomerDAL _cusddataLayer = null;
        private DataLayer.StatusDAL _statsddataLayer = null;
        private DataLayer.EnquiryLevelDAL _eqddataLayer = null;
        private DataLayer.ProductMasterDAL _prodddataLayer = null;
        private DataLayer.VendorDAL _venddataLayer = null;
        private DataLayer.BrandDAL _branddataLayer = null;
        private DataLayer.ProductMasterDAL _proddataLayer = null;
        private DataLayer.ItemMasterDAL _itemdataLayer = null;

        private DataLayer.ProductEnquiryDetailsDAL _enqDetailsdataLayer = null;
        public ProductEnquiry()
        {
            _dataLayer = new DataLayer.ProductEnquiryDAL();
            _locddataLayer = new DataLayer.LocationDAL();
            _cusddataLayer = new DataLayer.CustomerDAL();
            _statsddataLayer = new DataLayer.StatusDAL();
            _eqddataLayer = new DataLayer.EnquiryLevelDAL();
            _prodddataLayer = new DataLayer.ProductMasterDAL();
            _enqDetailsdataLayer = new DataLayer.ProductEnquiryDetailsDAL();
            _venddataLayer = new DataLayer.VendorDAL();
            _branddataLayer = new DataLayer.BrandDAL();
            _itemdataLayer = new DataLayer.ItemMasterDAL();

        }

        public BusinessModels.ProductEnquiry GetProductEnquiry(Int32 identity)
        {
            return _dataLayer.GetProductEnquiry(identity);
        }
        public IEnumerable<BusinessModels.ProductEnquiry> GetAll()
        {
            return _dataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.ProductEnquiryDetails> GetAllEnquiryItemDetails(int identity)
        {
            return _enqDetailsdataLayer.GetAll(identity);
        }
        public IEnumerable<BusinessModels.ProductEnquiry> GetAll(int locID)
        {
            return _dataLayer.GetAll(locID);
        }
        public IEnumerable<BusinessModels.ProductEnquiry> GetAll(int locID, int empID)
        {
            return _dataLayer.GetAll(locID,empID);
        }

        public IEnumerable<BusinessModels.EnquiryLevel> GetAllEnquiryLevels()
        {
            return _eqddataLayer.GetAll();
        }

        //public IEnumerable<BusinessModels.ProductMaster> GetAllProductMasters()
        //{
        //    return _prodddataLayer.GetAll();
        //}

        public IEnumerable<BusinessModels.Status> GetAllStatus()
        {
            return _statsddataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.ProductEnquiry ProductEnquiry)
        {
            return _dataLayer.Update(ProductEnquiry);
        }

        public BusinessModels.ProductEnquiry Insert(BusinessModels.ProductEnquiry ProductEnquiry)
        {
            return _dataLayer.Insert(ProductEnquiry);
        }

        public IEnumerable<BusinessModels.ItemMaster> GetAllItems()
        {
            //TestRegionData();
            return _itemdataLayer.GetAll();
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

        public IEnumerable<BusinessModels.ProductMaster> GetAllProductMasters()
        {
            //TestRegionData();
            return _proddataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.ItemMaster> GetItemMasters(string fldidentity)
        {
            //TestRegionData();
            return _itemdataLayer.GetAll(int.Parse(fldidentity));
        }
        public IEnumerable<BusinessModels.Vendor> GetAllVendors(string fldidentity)
        {
            //TestRegionData();
            return _venddataLayer.GetAll(int.Parse(fldidentity));
        }
        public IEnumerable<BusinessModels.Brand> GetAllBrands(string fldidentity)
        {
            //TestRegionData();
            return _branddataLayer.GetAll(int.Parse(fldidentity));
        }

        public BusinessModels.ItemMaster GetItemDetails(string fldidentity)
        {
            //TestRegionData();
            return _itemdataLayer.GetItemMaster(int.Parse(fldidentity));
        }
    }


}
