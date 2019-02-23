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
        private DataLayer.VendorDAL _venddataLayer = null;
        private DataLayer.BrandDAL _branddataLayer = null;
        private DataLayer.ProductMasterDAL _proddataLayer = null;


        public Discount()
        {
            _dataLayer = new DataLayer.DiscountDAL();
            _itemdataLayer = new DataLayer.ItemMasterDAL();
            _venddataLayer = new DataLayer.VendorDAL();
            _branddataLayer = new DataLayer.BrandDAL();
            _proddataLayer = new DataLayer.ProductMasterDAL();

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
            return _itemdataLayer.GetAll(int.Parse(fldidentity));
        }

        public IEnumerable<BusinessModels.Discount> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.Discount> GetdiscountOnBrand(string fldidentity)
        {
            return _dataLayer.GetAllDiscountOnBrand(int.Parse(fldidentity));
        }

        public IEnumerable<BusinessModels.Discount> GetdiscountOnVendor(string fldidentity)
        {
            return _dataLayer.GetAllDiscountOnVendor(int.Parse(fldidentity));
        }

        public IEnumerable<BusinessModels.Discount> GetdiscountOnProductCategory(string fldidentity)
        {
            return _dataLayer.GetAllDiscountOnProductMaster(int.Parse(fldidentity));
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
