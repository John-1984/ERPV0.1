using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class LocalSupplier
    {
        public LocalSupplier()
        {
            
        }

        private static List<BusinessModels.LocalSupplier> LocalSuppliers = new List<BusinessModels.LocalSupplier>();

        
        public BusinessModels.LocalSupplier GetLocalSupplier(Int32 identity)
        {
            return LocalSuppliers.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.LocalSupplier> GetAll()
        {
            return LocalSuppliers;
        }

        public Boolean Delete(Int32 identity)
        {
            LocalSuppliers.Remove(LocalSuppliers.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.LocalSupplier LocalSupplier)
        {
            LocalSuppliers.Remove(LocalSuppliers.Find(p => p.Identity.Equals(LocalSupplier.Identity)));
            LocalSuppliers.Add(LocalSupplier);
            return true;
        }

        public Boolean Insert(BusinessModels.LocalSupplier LocalSupplier)
        {
            LocalSuppliers.Add(LocalSupplier);
            return true;
        }

        public void TestData()
        {
            LocalSuppliers.Add(
                new BusinessModels.LocalSupplier()
                {
                    Identity = 1,

                    Address = "John",
                    Email = "m@mail.com",
                    ContactNumber = 1,
                    LocationID = 1,
                    ItemID = 1,
                    SupplierName = "Just So",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            LocalSuppliers.Add(
                new BusinessModels.LocalSupplier()
                {
                    Identity = 2,

                    Address = "John",
                    Email = "m@mail.com",
                    ContactNumber = 1,
                    LocationID = 1,
                    ItemID = 1,
                    SupplierName = "Just So",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            LocalSuppliers.Add(
                new BusinessModels.LocalSupplier()
                {
                    Identity = 3,

                    Address = "John",
                    Email = "m@mail.com",
                    ContactNumber = 1,
                    LocationID = 1,
                    ItemID = 1,
                    SupplierName = "Just So",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
