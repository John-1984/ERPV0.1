using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace DataLayer
{
    public class StockInExcessDetailsDAL
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
        private static List<BusinessModels.StockInExcessDetails> StockInExcessDetailss = new List<BusinessModels.StockInExcessDetails>();

        public StockInExcessDetailsDAL()
        {
        }

        public BusinessModels.StockInExcessDetails GetStockInExcessDetails(Int32 identity)
        {
            var _StockInExcessDetails = new BusinessModels.StockInExcessDetails();
            using (var dbContext = new StockInExcessDetailsDbContext())
            {
                _StockInExcessDetails = dbContext.StockInExcessDetails
                             .Include(K => K.PurchaseOrder)
                             .Include(d => d.ItemMaster)
                             .FirstOrDefault(p => p.Identity == identity);
            }
            return _StockInExcessDetails;
        }

        public IEnumerable<BusinessModels.StockInExcessDetails> GetAll()
        {
            var _StockInExcessDetailss = new List<BusinessModels.StockInExcessDetails>();
            using (var dbContext = new StockInExcessDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _StockInExcessDetailss = dbContext.StockInExcessDetails
                             .Include(K => K.PurchaseOrder)
                             .Include(d => d.ItemMaster)
                            .ToList();
            }

            return _StockInExcessDetailss;
        }

        public IEnumerable<BusinessModels.StockInExcessDetails> GetAllByPurchaseOrder(int reqID)
        {
            var _StockInExcessDetailss = new List<BusinessModels.StockInExcessDetails>();
            using (var dbContext = new StockInExcessDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _StockInExcessDetailss = dbContext.StockInExcessDetails
                            .Include(K => K.PurchaseOrder)
                             .Include(d => d.ItemMaster)
                             .Where(p => p.POID == reqID)
                            .ToList();
            }

            return _StockInExcessDetailss;
        }



        public Boolean Update(BusinessModels.StockInExcessDetails StockInExcessDetails)
        {
            using (var dbContext = new StockInExcessDetailsDbContext())
            {
                dbContext.Entry(StockInExcessDetails).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new StockInExcessDetailsDbContext())
            {
                dbContext.Entry(new BusinessModels.StockInExcessDetails() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.StockInExcessDetails Insert(BusinessModels.StockInExcessDetails StockInExcessDetails)
        {
            using (var dbContext = new StockInExcessDetailsDbContext())
            {
                dbContext.Entry(StockInExcessDetails).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return StockInExcessDetails;
        }

    }
}
