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
        private DataLayer.VendorDAL _venddataLayer = null;
        private DataLayer.BrandDAL _branddataLayer = null;
        private DataLayer.ProductMasterDAL _proddataLayer = null;

        public Tax()
        {
            _dataLayer = new DataLayer.TaxDAL();
            _itedataLayer = new DataLayer.ItemMasterDAL();
            _venddataLayer = new DataLayer.VendorDAL();
            _branddataLayer = new DataLayer.BrandDAL();
            _proddataLayer = new DataLayer.ProductMasterDAL();
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

        public IEnumerable<BusinessModels.Vendor> GetAllVendorsOnProductMaster(string fldidentity)
        {
            //TestRegionData();
            return _venddataLayer.GetAll(int.Parse(fldidentity));
        }
        public IEnumerable<BusinessModels.Brand> GetAllBrandsonVendor(string fldidentity)
        {
            //TestRegionData();
            return _branddataLayer.GetAll(int.Parse(fldidentity));
        }

        public IEnumerable<BusinessModels.ItemMaster> GetAllItemsOnBrand(string fldidentity)
        {
            //TestRegionData();
            return _itedataLayer.GetAll(int.Parse(fldidentity));
        }
        public IEnumerable<BusinessModels.Tax> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.Tax> GetTaxOnBrand(string fldidentity)
        {
            return _dataLayer.GetAllTaxOnBrand(int.Parse(fldidentity));
        }

        public IEnumerable<BusinessModels.Tax> GetTaxOnVendor(string fldidentity)
        {
            return _dataLayer.GetAllTaxOnVendor(int.Parse(fldidentity));
        }

        public IEnumerable<BusinessModels.Tax> GetTaxOnProductCategory(string fldidentity)
        {
            return _dataLayer.GetAllTaxOnProductCategory(int.Parse(fldidentity));
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
