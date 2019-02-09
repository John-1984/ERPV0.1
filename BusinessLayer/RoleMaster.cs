using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class RoleMaster
    {
        public RoleMaster()
        {
           
        }

        private static List<BusinessModels.RoleMaster> RoleMasters = new List<BusinessModels.RoleMaster>();

       
        public BusinessModels.RoleMaster GetRoleMaster(Int32 identity)
        {
            return RoleMasters.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.RoleMaster> GetAll()
        {
            return RoleMasters;
        }

        public Boolean Delete(Int32 identity)
        {
            RoleMasters.Remove(RoleMasters.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.RoleMaster RoleMaster)
        {
            RoleMasters.Remove(RoleMasters.Find(p => p.Identity.Equals(RoleMaster.Identity)));
            RoleMasters.Add(RoleMaster);
            return true;
        }

        public Boolean Insert(BusinessModels.RoleMaster RoleMaster)
        {
            RoleMasters.Add(RoleMaster);
            return true;
        }

        public void TestData()
        {
            RoleMasters.Add(
                new BusinessModels.RoleMaster()
                {
                    Identity = 1,

                    RoleTypeID = 1,
                    RoleName = "John",
                    RegionID=1,
                    ModuleID=1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            RoleMasters.Add(
                new BusinessModels.RoleMaster()
                {
                    Identity = 2,

                    RoleTypeID = 1,
                    RoleName = "John",
                    RegionID = 1,
                    ModuleID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            RoleMasters.Add(
                new BusinessModels.RoleMaster()
                {
                    Identity = 3,

                    RoleTypeID = 1,
                    RoleName = "John",
                    RegionID = 1,
                    ModuleID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
