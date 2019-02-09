using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Tax
    {
        public Tax()
        {
          
        }

        private static List<BusinessModels.Tax> Taxs = new List<BusinessModels.Tax>();


        public BusinessModels.Tax GetTax(Int32 identity)
        {
            return Taxs.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Tax> GetAll()
        {
            return Taxs;
        }

        public Boolean Delete(Int32 identity)
        {
            Taxs.Remove(Taxs.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Tax Tax)
        {
            Taxs.Remove(Taxs.Find(p => p.Identity.Equals(Tax.Identity)));
            Taxs.Add(Tax);
            return true;
        }

        public Boolean Insert(BusinessModels.Tax Tax)
        {
            Taxs.Add(Tax);
            return true;
        }

        public void TestData()
        {
            Taxs.Add(
                new BusinessModels.Tax()
                {
                    Identity = 1,

                    TaxValue = 10,
                    BrandID=1,
                    ItemID=1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Taxs.Add(
                new BusinessModels.Tax()
                {
                    Identity = 2,

                    TaxValue = 10,
                    BrandID = 1,
                    ItemID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Taxs.Add(
                new BusinessModels.Tax()
                {
                    Identity = 3,

                    TaxValue = 10,
                    BrandID = 1,
                    ItemID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
