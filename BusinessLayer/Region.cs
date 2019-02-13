using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class Region
    {
        private static List<BusinessModels.Region> Regions = new List<BusinessModels.Region>();

        public Region()
        {
            if (Regions.Count == 0)
                TestData();
        }

        public BusinessModels.Region GetRegion(Int32 identity)
        {
            return Regions.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Region> GetAll()
        {
            return Regions;
        }

        public Boolean Delete(Int32 identity)
        {
            Regions.Remove(Regions.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Region Region)
        {
            Regions.Remove(Regions.Find(p => p.Identity.Equals(Region.Identity)));
            Regions.Add(Region);
            return true;
        }

        public Boolean Insert(BusinessModels.Region Region)
        {
            Regions.Add(Region);
            return true;
        }

        public void TestData()
        {
            for(int i=0;i<=20; i++)
            { 
            Regions.Add(
                new BusinessModels.Region()
                {
                    RegionName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    Identity = 1,

                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Regions.Add(
                new BusinessModels.Region()
                {
                    Identity = 2,

                    RegionName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Regions.Add(
                new BusinessModels.Region()
                {
                    Identity = 3,

                    RegionName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            }
        }

    }


}
