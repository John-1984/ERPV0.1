using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLayer
{
    public class TaxDAL
    {
        private static List<BusinessModels.Tax> Taxs = new List<BusinessModels.Tax>();

        public TaxDAL()
        {
        }

        public BusinessModels.Tax GetTax(Int32 identity)
        {
            var _Tax = new BusinessModels.Tax();
            using (var dbContext = new TaxDbContext())
            {
                _Tax = dbContext.Tax
                             .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Tax;
        }

        public IEnumerable<BusinessModels.Tax> GetAll()
        {
            //Need to do
            var _Taxs = new List<BusinessModels.Tax>();
            using (var dbContext = new TaxDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Taxs = dbContext.Tax
                              .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                            .ToList();
            }

            return _Taxs;
        }


        public IEnumerable<BusinessModels.Tax> GetAll(int lcdentity)
        {
            //Need to do
            var _Taxs = new List<BusinessModels.Tax>();
            using (var dbContext = new TaxDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Taxs = dbContext.Tax
                              .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                            .Where(p => p.ItemMaster.Identity == lcdentity)
                            .ToList();
            }

            return _Taxs;
        }

        public IEnumerable<BusinessModels.Tax> GetAllTaxOnBrand(int lcdentity)
        {
            //Need to do
            var _Taxs = new List<BusinessModels.Tax>();
            using (var dbContext = new TaxDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Taxs = dbContext.Tax
                              .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                            .Where(p => p.ItemMaster.Brand.Identity == lcdentity)
                            .ToList();
            }

            return _Taxs;
        }

        public IEnumerable<BusinessModels.Tax> GetAllTaxOnVendor(int lcdentity)
        {
            //Need to do
            var _Taxs = new List<BusinessModels.Tax>();
            using (var dbContext = new TaxDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Taxs = dbContext.Tax
                              .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                            .Where(p => p.ItemMaster.Brand.Vendor.Identity == lcdentity)
                            .ToList();
            }

            return _Taxs;
        }

        public IEnumerable<BusinessModels.Tax> GetAllTaxOnProductCategory(int lcdentity)
        {
            //Need to do
            var _Taxs = new List<BusinessModels.Tax>();
            using (var dbContext = new TaxDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Taxs = dbContext.Tax
                              .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                            .Where(p => p.ItemMaster.Brand.Vendor.ProductMaster.Identity == lcdentity)
                            .ToList();
            }

            return _Taxs;
        }

        public IEnumerable<BusinessModels.ItemMaster> GetAllItemMaster()
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

        public Boolean Update(BusinessModels.Tax Tax)
        {
            using (var dbContext = new TaxDbContext())
            {
                dbContext.Entry(Tax).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new TaxDbContext())
            {
                dbContext.Entry(new BusinessModels.Tax() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.Tax Tax)
        {
            using (var dbContext = new TaxDbContext())
            {
                dbContext.Entry(Tax).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
