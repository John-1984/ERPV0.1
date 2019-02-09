using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class CallCenterDetails
    {
        public CallCenterDetails()
        {
           
        }
        private static List<BusinessModels.CallCenterDetails> CallCenterDetailss = new List<BusinessModels.CallCenterDetails>();


        public BusinessModels.CallCenterDetails GetCallCenterDetails(Int32 identity)
        {
            return CallCenterDetailss.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.CallCenterDetails> GetAll()
        {
            return CallCenterDetailss;
        }

        public Boolean Delete(Int32 identity)
        {
            CallCenterDetailss.Remove(CallCenterDetailss.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.CallCenterDetails CallCenterDetails)
        {
            CallCenterDetailss.Remove(CallCenterDetailss.Find(p => p.Identity.Equals(CallCenterDetails.Identity)));
            CallCenterDetailss.Add(CallCenterDetails);
            return true;
        }

        public Boolean Insert(BusinessModels.CallCenterDetails CallCenterDetails)
        {
            CallCenterDetailss.Add(CallCenterDetails);
            return true;
        }

        public void TestData()
        {
            CallCenterDetailss.Add(
                new BusinessModels.CallCenterDetails()
                {
                    Comments = "John",
                    Time = Convert.ToDecimal("0.00"),
                    Identity = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            CallCenterDetailss.Add(
                new BusinessModels.CallCenterDetails()
                {
                    
                    Comments = "John",
                    Time = Convert.ToDecimal("0.00"),
                    Identity = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            CallCenterDetailss.Add(
                new BusinessModels.CallCenterDetails()
                {
                    Comments = "John",
                    Time = Convert.ToDecimal("0.00"),
                    Identity = 3,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
