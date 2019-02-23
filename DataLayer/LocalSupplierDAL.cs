using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
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
                            .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                            .Include(y => y.Location)
                            .Include(r => r.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
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
                             .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                            .Include(y => y.Location)
                             .Include(r => r.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .ToList();
            }

            return _LocalSuppliers;
        }

        public IEnumerable<BusinessModels.LocalSupplier> GetAll(int lcdentity)
        {
            //Need to do
            var _LocalSuppliers = new List<BusinessModels.LocalSupplier>();
            using (var dbContext = new LocalSupplierDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _LocalSuppliers = dbContext.LocalSupplier
                             .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                            .Include(y => y.Location)
                            .Include(r => r.Location.District)
                            .Include(f => f.Location.District.State)
                            .Include(j => j.Location.District.State.Country)
                            .Include(m => m.Location.District.State.Country.Region)
                            .Where(p => p.ItemMaster.Identity == lcdentity)
                            .ToList();
            }

            return _LocalSuppliers;
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
