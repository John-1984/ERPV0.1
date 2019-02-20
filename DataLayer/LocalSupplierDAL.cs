using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LocalSupplierDAL
    {
        private static List<BusinessModels.LocalSupplier> LocalSuppliers = new List<BusinessModels.LocalSupplier>();

        public LocalSupplierDAL()
        {
        }

        public BusinessModels.LocalSupplier GetLocalSupplier(Int32 identity)
        {
            var _LocalSupplier = new BusinessModels.LocalSupplier();
            using (var dbContext = new LocalSupplierDbContext())
            {
                _LocalSupplier = dbContext.LocalSupplier
                            .Include("ItemMaster")
                            .Include("Location")
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _LocalSupplier;
        }

        public IEnumerable<BusinessModels.LocalSupplier> GetAll()
        {
            //Need to do
            var _LocalSuppliers = new List<BusinessModels.LocalSupplier>();
            using (var dbContext = new LocalSupplierDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _LocalSuppliers = dbContext.LocalSupplier
                             .Include("ItemMaster")
                            .Include("Location")
                            .ToList();
            }

            return _LocalSuppliers;
        }

        public IEnumerable<BusinessModels.ItemMaster> GetItemMaster()
        {
            var _ItemMasters = new List<BusinessModels.ItemMaster>();
            using (var dbContext = new ItemMasterDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _ItemMasters = dbContext.ItemMaster
                            .ToList();
            }
            return _ItemMasters;
        }

        public IEnumerable<BusinessModels.Location> GetLocation()
        {
            var _Locatiionss = new List<BusinessModels.Location>();
            using (var dbContext = new LocationDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Locatiionss = dbContext.Location
                            .ToList();
            }
            return _Locatiionss;
        }

        public Boolean Update(BusinessModels.LocalSupplier LocalSupplier)
        {
            using (var dbContext = new LocalSupplierDbContext())
            {
                dbContext.Entry(LocalSupplier).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new LocalSupplierDbContext())
            {
                dbContext.Entry(new BusinessModels.LocalSupplier() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.LocalSupplier LocalSupplier)
        {
            using (var dbContext = new LocalSupplierDbContext())
            {
                dbContext.Entry(LocalSupplier).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
