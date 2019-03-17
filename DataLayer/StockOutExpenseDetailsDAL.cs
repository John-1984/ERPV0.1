using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace DataLayer
{
    public class StockOutExpenseDetailsDAL
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
        private static List<BusinessModels.StockOutExpenseDetails> StockOutExpenseDetailss = new List<BusinessModels.StockOutExpenseDetails>();

        public StockOutExpenseDetailsDAL()
        {
        }

        public BusinessModels.StockOutExpenseDetails GetStockOutExpenseDetails(Int32 identity)
        {
            var _StockOutExpenseDetails = new BusinessModels.StockOutExpenseDetails();
            using (var dbContext = new StockOutExpenseDetailsDbContext())
            {
                _StockOutExpenseDetails = dbContext.StockOutExpenseDetails
                             .Include(K => K.SalesQuotation)
                             .Include(l => l.ExpenseType)
                             .FirstOrDefault(p => p.Identity == identity);
            }
            return _StockOutExpenseDetails;
        }

        public IEnumerable<BusinessModels.StockOutExpenseDetails> GetAll()
        {
            var _StockOutExpenseDetailss = new List<BusinessModels.StockOutExpenseDetails>();
            using (var dbContext = new StockOutExpenseDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _StockOutExpenseDetailss = dbContext.StockOutExpenseDetails
                             .Include(K => K.SalesQuotation)
                             .Include(l => l.ExpenseType)
                            .ToList();
            }

            return _StockOutExpenseDetailss;
        }

        public BusinessModels.StockOutExpenseDetails GetAllBySalesQuotation(int reqID)
        {
            var _StockOutExpenseDetailss = new BusinessModels.StockOutExpenseDetails();
            using (var dbContext = new StockOutExpenseDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _StockOutExpenseDetailss = dbContext.StockOutExpenseDetails
                            .Include(K => K.SalesQuotation)
                            .Include(l => l.ExpenseType)
                             .Where(p => p.SQID == reqID)
                            .FirstOrDefault(); 
            }

            return _StockOutExpenseDetailss;
        }


        public IEnumerable<BusinessModels.StockOutExpenseDetails> GetAllExpenseBySQ(int? identity)
        {
            var _SQAdvanceDetailss = new List<BusinessModels.StockOutExpenseDetails>();
            using (var dbContext = new StockOutExpenseDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _SQAdvanceDetailss = dbContext.StockOutExpenseDetails
                     .Include(K => K.SalesQuotation)
                            .Include(l => l.ExpenseType).Where(s => s.SQID == identity).ToList();
            }

            return _SQAdvanceDetailss;
        }


        public Boolean Update(BusinessModels.StockOutExpenseDetails StockOutExpenseDetails)
        {
            using (var dbContext = new StockOutExpenseDetailsDbContext())
            {
                dbContext.Entry(StockOutExpenseDetails).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new StockOutExpenseDetailsDbContext())
            {
                dbContext.Entry(new BusinessModels.StockOutExpenseDetails() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.StockOutExpenseDetails Insert(BusinessModels.StockOutExpenseDetails StockOutExpenseDetails)
        {
            using (var dbContext = new StockOutExpenseDetailsDbContext())
            {
                dbContext.Entry(StockOutExpenseDetails).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return StockOutExpenseDetails;
        }

    }
}
