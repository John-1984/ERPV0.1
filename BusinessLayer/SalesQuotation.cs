using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace BusinessLayer
{
    public class SalesQuotation
    {

        private List<BusinessModels.SalesQuotation> SalesQuotations = new List<BusinessModels.SalesQuotation>();
        private DataLayer.SalesQuotationDAL _dataLayer = null;
        private DataLayer.LocationDAL _locddataLayer = null;
        private DataLayer.StatusDAL _statsddataLayer = null;
        private DataLayer.ProductMasterDAL _prodddataLayer = null;
        private DataLayer.VendorDAL _venddataLayer = null;
        private DataLayer.BrandDAL _branddataLayer = null;
        private DataLayer.ItemMasterDAL _itemdataLayer = null;
        private DataLayer.CompanyTypeDAL _comptypedataLayer = null;
        
        private DataLayer.EnquiryLevelDAL _enqlvldataLayer = null;

        private DataLayer.SalesQuotationDetailsDAL _sqDetailsdataLayer = null;
        public SalesQuotation()
        {
            _dataLayer = new DataLayer.SalesQuotationDAL();
            _locddataLayer = new DataLayer.LocationDAL();
            _statsddataLayer = new DataLayer.StatusDAL();
            _prodddataLayer = new DataLayer.ProductMasterDAL();
            _sqDetailsdataLayer = new DataLayer.SalesQuotationDetailsDAL();
            _venddataLayer = new DataLayer.VendorDAL();
            _branddataLayer = new DataLayer.BrandDAL();
            _itemdataLayer = new DataLayer.ItemMasterDAL();
            _comptypedataLayer = new DataLayer.CompanyTypeDAL();           
            _enqlvldataLayer = new DataLayer.EnquiryLevelDAL();

        }

        public BusinessModels.SalesQuotation GetSalesQuotation(Int32 identity)
        {
            return _dataLayer.GetSalesQuotation(identity);
        }
        public IEnumerable<BusinessModels.SalesQuotation> GetAll()
        {
            return _dataLayer.GetAll();
        }
        

        public IEnumerable<BusinessModels.SalesQuotationDetails> GetAllBySalesQuotation(int identity)
        {
            return _sqDetailsdataLayer.GetAllBySalesQuotation(identity);
        }
        public IEnumerable<BusinessModels.SalesQuotation> GetAll(int locID)
        {
            return _dataLayer.GetAll(locID);
        }
        public IEnumerable<BusinessModels.SalesQuotation> GetAll(int locID, int empID)
        {
            return _dataLayer.GetAll(locID, empID);
        }

        public bool UpdateSalesQuotationAssignedandStatus(int assignedid, int statusid, int identity)
        {
            return _dataLayer.UpdateSalesQuotationAssignedandStatus(assignedid, statusid, identity);
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

        public Boolean Update(BusinessModels.SalesQuotation SalesQuotation)
        {
            return _dataLayer.Update(SalesQuotation);
        }

        public BusinessModels.SalesQuotation Insert(BusinessModels.SalesQuotation SalesQuotation)
        {
            BusinessModels.CompanyType mdcomp = _comptypedataLayer.GetCompanyType(SalesQuotation.CompanyTypeID);
            string companyName = mdcomp.Company.CompanyName;
            SalesQuotation.SQCode = "SQ#" + GetRandomAlphanumericString();           
            return _dataLayer.Insert(SalesQuotation);
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
