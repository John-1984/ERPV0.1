using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Stocks
    {

        private List<BusinessModels.Stocks> Stockss = new List<BusinessModels.Stocks>();
        private DataLayer.StocksDAL _dataLayer = null;
        private DataLayer.LocationDAL _locddataLayer = null;
        private DataLayer.VendorDAL _venddataLayer = null;
        private DataLayer.BrandDAL _branddataLayer = null;
        private DataLayer.ProductMasterDAL _proddataLayer = null;
        private DataLayer.ItemMasterDAL _itemdataLayer = null;

        public Stocks()
        {
            _dataLayer = new DataLayer.StocksDAL();
            _locddataLayer = new DataLayer.LocationDAL();
            _proddataLayer = new DataLayer.ProductMasterDAL();
            _venddataLayer = new DataLayer.VendorDAL();
            _branddataLayer = new DataLayer.BrandDAL();
            _itemdataLayer = new DataLayer.ItemMasterDAL();
        }

        public BusinessModels.Stocks GetStocks(Int32 identity)
        {
            return _dataLayer.GetStocks(identity);
        }
        public BusinessModels.Stocks GetStocks(int itemid, string size)
        {
            return _dataLayer.GetStocks(itemid, size);
        }
            public IEnumerable<BusinessModels.Stocks> GetAll()
        {
            return _dataLayer.GetAll();
        }
       
        public IEnumerable<BusinessModels.Stocks> GetAll(int locID)
        {
            return _dataLayer.GetAll(locID);
        }
        public IEnumerable<BusinessModels.Stocks> GetAll(int locID, int empID)
        {
            return _dataLayer.GetAll(locID,empID);
        }
       
        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Stocks Stocks)
        {
            return _dataLayer.Update(Stocks);
        }

        public BusinessModels.Stocks Insert(BusinessModels.Stocks Stocks)
        {
            return _dataLayer.Insert(Stocks);
        }
        public BusinessModels.Stocks GetStocksWithItemIDAndSize(Int32 identity, string size)
        {
            return _dataLayer.GetStocksWithItemIDAndSize(identity,size);
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
        public bool UpdateItemStockQuantity(int itemid, string size, decimal quantity)
        {
            return _dataLayer.UpdateItemStockQuantity(itemid, size, quantity);
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
