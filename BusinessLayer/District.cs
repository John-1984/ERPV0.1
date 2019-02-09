using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class District
    {
        public District()
        {
            if (Districts == null)
                TestData();
        }

        private static List<BusinessModels.District> Districts = new List<BusinessModels.District>();

        
        public BusinessModels.District GetDistrict(Int32 identity)
        {
            return Districts.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.District> GetAll()
        {
            return Districts;
        }

        public Boolean Delete(Int32 identity)
        {
            Districts.Remove(Districts.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.District District)
        {
            Districts.Remove(Districts.Find(p => p.Identity.Equals(District.Identity)));
            Districts.Add(District);
            return true;
        }

        public Boolean Insert(BusinessModels.District District)
        {
            Districts.Add(District);
            return true;
        }

        public void TestData()
        {
            Districts.Add(
                new BusinessModels.District()
                {
                    Identity = 1,

                    DistrictName = "John",
                    StateID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Districts.Add(
                new BusinessModels.District()
                {
                    Identity = 2,

                    DistrictName = "John",
                    StateID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Districts.Add(
                new BusinessModels.District()
                {
                    Identity = 3,

                    DistrictName = "John",
                    StateID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
