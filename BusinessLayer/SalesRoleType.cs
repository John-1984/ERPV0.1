using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class SalesRoleType
    {
        public SalesRoleType()
        {
           
        }

        private static List<BusinessModels.SalesRoleType> SalesRoleTypes = new List<BusinessModels.SalesRoleType>();

      

        public BusinessModels.SalesRoleType GetSalesRoleType(Int32 identity)
        {
            return SalesRoleTypes.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.SalesRoleType> GetAll()
        {
            return SalesRoleTypes;
        }

        public Boolean Delete(Int32 identity)
        {
            SalesRoleTypes.Remove(SalesRoleTypes.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.SalesRoleType SalesRoleType)
        {
            SalesRoleTypes.Remove(SalesRoleTypes.Find(p => p.Identity.Equals(SalesRoleType.Identity)));
            SalesRoleTypes.Add(SalesRoleType);
            return true;
        }

        public Boolean Insert(BusinessModels.SalesRoleType SalesRoleType)
        {
            SalesRoleTypes.Add(SalesRoleType);
            return true;
        }

        public void TestData()
        {
            SalesRoleTypes.Add(
                new BusinessModels.SalesRoleType()
                {
                    Identity = 1,

                    TypeName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            SalesRoleTypes.Add(
                new BusinessModels.SalesRoleType()
                {
                    Identity = 2,

                    TypeName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            SalesRoleTypes.Add(
                new BusinessModels.SalesRoleType()
                {
                    Identity = 3,

                    TypeName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
