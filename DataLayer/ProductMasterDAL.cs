using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class ProductMasterDAL
    {
        /// <summary>
        /// Multiple ways of calling EF
        ///     - Simple Query:
        ///         string sql = $@"select ID from User";
        ///         rowId = dbContext.Database.SqlQuery<int>(sql).ToList();
        ///     - Connected/Disconnected Way.
        ///         DisConnected way is used in this application
        ///     - Via Stored Procedures
        ///         Demonstarted in Login Module
        /// </summary>
        private static List<BusinessModels.ProductMaster> ProductMasters = new List<BusinessModels.ProductMaster>();

        public ProductMasterDAL()
        {
        }

        public BusinessModels.ProductMaster GetProductMaster(Int32 identity)
        {
            var _ProductMaster = new BusinessModels.ProductMaster();
            using (var dbContext = new ProductMasterDbContext())
            {
                _ProductMaster = dbContext.ProductMaster
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _ProductMaster;
        }

        public IEnumerable<BusinessModels.ProductMaster> GetAll()
        {
            var _ProductMasters = new List<BusinessModels.ProductMaster>();
            using (var dbContext = new ProductMasterDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _ProductMasters = dbContext.ProductMaster.ToList();
            }

            return _ProductMasters;
        }

        public Boolean Update(BusinessModels.ProductMaster ProductMaster)
        {
            using (var dbContext = new ProductMasterDbContext())
            {
                dbContext.Entry(ProductMaster).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new ProductMasterDbContext())
            {
                dbContext.Entry(new BusinessModels.ProductMaster() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.ProductMaster ProductMaster)
        {
            using (var dbContext = new ProductMasterDbContext())
            {
                dbContext.Entry(ProductMaster).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
