using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class StockOutDetailsDAL
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
        private static List<BusinessModels.StockOutDetails> StockOutDetailss = new List<BusinessModels.StockOutDetails>();

        public StockOutDetailsDAL()
        {
        }

        public BusinessModels.StockOutDetails GetStockOutDetails(Int32 identity)
        {
            var _StockOutDetails = new BusinessModels.StockOutDetails();
            using (var dbContext = new StockOutDetailsDbContext())
            {
                _StockOutDetails = dbContext.StockOutDetails
                             .Include(K => K.SalesQuotation)
                             .FirstOrDefault(p => p.Identity == identity);
            }
            return _StockOutDetails;
        }

        public IEnumerable<BusinessModels.StockOutDetails> GetAll()
        {
            var _StockOutDetailss = new List<BusinessModels.StockOutDetails>();
            using (var dbContext = new StockOutDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _StockOutDetailss = dbContext.StockOutDetails
                             .Include(K => K.SalesQuotation)
                            .ToList();
            }

            return _StockOutDetailss;
        }
        public BusinessModels.SalesQuotation UpdateStockOutWorkFlowID(int? flowid, int identity)
        {
            var _user = new BusinessModels.SalesQuotation();
            try             {                 using (var dbContext = new SalesQuotationDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.SalesQuotation>("CALL UpdateStockOutWorkFlowID(@_id, @_flowid)", new MySqlParameter("@_id", identity), new MySqlParameter("@_flowid", flowid)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }
        public BusinessModels.StockOutDetails GetAllBySalesQuotation(int reqID)
        {
            var _StockOutDetailss = new BusinessModels.StockOutDetails();
            using (var dbContext = new StockOutDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _StockOutDetailss = dbContext.StockOutDetails
                            .Include(K => K.SalesQuotation)
                             .Where(p => p.SQID == reqID)
                            .FirstOrDefault(); 
            }

            return _StockOutDetailss;
        }  

    

        public Boolean Update(BusinessModels.StockOutDetails StockOutDetails)
        {
            using (var dbContext = new StockOutDetailsDbContext())
            {
                dbContext.Entry(StockOutDetails).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new StockOutDetailsDbContext())
            {
                dbContext.Entry(new BusinessModels.StockOutDetails() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.StockOutDetails Insert(BusinessModels.StockOutDetails StockOutDetails)
        {
            using (var dbContext = new StockOutDetailsDbContext())
            {
                dbContext.Entry(StockOutDetails).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return StockOutDetails;
        }

    }
}
