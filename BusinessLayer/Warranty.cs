using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Warranty
    {
        private static List<BusinessModels.Warranty> Warrantys = new List<BusinessModels.Warranty>();

        public Warranty()
        {
            if (Warrantys.Count == 0)
                TestData();
        }

        public BusinessModels.Warranty GetWarranty(Int32 identity)
        {
            return Warrantys.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Warranty> GetAll()
        {
            return Warrantys;
        }

        public Boolean Delete(Int32 identity)
        {
            Warrantys.Remove(Warrantys.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Warranty Warranty)
        {
            Warrantys.Remove(Warrantys.Find(p => p.Identity.Equals(Warranty.Identity)));
            Warrantys.Add(Warranty);
            return true;
        }

        public Boolean Insert(BusinessModels.Warranty Warranty)
        {
            Warrantys.Add(Warranty);
            return true;
        }

        public void TestData()
        {
            Warrantys.Add(
                new BusinessModels.Warranty()
                {
                    Identity=1,
                    WarrantyValue = 10,
                    ItemID = 1,
                    CreatedDate =DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy=1,
                    ModifiedBy =1
                    
                });
            Warrantys.Add(
                new BusinessModels.Warranty()
                {
                    Identity = 2,
                    WarrantyValue = 10,
                    ItemID = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                });
            Warrantys.Add(
                new BusinessModels.Warranty()
                {
                    Identity = 3,
                    WarrantyValue = 10,
                    ItemID = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                });
        }

    }


}
