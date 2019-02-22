using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLayer
{
    public class BrandDAL
    {
        private static List<BusinessModels.Brand> Brands = new List<BusinessModels.Brand>();

        public BrandDAL()
        {
        }

        public BusinessModels.Brand GetBrand(Int32 identity)
        {
            var _Brand = new BusinessModels.Brand();
            using (var dbContext = new BrandDbContext())
            {
                _Brand = dbContext.Brand
                             .Include(K => K.Vendor)
                             .Include(l => l.Vendor.ProductMaster)
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Brand;
        }

        public IEnumerable<BusinessModels.Brand> GetAll()
        {
            //Need to do
            var _Brands = new List<BusinessModels.Brand>();
            using (var dbContext = new BrandDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Brands = dbContext.Brand
                             .Include(K => K.Vendor)
                             .Include(l => l.Vendor.ProductMaster)
                            .ToList();
            }

            return _Brands;
        }

        public IEnumerable<BusinessModels.Brand> GetAll(int bridentity)
        {
            //Need to do
            var _Brands = new List<BusinessModels.Brand>();
            using (var dbContext = new BrandDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Brands = dbContext.Brand
                            .Include(K => K.Vendor)
                            .Include(l => l.Vendor.ProductMaster)
                            .Where(p => p.Vendor.Identity == bridentity)
                            .ToList();
            }

            return _Brands;
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

        public Boolean Update(BusinessModels.Brand Brand)
        {
            using (var dbContext = new BrandDbContext())
            {
                dbContext.Entry(Brand).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new BrandDbContext())
            {
                dbContext.Entry(new BusinessModels.Brand() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.Brand Brand)
        {
            using (var dbContext = new BrandDbContext())
            {
                dbContext.Entry(Brand).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
