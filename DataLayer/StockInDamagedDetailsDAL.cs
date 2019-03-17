using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace DataLayer
{
    public class StockInDamagedDetailsDAL
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
        private static List<BusinessModels.StockInDamagedDetails> StockInDamagedDetailss = new List<BusinessModels.StockInDamagedDetails>();

        public StockInDamagedDetailsDAL()
        {
        }

        public BusinessModels.StockInDamagedDetails GetStockInDamagedDetails(Int32 identity)
        {
            var _StockInDamagedDetails = new BusinessModels.StockInDamagedDetails();
            using (var dbContext = new StockInDamagedDetailsDbContext())
            {
                _StockInDamagedDetails = dbContext.StockInDamagedDetails
                             .Include(K => K.PurchaseOrder)
                             .Include(d => d.ItemMaster)                            
                             .FirstOrDefault(p => p.Identity == identity);
            }
            return _StockInDamagedDetails;
        }

        public IEnumerable<BusinessModels.StockInDamagedDetails> GetAll()
        {
            var _StockInDamagedDetailss = new List<BusinessModels.StockInDamagedDetails>();
            using (var dbContext = new StockInDamagedDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _StockInDamagedDetailss = dbContext.StockInDamagedDetails
                             .Include(K => K.PurchaseOrder)
                             .Include(d => d.ItemMaster)
                            .ToList();
            }

            return _StockInDamagedDetailss;
        }

        public IEnumerable<BusinessModels.StockInDamagedDetails> GetAllByPurchaseOrder(int reqID)
        {
            var _StockInDamagedDetailss = new List<BusinessModels.StockInDamagedDetails>();
            using (var dbContext = new StockInDamagedDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _StockInDamagedDetailss = dbContext.StockInDamagedDetails
                            .Include(K => K.PurchaseOrder)
                             .Include(d => d.ItemMaster)
                             .Where(p => p.POID == reqID)
                            .ToList();
            }

            return _StockInDamagedDetailss;
        }  

    

        public Boolean Update(BusinessModels.StockInDamagedDetails StockInDamagedDetails)
        {
            using (var dbContext = new StockInDamagedDetailsDbContext())
            {
                dbContext.Entry(StockInDamagedDetails).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new StockInDamagedDetailsDbContext())
            {
                dbContext.Entry(new BusinessModels.StockInDamagedDetails() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.StockInDamagedDetails Insert(BusinessModels.StockInDamagedDetails StockInDamagedDetails)
        {
            using (var dbContext = new StockInDamagedDetailsDbContext())
            {
                dbContext.Entry(StockInDamagedDetails).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return StockInDamagedDetails;
        }

    }
}
