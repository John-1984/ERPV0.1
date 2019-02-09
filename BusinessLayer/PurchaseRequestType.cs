using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class PurchaseRequestType
    {
        public PurchaseRequestType()
        {
           
        }

        private static List<BusinessModels.PurchaseRequestType> PurchaseRequestTypes = new List<BusinessModels.PurchaseRequestType>();

       

        public BusinessModels.PurchaseRequestType GetPurchaseRequestType(Int32 identity)
        {
            return PurchaseRequestTypes.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.PurchaseRequestType> GetAll()
        {
            return PurchaseRequestTypes;
        }

        public Boolean Delete(Int32 identity)
        {
            PurchaseRequestTypes.Remove(PurchaseRequestTypes.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.PurchaseRequestType PurchaseRequestType)
        {
            PurchaseRequestTypes.Remove(PurchaseRequestTypes.Find(p => p.Identity.Equals(PurchaseRequestType.Identity)));
            PurchaseRequestTypes.Add(PurchaseRequestType);
            return true;
        }

        public Boolean Insert(BusinessModels.PurchaseRequestType PurchaseRequestType)
        {
            PurchaseRequestTypes.Add(PurchaseRequestType);
            return true;
        }

        public void TestData()
        {
            PurchaseRequestTypes.Add(
                new BusinessModels.PurchaseRequestType()
                {
                    Identity = 1,

                    Name = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            PurchaseRequestTypes.Add(
                new BusinessModels.PurchaseRequestType()
                {
                    Identity = 2,

                    Name = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            PurchaseRequestTypes.Add(
                new BusinessModels.PurchaseRequestType()
                {
                    Identity = 3,

                    Name = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
