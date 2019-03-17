using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class StockOutExpenseDetails
    {

        private List<BusinessModels.StockOutExpenseDetails> StockOutExpenseDetailss = new List<BusinessModels.StockOutExpenseDetails>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.StockOutExpenseDetailsDAL _dataLayer = null;
        private DataLayer.VendorDAL _venddataLayer = null;
        private DataLayer.BrandDAL _branddataLayer = null;
        private DataLayer.ProductMasterDAL _proddataLayer = null;
        private DataLayer.ItemMasterDAL _itemdataLayer = null;


        public StockOutExpenseDetails()
        {
            _dataLayer = new DataLayer.StockOutExpenseDetailsDAL();
            _venddataLayer = new DataLayer.VendorDAL();
            _branddataLayer = new DataLayer.BrandDAL();
            _proddataLayer = new DataLayer.ProductMasterDAL();
            _itemdataLayer = new DataLayer.ItemMasterDAL();

        }
        public IEnumerable<BusinessModels.StockOutExpenseDetails> GetAllExpenseBySQ(int? identity)
        {
            return _dataLayer.GetAllExpenseBySQ(identity);
        }

        public BusinessModels.StockOutExpenseDetails GetAllBySalesQuotation(int reqID)
        {
           return _dataLayer.GetAllBySalesQuotation(reqID);
        }
        public BusinessModels.StockOutExpenseDetails GetStockOutExpenseDetails(Int32 identity)
        {
            return _dataLayer.GetStockOutExpenseDetails(identity);
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


        public IEnumerable<BusinessModels.StockOutExpenseDetails> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.StockOutExpenseDetails StockOutExpenseDetails)
        {
            return _dataLayer.Update(StockOutExpenseDetails);
        }

        public BusinessModels.StockOutExpenseDetails Insert(BusinessModels.StockOutExpenseDetails StockOutExpenseDetails)
        {
            return _dataLayer.Insert(StockOutExpenseDetails);
        }



    }


}
