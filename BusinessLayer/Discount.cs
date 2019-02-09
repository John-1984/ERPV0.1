using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class Discount
    {
        public Discount()
        {
          
        }

        private static List<BusinessModels.Discount> Discounts = new List<BusinessModels.Discount>();

        

        public BusinessModels.Discount GetDiscount(Int32 identity)
        {
            return Discounts.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Discount> GetAll()
        {
            return Discounts;
        }

        public Boolean Delete(Int32 identity)
        {
            Discounts.Remove(Discounts.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Discount Discount)
        {
            Discounts.Remove(Discounts.Find(p => p.Identity.Equals(Discount.Identity)));
            Discounts.Add(Discount);
            return true;
        }

        public Boolean Insert(BusinessModels.Discount Discount)
        {
            Discounts.Add(Discount);
            return true;
        }

        public void TestData()
        {
            Discounts.Add(
                new BusinessModels.Discount()
                {
                    Identity = 1,

                    DiscountValue = 1,
                    BrandID= 1,
                    ItemID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Discounts.Add(
                new BusinessModels.Discount()
                {
                    Identity = 2,

                    DiscountValue = 1,
                    BrandID = 1,
                    ItemID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Discounts.Add(
                new BusinessModels.Discount()
                {
                    Identity = 3,

                    DiscountValue = 1,
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
