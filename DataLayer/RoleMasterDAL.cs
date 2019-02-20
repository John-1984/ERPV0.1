using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RoleMasterDAL
    {
        private static List<BusinessModels.RoleMaster> RoleMasters = new List<BusinessModels.RoleMaster>();

        public RoleMasterDAL()
        {
        }

        public BusinessModels.RoleMaster GetRoleMaster(Int32 identity)
        {
            var _RoleMaster = new BusinessModels.RoleMaster();
            using (var dbContext = new RoleMasterDbContext())
            {
                _RoleMaster = dbContext.RoleMaster
                            .Include("Region")
                             .Include("Modules")
                             .Include("RoleType")
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _RoleMaster;
        }

        public IEnumerable<BusinessModels.RoleMaster> GetAll()
        {
            //Need to do
            var _RoleMasters = new List<BusinessModels.RoleMaster>();
            using (var dbContext = new RoleMasterDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _RoleMasters = dbContext.RoleMaster
                              .Include("Region")
                             .Include("Modules")
                             .Include("RoleType")
                            .ToList();
            }

            return _RoleMasters;
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

        public IEnumerable<BusinessModels.Modules> GetModules()
        {
            var _Modules = new List<BusinessModels.Modules>();
            using (var dbContext = new ModulesDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Modules = dbContext.Modules
                            .ToList();
            }
            return _Modules;
        }

        public IEnumerable<BusinessModels.RoleType> GetRoleTypes()
        {
            var _RoleTypes = new List<BusinessModels.RoleType>();
            using (var dbContext = new RoleTypeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _RoleTypes = dbContext.RoleType
                            .ToList();
            }
            return _RoleTypes;
        }

        public Boolean Update(BusinessModels.RoleMaster RoleMaster)
        {
            using (var dbContext = new RoleMasterDbContext())
            {
                dbContext.Entry(RoleMaster).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new RoleMasterDbContext())
            {
                dbContext.Entry(new BusinessModels.RoleMaster() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.RoleMaster RoleMaster)
        {
            using (var dbContext = new RoleMasterDbContext())
            {
                dbContext.Entry(RoleMaster).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
