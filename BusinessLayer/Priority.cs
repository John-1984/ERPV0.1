using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class Priority
    {
        public Priority()
        {
            
        }
        private static List<BusinessModels.Priority> Prioritys = new List<BusinessModels.Priority>();

        

        public BusinessModels.Priority GetPriority(Int32 identity)
        {
            return Prioritys.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Priority> GetAll()
        {
            return Prioritys;
        }

        public Boolean Delete(Int32 identity)
        {
            Prioritys.Remove(Prioritys.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Priority Priority)
        {
            Prioritys.Remove(Prioritys.Find(p => p.Identity.Equals(Priority.Identity)));
            Prioritys.Add(Priority);
            return true;
        }

        public Boolean Insert(BusinessModels.Priority Priority)
        {
            Prioritys.Add(Priority);
            return true;
        }

        public void TestData()
        {
            Prioritys.Add(
                new BusinessModels.Priority()
                {
                    Identity = 1,

                    PriorityValue = 1                
                   
                });
            Prioritys.Add(
                new BusinessModels.Priority()
                {
                    Identity = 2,

                    PriorityValue = 1
                });
            Prioritys.Add(
                new BusinessModels.Priority()
                {
                    Identity = 3,

                    PriorityValue = 1
                });
        }

    }


}
