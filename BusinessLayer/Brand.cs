using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class Brand
    {
        public Brand()
        {
            
        }
        private static List<BusinessModels.Brand> Brands = new List<BusinessModels.Brand>();

      

        public BusinessModels.Brand GetBrand(Int32 identity)
        {
            return Brands.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Brand> GetAll()
        {
            return Brands;
        }

        public Boolean Delete(Int32 identity)
        {
            Brands.Remove(Brands.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Brand Brand)
        {
            Brands.Remove(Brands.Find(p => p.Identity.Equals(Brand.Identity)));
            Brands.Add(Brand);
            return true;
        }

        public Boolean Insert(BusinessModels.Brand Brand)
        {
            Brands.Add(Brand);
            return true;
        }

        public void TestData()
        {
            Brands.Add(
                new BusinessModels.Brand()
                {
                    Identity = 1,
                    BrandName = "John",
                    ProductMasterID=1,
                    VendorID=1,                    
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Brands.Add(
                new BusinessModels.Brand()
                {
                    Identity = 2,
                    BrandName = "John",
                    ProductMasterID = 1,
                    VendorID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Brands.Add(
                new BusinessModels.Brand()
                {
                    Identity = 3,
                    BrandName = "John",
                    ProductMasterID = 1,
                    VendorID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
