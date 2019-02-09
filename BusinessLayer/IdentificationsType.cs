using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class IdentificationsType
    {
        public IdentificationsType()
        {
            
        }
        private static List<BusinessModels.IdentificationsType> IdentificationsTypes = new List<BusinessModels.IdentificationsType>();

       
        public BusinessModels.IdentificationsType GetIdentificationsType(Int32 identity)
        {
            return IdentificationsTypes.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.IdentificationsType> GetAll()
        {
            return IdentificationsTypes;
        }

        public Boolean Delete(Int32 identity)
        {
            IdentificationsTypes.Remove(IdentificationsTypes.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.IdentificationsType IdentificationsType)
        {
            IdentificationsTypes.Remove(IdentificationsTypes.Find(p => p.Identity.Equals(IdentificationsType.Identity)));
            IdentificationsTypes.Add(IdentificationsType);
            return true;
        }

        public Boolean Insert(BusinessModels.IdentificationsType IdentificationsType)
        {
            IdentificationsTypes.Add(IdentificationsType);
            return true;
        }

        public void TestData()
        {
            IdentificationsTypes.Add(
                new BusinessModels.IdentificationsType()
                {
                    Identity = 1,

                    IdentificationName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            IdentificationsTypes.Add(
                new BusinessModels.IdentificationsType()
                {
                    Identity = 2,

                    IdentificationName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            IdentificationsTypes.Add(
                new BusinessModels.IdentificationsType()
                {
                    Identity = 2,

                    IdentificationName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
