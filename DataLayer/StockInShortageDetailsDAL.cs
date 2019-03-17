using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace DataLayer
{
    public class StockInShortageDetailsDAL
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
        private static List<BusinessModels.StockInShortageDetails> StockInShortageDetailss = new List<BusinessModels.StockInShortageDetails>();

        public StockInShortageDetailsDAL()
        {
        }

        public BusinessModels.StockInShortageDetails GetStockInShortageDetails(Int32 identity)
        {
            var _StockInShortageDetails = new BusinessModels.StockInShortageDetails();
            using (var dbContext = new StockInShortageDetailsDbContext())
            {
                _StockInShortageDetails = dbContext.StockInShortageDetails
                             .Include(K => K.PurchaseOrder)
                             .Include(d => d.ItemMaster)
                             .FirstOrDefault(p => p.Identity == identity);
            }
            return _StockInShortageDetails;
        }

        public IEnumerable<BusinessModels.StockInShortageDetails> GetAll()
        {
            var _StockInShortageDetailss = new List<BusinessModels.StockInShortageDetails>();
            using (var dbContext = new StockInShortageDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _StockInShortageDetailss = dbContext.StockInShortageDetails
                             .Include(K => K.PurchaseOrder)
                             .Include(d => d.ItemMaster)
                            .ToList();
            }

            return _StockInShortageDetailss;
        }

        public IEnumerable<BusinessModels.StockInShortageDetails> GetAllByPurchaseOrder(int reqID)
        {
            var _StockInShortageDetailss = new List<BusinessModels.StockInShortageDetails>();
            using (var dbContext = new StockInShortageDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _StockInShortageDetailss = dbContext.StockInShortageDetails
                            .Include(K => K.PurchaseOrder)
                             .Include(d => d.ItemMaster)
                             .Where(p => p.POID == reqID)
                            .ToList();
            }

            return _StockInShortageDetailss;
        }



        public Boolean Update(BusinessModels.StockInShortageDetails StockInShortageDetails)
        {
            using (var dbContext = new StockInShortageDetailsDbContext())
            {
                dbContext.Entry(StockInShortageDetails).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new StockInShortageDetailsDbContext())
            {
                dbContext.Entry(new BusinessModels.StockInShortageDetails() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.StockInShortageDetails Insert(BusinessModels.StockInShortageDetails StockInShortageDetails)
        {
            using (var dbContext = new StockInShortageDetailsDbContext())
            {
                dbContext.Entry(StockInShortageDetails).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return StockInShortageDetails;
        }

    }
}
