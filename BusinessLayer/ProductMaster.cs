using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class ProductMaster
    {
        private List<BusinessModels.ProductMaster> ProductMasters = new List<BusinessModels.ProductMaster>();
        private DataLayer.ProductMasterDAL _dataLayer = null;

        public ProductMaster()
        {
            _dataLayer = new DataLayer.ProductMasterDAL();
        }

        public BusinessModels.ProductMaster GetProductMaster(Int32 identity)
        {
            return _dataLayer.GetProductMaster(identity);
        }

        public IEnumerable<BusinessModels.ProductMaster> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.ProductMaster ProductMaster)
        {
            return _dataLayer.Update(ProductMaster);
        }

        public Boolean Insert(BusinessModels.ProductMaster ProductMaster)
        {
            return _dataLayer.Insert(ProductMaster);
        }



    }


}
