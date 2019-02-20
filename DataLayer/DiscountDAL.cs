using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                            .Include("ItemMaster")
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
                             .Include("ItemMaster")
                            .ToList();
            }

            return _Discounts;
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
