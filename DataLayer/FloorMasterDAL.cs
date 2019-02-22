using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLayer
{
    public class FloorMasterDAL
    {
        private static List<BusinessModels.FloorMaster> FloorMasters = new List<BusinessModels.FloorMaster>();

        public FloorMasterDAL()
        {
        }

        public BusinessModels.FloorMaster GetFloorMaster(Int32 identity)
        {
            var _FloorMaster = new BusinessModels.FloorMaster();
            using (var dbContext = new FloorMasterDbContext())
            {
                _FloorMaster = dbContext.FloorMaster
                            .Include(K => K.CompanyType)
                            .Include(K => K.CompanyType.Company)
                            .Include(K => K.CompanyType.Company.Location)
                             .Include(K => K.CompanyType.Company.Location.District)
                            .Include(o => o.CompanyType.Company.Location.District.State)
                            .Include(o => o.CompanyType.Company.Location.District.State.Country)
                            .Include(o => o.CompanyType.Company.Location.District.State.Country.Region)
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _FloorMaster;
        }

        public IEnumerable<BusinessModels.FloorMaster> GetAll()
        {
            //Need to do
            var _FloorMasters = new List<BusinessModels.FloorMaster>();
            using (var dbContext = new FloorMasterDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _FloorMasters = dbContext.FloorMaster
                              .Include(K => K.CompanyType)
                            .Include(K => K.CompanyType.Company)
                            .Include(K => K.CompanyType.Company.Location)
                             .Include(K => K.CompanyType.Company.Location.District)
                            .Include(o => o.CompanyType.Company.Location.District.State)
                            .Include(o => o.CompanyType.Company.Location.District.State.Country)
                            .Include(o => o.CompanyType.Company.Location.District.State.Country.Region)
                            .ToList();
            }

            return _FloorMasters;
        }

        public IEnumerable<BusinessModels.FloorMaster> GetAll(int stidentity)
        {
            //Need to do
            var _FloorMasters = new List<BusinessModels.FloorMaster>();
            using (var dbContext = new FloorMasterDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _FloorMasters = dbContext.FloorMaster
                              .Include(K => K.CompanyType)
                            .Include(K => K.CompanyType.Company)
                            .Include(K => K.CompanyType.Company.Location)
                             .Include(K => K.CompanyType.Company.Location.District)
                            .Include(o => o.CompanyType.Company.Location.District.State)
                            .Include(o => o.CompanyType.Company.Location.District.State.Country)
                            .Include(o => o.CompanyType.Company.Location.District.State.Country.Region)
                             .Where(p => p.CompanyType.Identity == stidentity)
                            .ToList();
            }

            return _FloorMasters;
        }

        public IEnumerable<BusinessModels.Company> GetAllCompanies()
        {
            var _Companies = new List<BusinessModels.Company>();
            using (var dbContext = new CompanyDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Companies = dbContext.Company
                            .ToList();
            }
            return _Companies;
        }

        public IEnumerable<BusinessModels.CompanyType> GetAllCompanyTypes()
        {
            var _CompanyTypes = new List<BusinessModels.CompanyType>();
            using (var dbContext = new CompanyTypeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _CompanyTypes = dbContext.CompanyType
                            .ToList();
            }
            return _CompanyTypes;
        }

        public Boolean Update(BusinessModels.FloorMaster FloorMaster)
        {
            using (var dbContext = new FloorMasterDbContext())
            {
                dbContext.Entry(FloorMaster).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new FloorMasterDbContext())
            {
                dbContext.Entry(new BusinessModels.FloorMaster() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.FloorMaster FloorMaster)
        {
            using (var dbContext = new FloorMasterDbContext())
            {
                dbContext.Entry(FloorMaster).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
