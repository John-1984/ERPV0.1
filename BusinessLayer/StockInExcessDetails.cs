using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class StockInExcessDetails
    {

        private List<BusinessModels.StockInExcessDetails> StockInExcessDetailss = new List<BusinessModels.StockInExcessDetails>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.StockInExcessDetailsDAL _dataLayer = null;
        private DataLayer.VendorDAL _venddataLayer = null;
        private DataLayer.BrandDAL _branddataLayer = null;
        private DataLayer.ProductMasterDAL _proddataLayer = null;
        private DataLayer.ItemMasterDAL _itemdataLayer = null;


        public StockInExcessDetails()
        {
            _dataLayer = new DataLayer.StockInExcessDetailsDAL();
            _venddataLayer = new DataLayer.VendorDAL();
            _branddataLayer = new DataLayer.BrandDAL();
            _proddataLayer = new DataLayer.ProductMasterDAL();
            _itemdataLayer = new DataLayer.ItemMasterDAL();

        }
        public IEnumerable<BusinessModels.StockInExcessDetails> GetAllByPurchaseOrder(int reqID)
        {
            return _dataLayer.GetAllByPurchaseOrder(reqID);
        }
        public BusinessModels.StockInExcessDetails GetStockInExcessDetails(Int32 identity)
        {
            return _dataLayer.GetStockInExcessDetails(identity);
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


        public IEnumerable<BusinessModels.StockInExcessDetails> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.StockInExcessDetails StockInExcessDetails)
        {
            return _dataLayer.Update(StockInExcessDetails);
        }

        public BusinessModels.StockInExcessDetails Insert(BusinessModels.StockInExcessDetails StockInExcessDetails)
        {
            return _dataLayer.Insert(StockInExcessDetails);
        }



    }


}
