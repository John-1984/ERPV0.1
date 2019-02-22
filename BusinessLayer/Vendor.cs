using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Vendor
    {
        private List<BusinessModels.Vendor> Vendors = new List<BusinessModels.Vendor>();
        private DataLayer.VendorDAL _dataLayer = null;
        private DataLayer.ProductMasterDAL _proddataLayer = null;

        public Vendor()
        {
            _dataLayer = new DataLayer.VendorDAL();
            _proddataLayer = new DataLayer.ProductMasterDAL();
        }

        public BusinessModels.Vendor GetVendor(Int32 identity)
        {
            return _dataLayer.GetVendor(identity);
        }

        public IEnumerable<BusinessModels.Vendor> GetAll()
        {
            return _dataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.ProductMaster> GetAllProductMaster()
        {
            return _proddataLayer.GetAll();
        }

       
        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Vendor Vendor)
        {
            return _dataLayer.Update(Vendor);
        }

        public Boolean Insert(BusinessModels.Vendor Vendor)
        {
            return _dataLayer.Insert(Vendor);
        }



    }


}
