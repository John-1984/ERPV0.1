using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace BusinessLayer
{
    public class PurchaseOrder
    {

        private List<BusinessModels.PurchaseOrder> PurchaseOrders = new List<BusinessModels.PurchaseOrder>();
        private DataLayer.PurchaseOrderDAL _dataLayer = null;
        private DataLayer.LocationDAL _locddataLayer = null;
        private DataLayer.StatusDAL _statsddataLayer = null;
        private DataLayer.ProductMasterDAL _prodddataLayer = null;
        private DataLayer.VendorDAL _venddataLayer = null;
        private DataLayer.BrandDAL _branddataLayer = null;
        private DataLayer.ItemMasterDAL _itemdataLayer = null;
        private DataLayer.CompanyTypeDAL _comptypedataLayer = null;

        private DataLayer.EnquiryLevelDAL _enqlvldataLayer = null;
        private DataLayer.MenuDAL _menudataLayer = null;

        private DataLayer.PurchaseQuotationDAL _pqDetailsdataLayer = null;
        public PurchaseOrder()
        {
            _dataLayer = new DataLayer.PurchaseOrderDAL();
            _locddataLayer = new DataLayer.LocationDAL();
            _statsddataLayer = new DataLayer.StatusDAL();
            _prodddataLayer = new DataLayer.ProductMasterDAL();
            _pqDetailsdataLayer = new DataLayer.PurchaseQuotationDAL();
            _venddataLayer = new DataLayer.VendorDAL();
            _branddataLayer = new DataLayer.BrandDAL();
            _itemdataLayer = new DataLayer.ItemMasterDAL();
            _comptypedataLayer = new DataLayer.CompanyTypeDAL();
            _enqlvldataLayer = new DataLayer.EnquiryLevelDAL();
            _menudataLayer = new DataLayer.MenuDAL();

        }

        public BusinessModels.PurchaseOrder GetPurchaseOrder(Int32 identity)
        {
            return _dataLayer.GetPurchaseOrder(identity);
        }

        public BusinessModels.PurchaseOrder GetPurchaseOrderDetails(Int32 identity)
        {
            return _dataLayer.GetPurchaseOrderDetails(identity);
        }

        public BusinessModels.PurchaseOrder UpdatePurchaseOrderStatus(int? statusid, int identity)
        {
            return _dataLayer.UpdatePurchaseOrderStatus(statusid, identity);
        }
       
        public IEnumerable<BusinessModels.PurchaseOrder> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAll(int locID)
        {
            return _dataLayer.GetAll(locID);
        }
        public IEnumerable<BusinessModels.PurchaseOrder> GetAll(int locID, int empID)
        {
            return _dataLayer.GetAll(locID, empID);
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAllPendingTobeAssigned()
        {
            return _dataLayer.GetAllPendingTobeAssigned();
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAllPendingTobeAssigned(int locID)
        {
            return _dataLayer.GetAllPendingTobeAssigned(locID);
        }
        public IEnumerable<BusinessModels.PurchaseOrder> GetAllPendingTobeAssigned(int locID, int empID)
        {
            return _dataLayer.GetAllPendingTobeAssigned(locID, empID);
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAllWarehouseAssignedPO()
        {
            return _dataLayer.GetAllWarehouseAssignedPO();
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAllWarehouseAssignedPO(int locID)
        {
            return _dataLayer.GetAllWarehouseAssignedPO(locID);
        }
        public IEnumerable<BusinessModels.PurchaseOrder> GetAllWarehouseAssignedPO(int locID, int empID)
        {
            return _dataLayer.GetAllWarehouseAssignedPO(locID, empID);
        }


        public IEnumerable<BusinessModels.PurchaseOrder> GetAllPendingApporvalPO()
        {
            return _dataLayer.GetAllPendingApporvalPO();
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAllPendingApporvalPO(int locID)
        {
            return _dataLayer.GetAllPendingApporvalPO(locID);
        }
        public IEnumerable<BusinessModels.PurchaseOrder> GetAllPendingApporvalPO(int locID, int empID)
        {
            return _dataLayer.GetAllPendingApporvalPO(locID, empID);
        }

        public BusinessModels.PurchaseOrder UpdatePurchaseOrderAssignedandStatus(int assignedid, int statusid, int identity)
        {
            return _dataLayer.UpdatePurchaseOrderAssignedandStatus(assignedid, statusid, identity);
        }

        public BusinessModels.PurchaseOrder UpdatePurchaseOrderAssigned(int? assignedid, int identity)
        {
            return _dataLayer.UpdatePurchaseOrderAssigned(assignedid, identity);
        }
        public BusinessModels.PurchaseOrder UpdatePOWareHouseAssignedID(int? assignedid, int identity)
        {
            return _dataLayer.UpdatePOWareHouseAssignedID(assignedid, identity);
        }
        //public IEnumerable<BusinessModels.ProductMaster> GetAllProductMasters()
        //{
        //    return _prodddataLayer.GetAll();
        //}

        public IEnumerable<BusinessModels.Status> GetAllStatus()
        {
            return _statsddataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.EnquiryLevel> GetAllEnquiryLevels()
        {
            return _enqlvldataLayer.GetAll();
        }


        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }



        public Boolean Update(BusinessModels.PurchaseOrder PurchaseOrder)
        {
            return _dataLayer.Update(PurchaseOrder);
        }

       
      
        public IEnumerable<BusinessModels.ItemMaster> GetAllItems()
        {

            return _itemdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Vendor> GetAllVendors()
        {

            return _venddataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Brand> GetAllBrands()
        {

            return _branddataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.ProductMaster> GetAllProductMasters()
        {

            return _prodddataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.ItemMaster> GetItemMasters(string fldidentity)
        {

            return _itemdataLayer.GetAll(int.Parse(fldidentity));
        }

        public IEnumerable<BusinessModels.Vendor> GetAllVendors(string fldidentity)
        {

            return _venddataLayer.GetAll(int.Parse(fldidentity));
        }
        public IEnumerable<BusinessModels.Brand> GetAllBrands(string fldidentity)
        {

            return _branddataLayer.GetAll(int.Parse(fldidentity));
        }

        public BusinessModels.ItemMaster GetItemDetails(string fldidentity)
        {

            return _itemdataLayer.GetItemMaster(int.Parse(fldidentity));
        }
    }


}
