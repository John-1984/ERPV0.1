using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class RoleType
    {
        public RoleType()
        {
           
        }

        private static List<BusinessModels.RoleType> RoleTypes = new List<BusinessModels.RoleType>();

       

        public BusinessModels.RoleType GetRoleType(Int32 identity)
        {
            return RoleTypes.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.RoleType> GetAll()
        {
            return RoleTypes;
        }

        public Boolean Delete(Int32 identity)
        {
            RoleTypes.Remove(RoleTypes.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.RoleType RoleType)
        {
            RoleTypes.Remove(RoleTypes.Find(p => p.Identity.Equals(RoleType.Identity)));
            RoleTypes.Add(RoleType);
            return true;
        }

        public Boolean Insert(BusinessModels.RoleType RoleType)
        {
            RoleTypes.Add(RoleType);
            return true;
        }

        public void TestData()
        {
            RoleTypes.Add(
                new BusinessModels.RoleType()
                {
                    Identity = 1,

                    RoletypeName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            RoleTypes.Add(
                new BusinessModels.RoleType()
                {
                    Identity = 2,

                    RoletypeName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            RoleTypes.Add(
                new BusinessModels.RoleType()
                {
                    Identity = 3,

                    RoletypeName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
