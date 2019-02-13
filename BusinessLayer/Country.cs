using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Country
    {

        public Country()
        {
           // if (Countrys == null)
                
           
        }
        private static List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private static List<BusinessModels.Region> Regions = new List<BusinessModels.Region>();



        public BusinessModels.Country GetCountry(Int32 identity)
        {
            return Countrys.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Country> GetAll()
        {
            TestData();
            return Countrys;
        }

        public IEnumerable<BusinessModels.Region> GetAllRegions()
        {
            TestRegionData();
            return Regions;
        }
        public Boolean Delete(Int32 identity)
        {
            Countrys.Remove(Countrys.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Country Country)
        {
            Countrys.Remove(Countrys.Find(p => p.Identity.Equals(Country.Identity)));
            Countrys.Add(Country);
            return true;
        }

        public Boolean Insert(BusinessModels.Country Country)
        {
            Countrys.Add(Country);
            return true;
        }

        public void TestData()
        {
            Countrys.Add(
                new BusinessModels.Country()
                {
                    Identity = 1,

                    CountryName = "John",
                    RegionID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Countrys.Add(
                new BusinessModels.Country()
                {
                    Identity = 2,

                    CountryName = "John",
                    RegionID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Countrys.Add(
                new BusinessModels.Country()
                {
                    Identity = 3,

                    CountryName = "John",
                    RegionID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

        public void TestRegionData()
        {
            Regions.Add(
                new BusinessModels.Region()
                {
                    Identity = 1,

                    RegionName = "John",
                  
                });
            Regions.Add(
                new BusinessModels.Region()
                {
                    Identity = 1,

                    RegionName = "John",

                });
        }

    }


}
