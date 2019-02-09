using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class PurchaseRequestDetails
    {
        public PurchaseRequestDetails()
        {
          
        }

        private static List<BusinessModels.PurchaseRequestDetails> PurchaseRequestDetailss = new List<BusinessModels.PurchaseRequestDetails>();


        public BusinessModels.PurchaseRequestDetails GetPurchaseRequestDetails(Int32 identity)
        {
            return PurchaseRequestDetailss.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.PurchaseRequestDetails> GetAll()
        {
            return PurchaseRequestDetailss;
        }

        public Boolean Delete(Int32 identity)
        {
            PurchaseRequestDetailss.Remove(PurchaseRequestDetailss.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.PurchaseRequestDetails PurchaseRequestDetails)
        {
            PurchaseRequestDetailss.Remove(PurchaseRequestDetailss.Find(p => p.Identity.Equals(PurchaseRequestDetails.Identity)));
            PurchaseRequestDetailss.Add(PurchaseRequestDetails);
            return true;
        }

        public Boolean Insert(BusinessModels.PurchaseRequestDetails PurchaseRequestDetails)
        {
            PurchaseRequestDetailss.Add(PurchaseRequestDetails);
            return true;
        }

        public void TestData()
        {
            PurchaseRequestDetailss.Add(
                new BusinessModels.PurchaseRequestDetails()
                {
                    Identity = 1,

                    ItemID = 1,
                    ItemPrice = Convert.ToDecimal("0,.0"),
                    ItemSize = "1*45",
                    Quantity = 1,
                    PurchaseRequestID =1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            PurchaseRequestDetailss.Add(
                new BusinessModels.PurchaseRequestDetails()
                {
                    Identity = 2,

                    ItemID = 1,
                    ItemPrice = Convert.ToDecimal("0,.0"),
                    ItemSize = "1*45",
                    Quantity = 1,
                    PurchaseRequestID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            PurchaseRequestDetailss.Add(
                new BusinessModels.PurchaseRequestDetails()
                {
                    Identity = 3,

                    ItemID = 1,
                    ItemPrice = Convert.ToDecimal("0,.0"),
                    ItemSize = "1*45",
                    Quantity = 1,
                    PurchaseRequestID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
