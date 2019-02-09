using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class RoleEscalation
    {
        public RoleEscalation()
        {
        }

        private static List<BusinessModels.RoleEscalation> RoleEscalations = new List<BusinessModels.RoleEscalation>();

     

        public BusinessModels.RoleEscalation GetRoleEscalation(Int32 identity)
        {
            return RoleEscalations.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.RoleEscalation> GetAll()
        {
            return RoleEscalations;
        }

        public Boolean Delete(Int32 identity)
        {
            RoleEscalations.Remove(RoleEscalations.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.RoleEscalation RoleEscalation)
        {
            RoleEscalations.Remove(RoleEscalations.Find(p => p.Identity.Equals(RoleEscalation.Identity)));
            RoleEscalations.Add(RoleEscalation);
            return true;
        }

        public Boolean Insert(BusinessModels.RoleEscalation RoleEscalation)
        {
            RoleEscalations.Add(RoleEscalation);
            return true;
        }

        public void TestData()
        {
            RoleEscalations.Add(
                new BusinessModels.RoleEscalation()
                {

                    RoleID = 1,
                    RoleManagerID = 1,
                    Identity = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            RoleEscalations.Add(
                new BusinessModels.RoleEscalation()
                {
                    RoleID = 1,
                    RoleManagerID = 1,
                    Identity = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            RoleEscalations.Add(
                new BusinessModels.RoleEscalation()
                {
                    RoleID = 1,
                    RoleManagerID = 1,
                    Identity = 3,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
