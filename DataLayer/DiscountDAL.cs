using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLayer
{
    public class DiscountDAL
    {
        private static List<BusinessModels.Discount> Discounts = new List<BusinessModels.Discount>();

        public DiscountDAL()
        {
        }

        public BusinessModels.Discount GetDiscount(Int32 identity)
        {
            var _Discount = new BusinessModels.Discount();
            using (var dbContext = new DiscountDbContext())
            {
                _Discount = dbContext.Discount
                             .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Discount;
        }

        public IEnumerable<BusinessModels.Discount> GetAll()
        {
            //Need to do
            var _Discounts = new List<BusinessModels.Discount>();
            using (var dbContext = new DiscountDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Discounts = dbContext.Discount
                             .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                            .ToList();
            }

            return _Discounts;
        }

        public IEnumerable<BusinessModels.Discount> GetAll(int lcdentity)
        {
            //Need to do
            var _Discounts = new List<BusinessModels.Discount>();
            using (var dbContext = new DiscountDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Discounts = dbContext.Discount
                             .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                             .Where(p => p.ItemMaster.Identity == lcdentity)
                            .ToList();
            }

            return _Discounts;
        }

        public IEnumerable<BusinessModels.Discount> GetAllDiscountOnBrand(int lcdentity)
        {
            //Need to do
            var _Discounts = new List<BusinessModels.Discount>();
            using (var dbContext = new DiscountDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Discounts = dbContext.Discount
                             .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                             .Where(p => p.ItemMaster.Brand.Identity == lcdentity)
                            .ToList();
            }

            return _Discounts;
        }

        public IEnumerable<BusinessModels.Discount> GetAllDiscountOnVendor(int lcdentity)
        {
            //Need to do
            var _Discounts = new List<BusinessModels.Discount>();
            using (var dbContext = new DiscountDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Discounts = dbContext.Discount
                             .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                             .Where(p => p.ItemMaster.Brand.Vendor.Identity == lcdentity)
                            .ToList();
            }

            return _Discounts;
        }

        public IEnumerable<BusinessModels.Discount> GetAllDiscountOnProductMaster(int lcdentity)
        {
            //Need to do
            var _Discounts = new List<BusinessModels.Discount>();
            using (var dbContext = new DiscountDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Discounts = dbContext.Discount
                             .Include(K => K.ItemMaster)
                            .Include(l => l.ItemMaster.Brand)
                            .Include(o => o.ItemMaster.Brand.Vendor)
                            .Include(s => s.ItemMaster.Brand.Vendor.ProductMaster)
                             .Where(p => p.ItemMaster.Brand.Vendor.ProductMaster.Identity == lcdentity)
                            .ToList();
            }

            return _Discounts;
        }



        public Boolean Update(BusinessModels.Discount Discount)
        {
            using (var dbContext = new DiscountDbContext())
            {
                dbContext.Entry(Discount).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new DiscountDbContext())
            {
                dbContext.Entry(new BusinessModels.Discount() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.Discount Discount)
        {
            using (var dbContext = new DiscountDbContext())
            {
                dbContext.Entry(Discount).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
