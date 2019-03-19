using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace BusinessLayer
{
    public class PurchaseQuotation
    {

        private List<BusinessModels.PurchaseQuotation> PurchaseQuotations = new List<BusinessModels.PurchaseQuotation>();
        private DataLayer.PurchaseQuotationDAL _dataLayer = null;
        private DataLayer.LocationDAL _locddataLayer = null;
        private DataLayer.StatusDAL _statsddataLayer = null;
        private DataLayer.ProductMasterDAL _prodddataLayer = null;
        private DataLayer.VendorDAL _venddataLayer = null;
        private DataLayer.BrandDAL _branddataLayer = null;
        private DataLayer.ItemMasterDAL _itemdataLayer = null;
        private DataLayer.CompanyTypeDAL _comptypedataLayer = null;
        
        private DataLayer.EnquiryLevelDAL _enqlvldataLayer = null;
        private DataLayer.MenuDAL _menudataLayer = null;

        private DataLayer.PurchaseQuotationDetailsDAL _sqDetailsdataLayer = null;
        public PurchaseQuotation()
        {
            _dataLayer = new DataLayer.PurchaseQuotationDAL();
            _locddataLayer = new DataLayer.LocationDAL();
            _statsddataLayer = new DataLayer.StatusDAL();
            _prodddataLayer = new DataLayer.ProductMasterDAL();
            _sqDetailsdataLayer = new DataLayer.PurchaseQuotationDetailsDAL();
            _venddataLayer = new DataLayer.VendorDAL();
            _branddataLayer = new DataLayer.BrandDAL();
            _itemdataLayer = new DataLayer.ItemMasterDAL();
            _comptypedataLayer = new DataLayer.CompanyTypeDAL();           
            _enqlvldataLayer = new DataLayer.EnquiryLevelDAL();
            _menudataLayer = new DataLayer.MenuDAL();

        }

        public BusinessModels.PurchaseQuotation GetPurchaseQuotation(Int32 identity)
        {
            return _dataLayer.GetPurchaseQuotation(identity);
        }

        public BusinessModels.PurchaseQuotation GetPurchaseQuotationDetails(Int32? identity)
        {
            return _dataLayer.GetPurchaseQuotationDetails(identity);
        }

        public BusinessModels.PurchaseQuotation UpdatePurchaseQuotationStatus(int? statusid, int identity)
        {
            return _dataLayer.UpdatePurchaseQuotationStatus(statusid,identity);
        }
            public BusinessModels.PurchaseQuotationDetails GetAllByPurchaseQuotation(int? identity)
        {
            return _sqDetailsdataLayer.GetAllByPurchaseQuotation(identity);
        }

        public IEnumerable<BusinessModels.PurchaseQuotation> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.PurchaseQuotation> GetAll(int locID)
        {
            return _dataLayer.GetAll(locID);
        }
        public IEnumerable<BusinessModels.PurchaseQuotation> GetAll(int locID, int empID)
        {
            return _dataLayer.GetAll(locID, empID);
        }


        public IEnumerable<BusinessModels.PurchaseQuotation> GetAllPendingApporvalPQ()
        {
            return _dataLayer.GetAllPendingApporvalPQ();
        }

        public IEnumerable<BusinessModels.PurchaseQuotation> GetAllPendingApporvalPQ(int locID)
        {
            return _dataLayer.GetAllPendingApporvalPQ(locID);
        }
        public IEnumerable<BusinessModels.PurchaseQuotation> GetAllPendingApporvalPQ(int locID, int empID)
        {
            return _dataLayer.GetAllPendingApporvalPQ(locID, empID);
        }

        public BusinessModels.PurchaseQuotation UpdatePurchaseQuotationAssignedandStatus(int assignedid, int statusid, int identity)
        {
            return _dataLayer.UpdatePurchaseQuotationAssignedandStatus(assignedid, statusid, identity);
        }

        public BusinessModels.PurchaseQuotation UpdatePurchaseQuotationAssigned(int assignedid,  int identity)
        {
            return _dataLayer.UpdatePurchaseQuotationAssigned(assignedid, identity);
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

        

        public Boolean Update(BusinessModels.PurchaseQuotation PurchaseQuotation)
        {
            return _dataLayer.Update(PurchaseQuotation);
        }

        public BusinessModels.PurchaseQuotation Insert(BusinessModels.PurchaseRequest prRequest, int companyType,string empID)
        {
            BusinessModels.PurchaseQuotation mdPurchaseQuote = new BusinessModels.PurchaseQuotation();
            mdPurchaseQuote.LocationID = prRequest.LocationID;
            mdPurchaseQuote.OriginatorID = prRequest.AssignedTo;
            mdPurchaseQuote.EnquiryLevelID = prRequest.EnquiryLevelID;
            mdPurchaseQuote.PurchaseRequestID = prRequest.Identity;
            mdPurchaseQuote.IsActive = true;
            mdPurchaseQuote.IsApproved = false;
            mdPurchaseQuote.IsPOGenerated= false;
            mdPurchaseQuote.CreatedBy = prRequest.OriginatorID;
            mdPurchaseQuote.CreatedDate = DateTime.Now;
            mdPurchaseQuote.CompanyTypeID = companyType;
            mdPurchaseQuote.StatusID = 1;
            mdPurchaseQuote.AssignedTo = prRequest.AssignedTo;

            mdPurchaseQuote.PQCode = "PQ#" + GetRandomAlphanumericString();
            _dataLayer.Insert(mdPurchaseQuote);
            //WorkflowManager.WorkflowInitializer _workflowInitializer = new WorkflowManager.WorkflowInitializer();
            ////coded
            //BusinessModels.Menu mnID = _menudataLayer.GetMenuByName("Sales Quotation");
            //BusinessModels.Workflow.Workflow wrkFlow = _workflowInitializer.GetWorkFLowIDForLocationAndItemType(prRequest.LocationID,mnID.Identity);

            //_workflowInitializer.InitializeWorkflow(wrkFlow.Identity, Convert.ToInt32(empID), mdPurchaseQuote.Identity, mnID.Identity.ToString());

            return mdPurchaseQuote;
        }

        public bool InitiateinvoiceApprovalWOrkFlow(int sqId, int empID, int locID)
        {
            //Intitate work flow for invoice approval by FM and head. Initially we pass FM empid for first step
            WorkflowManager.WorkflowInitializer _workflowInitializer = new WorkflowManager.WorkflowInitializer();
            //coded
            BusinessModels.Menu mnID = _menudataLayer.GetMenuByName("PR Invoice Generated");
            BusinessModels.Workflow.Workflow wrkFlow = _workflowInitializer.GetWorkFLowIDForLocationAndItemType(locID, mnID.ID);

            return _workflowInitializer.InitializeWorkflow(wrkFlow.Identity, Convert.ToInt32(empID), sqId, mnID.ID.ToString());
        }

        private static string GetRandomAlphanumericString()
        {
            const string alphanumericCharacters =
               "0123456789" + "0123456789";
            return GetRandomString(3, alphanumericCharacters);
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
