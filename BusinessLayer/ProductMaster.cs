using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class ProductMaster
    {
        public ProductMaster()
        {
           
        }

        private static List<BusinessModels.ProductMaster> ProductMasters = new List<BusinessModels.ProductMaster>();

        public BusinessModels.ProductMaster GetProductMaster(Int32 identity)
        {
            return ProductMasters.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.ProductMaster> GetAll()
        {
            return ProductMasters;
        }

        public Boolean Delete(Int32 identity)
        {
            ProductMasters.Remove(ProductMasters.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.ProductMaster ProductMaster)
        {
            ProductMasters.Remove(ProductMasters.Find(p => p.Identity.Equals(ProductMaster.Identity)));
            ProductMasters.Add(ProductMaster);
            return true;
        }

        public Boolean Insert(BusinessModels.ProductMaster ProductMaster)
        {
            ProductMasters.Add(ProductMaster);
            return true;
        }

        public void TestData()
        {
            ProductMasters.Add(
                new BusinessModels.ProductMaster()
                {
                    ProductName = "John",
                    Identity = 1,

                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            ProductMasters.Add(
                new BusinessModels.ProductMaster()
                {
                    ProductName = "John",
                    Identity = 2,

                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            ProductMasters.Add(
                new BusinessModels.ProductMaster()
                {
                    Identity = 3,

                    ProductName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
