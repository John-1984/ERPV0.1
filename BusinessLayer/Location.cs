using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class Location
    {
        public Location()
        {
            
        }

        private static List<BusinessModels.Location> Locations = new List<BusinessModels.Location>();

       

        public BusinessModels.Location GetLocation(Int32 identity)
        {
            return Locations.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Location> GetAll()
        {
            return Locations;
        }

        public Boolean Delete(Int32 identity)
        {
            Locations.Remove(Locations.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Location Location)
        {
            Locations.Remove(Locations.Find(p => p.Identity.Equals(Location.Identity)));
            Locations.Add(Location);
            return true;
        }

        public Boolean Insert(BusinessModels.Location Location)
        {
            Locations.Add(Location);
            return true;
        }

        public void TestData()
        {
            Locations.Add(
                new BusinessModels.Location()
                {
                    Identity = 1,

                    DistrictID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Locations.Add(
                new BusinessModels.Location()
                {
                    Identity = 2,

                    DistrictID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Locations.Add(
                new BusinessModels.Location()
                {
                    Identity = 3,

                    DistrictID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
