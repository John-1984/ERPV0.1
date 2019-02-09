using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class CallCenter
    {
        public CallCenter()
        {
           
        }

        private static List<BusinessModels.CallCenter> CallCenters = new List<BusinessModels.CallCenter>();

        public BusinessModels.CallCenter GetCallCenter(Int32 identity)
        {
            return CallCenters.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.CallCenter> GetAll()
        {
            return CallCenters;
        }

        public Boolean Delete(Int32 identity)
        {
            CallCenters.Remove(CallCenters.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.CallCenter CallCenter)
        {
            CallCenters.Remove(CallCenters.Find(p => p.Identity.Equals(CallCenter.Identity)));
            CallCenters.Add(CallCenter);
            return true;
        }

        public Boolean Insert(BusinessModels.CallCenter CallCenter)
        {
            CallCenters.Add(CallCenter);
            return true;
        }

        public void TestData()
        {
            CallCenters.Add(
                new BusinessModels.CallCenter()
                {
                    Identity = 1,
                    CustomerID = 1,
                    ProductEnquriyID = 1,
                    Status = 1,
                    AssignedTo = 1,
                    VerifiedBy = 1,
                    ApprovedBy = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            CallCenters.Add(
                new BusinessModels.CallCenter()
                {
                    Identity = 2,
                    CustomerID = 1,
                    ProductEnquriyID = 1,
                    Status = 1,
                    AssignedTo = 1,
                    VerifiedBy = 1,
                    ApprovedBy = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            CallCenters.Add(
                new BusinessModels.CallCenter()
                {
                    Identity = 3,
                    CustomerID = 1,
                    ProductEnquriyID = 1,
                    Status = 1,
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
