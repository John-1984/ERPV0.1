using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLayer
{
    public class ItemMasterDAL
    {
        private static List<BusinessModels.ItemMaster> ItemMasters = new List<BusinessModels.ItemMaster>();

        public ItemMasterDAL()
        {
        }

        public BusinessModels.ItemMaster GetItemMaster(Int32 identity)
        {
            var _ItemMaster = new BusinessModels.ItemMaster();
            using (var dbContext = new ItemMasterDbContext())
            {
                _ItemMaster = dbContext.ItemMaster
                            .Include(K => K.Brand)
                            .Include(K => K.UOMMaster)
                            .Include(K => K.Brand.Vendor)
                            .Include(K => K.Brand.Vendor.ProductMaster)
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _ItemMaster;
        }

        public IEnumerable<BusinessModels.ItemMaster> GetAll()
        {
            //Need to do
            var _ItemMasters = new List<BusinessModels.ItemMaster>();
            using (var dbContext = new ItemMasterDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _ItemMasters = dbContext.ItemMaster
                             .Include(K => K.Brand)
                            .Include(l => l.UOMMaster)
                            .Include(o => o.Brand.Vendor)
                            .Include(s => s.Brand.Vendor.ProductMaster)
                            .ToList();
            }

            return _ItemMasters;
        }

        public IEnumerable<BusinessModels.ItemMaster> GetAll(int bridentity)
        {
            //Need to do
            var _ItemMasters = new List<BusinessModels.ItemMaster>();
            using (var dbContext = new ItemMasterDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _ItemMasters = dbContext.ItemMaster
                             .Include(K => K.Brand)
                            .Include(l => l.UOMMaster)
                            .Include(o => o.Brand.Vendor)
                            .Include(s => s.Brand.Vendor.ProductMaster)
                            .Where(p => p.Brand.Identity == bridentity)
                            .ToList();
            }

            return _ItemMasters;
        }
       
        public Boolean Update(BusinessModels.ItemMaster ItemMaster)
        {
            using (var dbContext = new ItemMasterDbContext())
            {
                dbContext.Entry(ItemMaster).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new ItemMasterDbContext())
            {
                dbContext.Entry(new BusinessModels.ItemMaster() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.ItemMaster ItemMaster)
        {
            using (var dbContext = new ItemMasterDbContext())
            {
                dbContext.Entry(ItemMaster).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
