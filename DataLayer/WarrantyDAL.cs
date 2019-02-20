using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class WarrantyDAL
    {
        private static List<BusinessModels.Warranty> Warrantys = new List<BusinessModels.Warranty>();

        public WarrantyDAL()
        {
        }

        public BusinessModels.Warranty GetWarranty(Int32 identity)
        {
            var _Warranty = new BusinessModels.Warranty();
            using (var dbContext = new WarrantyDbContext())
            {
                _Warranty = dbContext.Warranty
                            .Include("ItemMaster")
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Warranty;
        }

        public IEnumerable<BusinessModels.Warranty> GetAll()
        {
            //Need to do
            var _Warrantys = new List<BusinessModels.Warranty>();
            using (var dbContext = new WarrantyDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Warrantys = dbContext.Warranty
                             .Include("ItemMaster")
                            .ToList();
            }

            return _Warrantys;
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

        public Boolean Update(BusinessModels.Warranty Warranty)
        {
            using (var dbContext = new WarrantyDbContext())
            {
                dbContext.Entry(Warranty).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new WarrantyDbContext())
            {
                dbContext.Entry(new BusinessModels.Warranty() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.Warranty Warranty)
        {
            using (var dbContext = new WarrantyDbContext())
            {
                dbContext.Entry(Warranty).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
