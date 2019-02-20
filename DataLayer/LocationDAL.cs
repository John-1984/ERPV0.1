using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LocationDAL
    {
        private static List<BusinessModels.Location> Locations = new List<BusinessModels.Location>();

        public LocationDAL()
        {
        }

        public BusinessModels.Location GetLocation(Int32 identity)
        {
            var _Location = new BusinessModels.Location();
            using (var dbContext = new LocationDbContext())
            {
                _Location = dbContext.Location
                            .Include("District")
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Location;
        }

        public IEnumerable<BusinessModels.Location> GetAll()
        {
            //Need to do
            var _Locations = new List<BusinessModels.Location>();
            using (var dbContext = new LocationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Locations = dbContext.Location
                             .Include("District")
                            .ToList();
            }

            return _Locations;
        }

        public IEnumerable<BusinessModels.Country> GetCountry()
        {
            var _Countrys = new List<BusinessModels.Country>();
            using (var dbContext = new CountryDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Countrys = dbContext.Country
                            .ToList();
            }
            return _Countrys;
        }

        public Boolean Update(BusinessModels.Location Location)
        {
            using (var dbContext = new LocationDbContext())
            {
                dbContext.Entry(Location).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new LocationDbContext())
            {
              dbContext.Entry(new BusinessModels.Location() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.Location Location)
        {
            using (var dbContext = new LocationDbContext())
            {
               dbContext.Entry(Location).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
