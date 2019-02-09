using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Status
    {
        public Status()
        {
            
        }
        private static List<BusinessModels.Status> Statuss = new List<BusinessModels.Status>();


        public BusinessModels.Status GetStatus(Int32 identity)
        {
            return Statuss.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Status> GetAll()
        {
            return Statuss;
        }

        public Boolean Delete(Int32 identity)
        {
            Statuss.Remove(Statuss.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Status Status)
        {
            Statuss.Remove(Statuss.Find(p => p.Identity.Equals(Status.Identity)));
            Statuss.Add(Status);
            return true;
        }

        public Boolean Insert(BusinessModels.Status Status)
        {
            Statuss.Add(Status);
            return true;
        }

        public void TestData()
        {
            Statuss.Add(
                new BusinessModels.Status()
                {
                    Identity = 1,

                    StatusName = "John"
                   
                });
            Statuss.Add(
                new BusinessModels.Status()
                {
                    Identity = 2,

                    StatusName = "John"
                });
            Statuss.Add(
                new BusinessModels.Status()
                {
                    Identity = 3,

                    StatusName = "John"
                });
        }

    }


}
