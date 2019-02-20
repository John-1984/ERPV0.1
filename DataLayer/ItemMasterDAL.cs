using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                            .Include("Vendor")
                            .Include("Brand")
                            .Include("UOMMaster")
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
                             .Include("Vendor")
                            .Include("Brand")
                            .Include("UOMMaster")
                            .ToList();
            }

            return _ItemMasters;
        }

        public IEnumerable<BusinessModels.Vendor> GetVendors()
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

        public IEnumerable<BusinessModels.Brand> GetBrands()
        {
            var _Brands = new List<BusinessModels.Brand>();
            using (var dbContext = new BrandDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Brands = dbContext.Brand
                            .ToList();
            }
            return _Brands;
        }

        public IEnumerable<BusinessModels.UOMMaster> GetUOMs()
        {
            var _UOMs = new List<BusinessModels.UOMMaster>();
            using (var dbContext = new UOMMasterDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _UOMs = dbContext.UOMMaster
                            .ToList();
            }
            return _UOMs;
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
