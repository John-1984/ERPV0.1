using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
    public class DistrictDAL
    {
        private static List<BusinessModels.District> Districts = new List<BusinessModels.District>();

        public DistrictDAL()
        {
        }

        public BusinessModels.District GetDistrict(Int32 identity)
        {
            var _District = new BusinessModels.District();
            using (var dbContext = new DistrictDbContext())
            {
                _District = dbContext.District
                            .Include(K => K.State)
                            .Include(o => o.State.Country)
                            .Include(o => o.State.Country.Region)
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _District;
        }

        public IEnumerable<BusinessModels.District> GetAll()
        {
            //Need to do
            var _Districts = new List<BusinessModels.District>();
            using (var dbContext = new DistrictDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Districts = dbContext.District
                             .Include(K => K.State)
                            .Include(o => o.State.Country)
                            .Include(o => o.State.Country.Region)
                            .ToList();
            }

            return _Districts;
        }

        public IEnumerable<BusinessModels.District> GetAll(int stidentity)
        {
            var _Districts = new List<BusinessModels.District>();
            using (var dbContext = new DistrictDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Districts = dbContext.District
                             .Include(K => K.State)
                            .Include(o => o.State.Country)
                            .Include(o => o.State.Country.Region).Where(p => p.State.Identity == stidentity)
                            .ToList();
            }

            return _Districts;
        }
        

        public Boolean Update(BusinessModels.District District)
        {
            using (var dbContext = new DistrictDbContext())
            {
                dbContext.Entry(District).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }
        
        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new DistrictDbContext())
            {
                dbContext.Entry(new BusinessModels.District() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.District District)
        {
            using (var dbContext = new DistrictDbContext())
            {
                dbContext.Entry(District).State= System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
