using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CountryDAL
    {
        private static List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();

        public CountryDAL()
        {
        }

        public BusinessModels.Country GetCountry(Int32 identity)
        {
            var _Country = new BusinessModels.Country();
            using (var dbContext = new CountryDbContext())
            {
                _Country = dbContext.Country
                            .Include("Region")
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Country;
        }

        public IEnumerable<BusinessModels.Country> GetAll()
        {
            var _Countrys = new List<BusinessModels.Country>();
            using (var dbContext = new CountryDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Countrys = dbContext.Country
                             .Include("Region")
                            .ToList();
            }

            return _Countrys;
        }
      

        public IEnumerable<BusinessModels.Region> GetRegions()
        {
            var _Regions = new List<BusinessModels.Region>();
            using (var dbContext = new RegionDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Regions = dbContext.Region
                            .ToList();
            }
            return _Regions;
        }

        public Boolean Update(BusinessModels.Country Country)
        {
            using (var dbContext = new CountryDbContext())
            {
                dbContext.Entry(Country).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new CountryDbContext())
            {
                dbContext.Entry(new BusinessModels.Country() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.Country Country)
        {
            using (var dbContext = new CountryDbContext())
            {
                dbContext.Entry(Country).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
