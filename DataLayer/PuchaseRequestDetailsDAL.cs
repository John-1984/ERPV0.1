using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace DataLayer
{
    public class PurchaseRequestDetailsDAL
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
        private static List<BusinessModels.PurchaseRequestDetails> PurchaseRequestDetailss = new List<BusinessModels.PurchaseRequestDetails>();

        public PurchaseRequestDetailsDAL()
        {
        }

        public BusinessModels.PurchaseRequestDetails GetPurchaseRequestDetails(Int32 identity)
        {
            var _PurchaseRequestDetails = new BusinessModels.PurchaseRequestDetails();
            using (var dbContext = new PurchaseRequestDetailsDbContext())
            {
                _PurchaseRequestDetails = dbContext.PurchaseRequestDetails
                             .Include(K => K.PurchaseRequest)
                             .Include(d => d.ItemMaster)                            
                             .FirstOrDefault(p => p.Identity == identity);
            }
            return _PurchaseRequestDetails;
        }

        public IEnumerable<BusinessModels.PurchaseRequestDetails> GetAll()
        {
            var _PurchaseRequestDetailss = new List<BusinessModels.PurchaseRequestDetails>();
            using (var dbContext = new PurchaseRequestDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseRequestDetailss = dbContext.PurchaseRequestDetails
                             .Include(K => K.PurchaseRequest)
                             .Include(d => d.ItemMaster)
                            .ToList();
            }

            return _PurchaseRequestDetailss;
        }

        public IEnumerable<BusinessModels.PurchaseRequestDetails> GetAllByPurchaseRequest(int reqID)
        {
            var _PurchaseRequestDetailss = new List<BusinessModels.PurchaseRequestDetails>();
            using (var dbContext = new PurchaseRequestDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseRequestDetailss = dbContext.PurchaseRequestDetails
                            .Include(K => K.PurchaseRequest)
                             .Include(d => d.ItemMaster)
                             .Where(p => p.PurchaseRequestID == reqID)
                            .ToList();
            }

            return _PurchaseRequestDetailss;
        }  

    

        public Boolean Update(BusinessModels.PurchaseRequestDetails PurchaseRequestDetails)
        {
            using (var dbContext = new PurchaseRequestDetailsDbContext())
            {
                dbContext.Entry(PurchaseRequestDetails).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new PurchaseRequestDetailsDbContext())
            {
                dbContext.Entry(new BusinessModels.PurchaseRequestDetails() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.PurchaseRequestDetails Insert(BusinessModels.PurchaseRequestDetails PurchaseRequestDetails)
        {
            using (var dbContext = new PurchaseRequestDetailsDbContext())
            {
                dbContext.Entry(PurchaseRequestDetails).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return PurchaseRequestDetails;
        }

    }
}
