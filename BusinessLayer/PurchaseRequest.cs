using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class PurchaseRequest
    {
        public PurchaseRequest()
        {
            
        }

        private static List<BusinessModels.PurchaseRequest> PurchaseRequests = new List<BusinessModels.PurchaseRequest>();

        public BusinessModels.PurchaseRequest GetPurchaseRequest(Int32 identity)
        {
            return PurchaseRequests.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.PurchaseRequest> GetAll()
        {
            return PurchaseRequests;
        }

        public Boolean Delete(Int32 identity)
        {
            PurchaseRequests.Remove(PurchaseRequests.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.PurchaseRequest PurchaseRequest)
        {
            PurchaseRequests.Remove(PurchaseRequests.Find(p => p.Identity.Equals(PurchaseRequest.Identity)));
            PurchaseRequests.Add(PurchaseRequest);
            return true;
        }

        public Boolean Insert(BusinessModels.PurchaseRequest PurchaseRequest)
        {
            PurchaseRequests.Add(PurchaseRequest);
            return true;
        }

        public void TestData()
        {
            PurchaseRequests.Add(
                new BusinessModels.PurchaseRequest()
                {
                    Identity = 1,

                    WarehouseId = 1,
                    Status = 1,
                    LocationID = 1,
                    PurchaseRequestType = 1,
                    CaseNo = "Engg",
                    Comments = "Just So",
                    SOCode = "12",
                    AssignedTo = 1,
                    VerifiedBy = 1,
                    ApprovedBy = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            PurchaseRequests.Add(
                new BusinessModels.PurchaseRequest()
                {
                    Identity = 2,

                    WarehouseId = 1,
                    Status = 1,
                    LocationID = 1,
                    PurchaseRequestType = 1,
                    CaseNo = "Engg",
                    Comments = "Just So",
                    SOCode = "12",
                    AssignedTo = 1,
                    VerifiedBy = 1,
                    ApprovedBy = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            PurchaseRequests.Add(
                new BusinessModels.PurchaseRequest()
                {
                    Identity = 3,

                    WarehouseId = 1,
                    Status = 1,
                    LocationID = 1,
                    PurchaseRequestType = 1,
                    CaseNo = "Engg",
                    Comments = "Just So",
                    SOCode = "12",
                    AssignedTo = 1,
                    VerifiedBy = 1,
                    ApprovedBy = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
