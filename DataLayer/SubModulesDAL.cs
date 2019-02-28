using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLayer
{
    public class SubModulesDAL
    {
        private static List<BusinessModels.SubModules> SubModuless = new List<BusinessModels.SubModules>();

        public SubModulesDAL()
        {
        }

        public BusinessModels.SubModules GetSubModules(Int32 identity)
        {
            var _SubModules = new BusinessModels.SubModules();
            using (var dbContext = new SubModulesDbContext())
            {
                _SubModules = dbContext.SubModules
                             .Include(K => K.Modules)
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _SubModules;
        }

        public IEnumerable<BusinessModels.SubModules> GetAll()
        {
            //Need to do
            var _SubModuless = new List<BusinessModels.SubModules>();
            using (var dbContext = new SubModulesDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _SubModuless = dbContext.SubModules
                             .Include(K => K.Modules)
                            .ToList();
            }

            return _SubModuless;
        }

        public IEnumerable<BusinessModels.SubModules> GetAll(int bridentity)
        {
            //Need to do
            var _SubModuless = new List<BusinessModels.SubModules>();
            using (var dbContext = new SubModulesDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _SubModuless = dbContext.SubModules
                           .Include(K => K.Modules)
                            .Where(p => p.Modules.Identity == bridentity)
                            .ToList();
            }

            return _SubModuless;
        }

        public IEnumerable<BusinessModels.Vendor> GetVendor()
        {
            var _Vendors = new List<BusinessModels.Vendor>();
            using (var dbContext = new VendorDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Vendors = dbContext.Vendor
                            .ToList();
            }
            return _Vendors;
        }

        public Boolean Update(BusinessModels.SubModules SubModules)
        {
            using (var dbContext = new SubModulesDbContext())
            {
                dbContext.Entry(SubModules).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new SubModulesDbContext())
            {
                dbContext.Entry(new BusinessModels.SubModules() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.SubModules SubModules)
        {
            using (var dbContext = new SubModulesDbContext())
            {
                dbContext.Entry(SubModules).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
