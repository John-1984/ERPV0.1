using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace BusinessLayer
{
    public class PurchaseRequest
    {

        private List<BusinessModels.PurchaseRequest> PurchaseRequests = new List<BusinessModels.PurchaseRequest>();
        private DataLayer.PurchaseRequestDAL _dataLayer = null;
        private DataLayer.LocationDAL _locddataLayer = null;
        private DataLayer.StatusDAL _statsddataLayer = null;
        private DataLayer.ProductMasterDAL _prodddataLayer = null;
        private DataLayer.VendorDAL _venddataLayer = null;
        private DataLayer.BrandDAL _branddataLayer = null;
        private DataLayer.ItemMasterDAL _itemdataLayer = null;
        private DataLayer.CompanyTypeDAL _comptypedataLayer = null;
        private DataLayer.PurchaseRequestTypeDAL _purtypedataLayer = null;
        private DataLayer.EnquiryLevelDAL _enqlvldataLayer = null;
        private DataLayer.MenuDAL _menudataLayer =null;

        private DataLayer.PurchaseRequestDetailsDAL _enqDetailsdataLayer = null;
        public PurchaseRequest()
        {
            _dataLayer = new DataLayer.PurchaseRequestDAL();
            _locddataLayer = new DataLayer.LocationDAL();
            _statsddataLayer = new DataLayer.StatusDAL();
            _prodddataLayer = new DataLayer.ProductMasterDAL();
            _enqDetailsdataLayer = new DataLayer.PurchaseRequestDetailsDAL();
            _venddataLayer = new DataLayer.VendorDAL();
            _branddataLayer = new DataLayer.BrandDAL();
            _menudataLayer = new DataLayer.MenuDAL();
            _itemdataLayer = new DataLayer.ItemMasterDAL();
            _comptypedataLayer = new DataLayer.CompanyTypeDAL();
            _purtypedataLayer = new DataLayer.PurchaseRequestTypeDAL();
            _enqlvldataLayer = new DataLayer.EnquiryLevelDAL();

        }

        public BusinessModels.PurchaseRequest GetPurchaseRequest(Int32? identity)
        {
            return _dataLayer.GetPurchaseRequest(identity);
        }
        public IEnumerable<BusinessModels.PurchaseRequest> GetAll()
        {
            return _dataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.PurchaseRequestType> GetAllPurchaseRequestType()
        {
            return _purtypedataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.PurchaseRequestDetails> GetAllByPurchaseRequest(int identity)
        {
            return _enqDetailsdataLayer.GetAllByPurchaseRequest(identity);
        }
        public IEnumerable<BusinessModels.PurchaseRequest> GetAll(int locID)
        {
            return _dataLayer.GetAll(locID);
        }
        public IEnumerable<BusinessModels.PurchaseRequest> GetAll(int locID, int empID)
        {
            return _dataLayer.GetAll(locID, empID);
        }

        public BusinessModels.PurchaseRequest UpdatePurchaseRequestAssignedandStatus(int assignedid, int statusid, int identity)
        {
            return _dataLayer.UpdatePurchaseRequestAssignedandStatus(assignedid,statusid,identity);
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

        public bool InitiateinvoiceApprovalWorkFlow(int prId, int empID, int locID, string strName)
        {
            //Intitate work flow for invoice approval by FM and head. Initially we pass FM empid for first step
            WorkflowManager.WorkflowInitializer _workflowInitializer = new WorkflowManager.WorkflowInitializer();
            //coded
            BusinessModels.Menu mnID = _menudataLayer.GetMenuByName("Purchase Request");
            BusinessModels.Workflow.Workflow wrkFlow = _workflowInitializer.GetWorkFLowIDForLocationAndItemTypeByName(locID, mnID.ID, strName);
            return _workflowInitializer.InitializeWorkflow(wrkFlow.Identity, Convert.ToInt32(empID), prId, mnID.ID.ToString());
        }
        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.PurchaseRequest PurchaseRequest)
        {
            return _dataLayer.Update(PurchaseRequest);
        }

        public BusinessModels.PurchaseRequest Insert(BusinessModels.PurchaseRequest PurchaseRequest)
        {
            BusinessModels.CompanyType mdcomp = _comptypedataLayer.GetCompanyType(PurchaseRequest.CompanyTypeID);
            string companyName = mdcomp.Company.CompanyName;
            PurchaseRequest.CaseNo = "Case#" + GetRandomAlphanumericString();
            PurchaseRequest.POCode = companyName+"#PO" + GetRandomAlphanumericString();
            return _dataLayer.Insert(PurchaseRequest);
        }
        private static string GetRandomAlphanumericString()
        {
            const string alphanumericCharacters =
               "0123456789" + "0123456789" ;
            return GetRandomString(2, alphanumericCharacters);
        }
        private static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
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
