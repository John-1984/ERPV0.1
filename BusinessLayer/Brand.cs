using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Brand
    {

        private List<BusinessModels.Brand> Brands = new List<BusinessModels.Brand>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.BrandDAL _dataLayer = null;
        private DataLayer.VendorDAL _venddataLayer = null;
       

        public Brand()
        {
            _dataLayer = new DataLayer.BrandDAL();
            _venddataLayer = new DataLayer.VendorDAL();
           
        }

        public BusinessModels.Brand GetBrand(Int32 identity)
        {
            return _dataLayer.GetBrand(identity);
        }
        public IEnumerable<BusinessModels.Vendor> GetAllVendors()
        {
            //TestRegionData();
            return _venddataLayer.GetAll();
        }
       
        public IEnumerable<BusinessModels.Brand> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Brand Brand)
        {
            return _dataLayer.Update(Brand);
        }

        public Boolean Insert(BusinessModels.Brand Brand)
        {
            return _dataLayer.Insert(Brand);
        }



    }


}
