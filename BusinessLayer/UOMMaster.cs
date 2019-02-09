using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class UOMMaster
    {
        public UOMMaster()
        {
           
        }
        private static List<BusinessModels.UOMMaster> UOMMasters = new List<BusinessModels.UOMMaster>();

       

        public BusinessModels.UOMMaster GetUOMMaster(Int32 identity)
        {
            return UOMMasters.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.UOMMaster> GetAll()
        {
            return UOMMasters;
        }

        public Boolean Delete(Int32 identity)
        {
            UOMMasters.Remove(UOMMasters.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.UOMMaster UOMMaster)
        {
            UOMMasters.Remove(UOMMasters.Find(p => p.Identity.Equals(UOMMaster.Identity)));
            UOMMasters.Add(UOMMaster);
            return true;
        }

        public Boolean Insert(BusinessModels.UOMMaster UOMMaster)
        {
            UOMMasters.Add(UOMMaster);
            return true;
        }

        public void TestData()
        {
            UOMMasters.Add(
                new BusinessModels.UOMMaster()
                {
                    Identity = 1,

                    UOMName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            UOMMasters.Add(
                new BusinessModels.UOMMaster()
                {
                    Identity = 2,

                    UOMName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            UOMMasters.Add(
                new BusinessModels.UOMMaster()
                {
                    Identity = 3,

                    UOMName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
