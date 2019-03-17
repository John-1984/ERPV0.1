using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace DataLayer
{
    public class PurchaseQuotationDetailsDAL
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
        private static List<BusinessModels.PurchaseQuotationDetails> PurchaseQuotationDetailss = new List<BusinessModels.PurchaseQuotationDetails>();

        public PurchaseQuotationDetailsDAL()
        {
        }

        public BusinessModels.PurchaseQuotationDetails GetPurchaseQuotationDetails(Int32 identity)
        {
            var _PurchaseQuotationDetails = new BusinessModels.PurchaseQuotationDetails();
            using (var dbContext = new PurchaseQuotationDetailsDbContext())
            {
                _PurchaseQuotationDetails = dbContext.PurchaseQuotationDetails
                             .Include(K => K.PurchaseQuotation)
                             .Include(o => o.PaymentMode)
                             .Include(y => y.PaymentType)
                             //.Include(d => d.ItemMaster)                            
                             .FirstOrDefault(p => p.Identity == identity);
            }
            return _PurchaseQuotationDetails;
        }

        public IEnumerable<BusinessModels.PurchaseQuotationDetails> GetAll()
        {
            var _PurchaseQuotationDetailss = new List<BusinessModels.PurchaseQuotationDetails>();
            using (var dbContext = new PurchaseQuotationDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseQuotationDetailss = dbContext.PurchaseQuotationDetails
                             .Include(K => K.PurchaseQuotation)
                             .Include(o=>o.PaymentMode)
                             .Include(y => y.PaymentType)
                            // .Include(d => d.ItemMaster)
                            .ToList();
            }

            return _PurchaseQuotationDetailss;
        }

        public BusinessModels.PurchaseQuotationDetails GetAllByPurchaseQuotation(int? reqID)
        {
            var _PurchaseQuotationDetailss = new BusinessModels.PurchaseQuotationDetails();
            using (var dbContext = new PurchaseQuotationDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseQuotationDetailss = dbContext.PurchaseQuotationDetails
                            .Include(K => K.PurchaseQuotation)
                            .Include(o => o.PaymentMode)
                             .Include(y => y.PaymentType)
                             // .Include(d => d.ItemMaster)
                             .Where(p => p.PQID == reqID)
                            .FirstOrDefault(); 
            }

            return _PurchaseQuotationDetailss;
        }  

    

        public Boolean Update(BusinessModels.PurchaseQuotationDetails PurchaseQuotationDetails)
        {
            using (var dbContext = new PurchaseQuotationDetailsDbContext())
            {
                dbContext.Entry(PurchaseQuotationDetails).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new PurchaseQuotationDetailsDbContext())
            {
                dbContext.Entry(new BusinessModels.PurchaseQuotationDetails() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.PurchaseQuotationDetails Insert(BusinessModels.PurchaseQuotationDetails PurchaseQuotationDetails)
        {
            using (var dbContext = new PurchaseQuotationDetailsDbContext())
            {
                dbContext.Entry(PurchaseQuotationDetails).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return PurchaseQuotationDetails;
        }

    }
}
