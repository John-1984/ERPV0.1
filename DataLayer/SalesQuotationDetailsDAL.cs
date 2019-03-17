using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace DataLayer
{
    public class SalesQuotationDetailsDAL
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
        private static List<BusinessModels.SalesQuotationDetails> SalesQuotationDetailss = new List<BusinessModels.SalesQuotationDetails>();

        public SalesQuotationDetailsDAL()
        {
        }

        public BusinessModels.SalesQuotationDetails GetSalesQuotationDetails(Int32 identity)
        {
            var _SalesQuotationDetails = new BusinessModels.SalesQuotationDetails();
            using (var dbContext = new SalesQuotationDetailsDbContext())
            {
                _SalesQuotationDetails = dbContext.SalesQuotationDetails
                             .Include(K => K.SalesQuotation)
                             .Include(o => o.PaymentMode)
                             .Include(y => y.PaymentType)
                             //.Include(d => d.ItemMaster)                            
                             .FirstOrDefault(p => p.Identity == identity);
            }
            return _SalesQuotationDetails;
        }

        public IEnumerable<BusinessModels.SalesQuotationDetails> GetAll()
        {
            var _SalesQuotationDetailss = new List<BusinessModels.SalesQuotationDetails>();
            using (var dbContext = new SalesQuotationDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _SalesQuotationDetailss = dbContext.SalesQuotationDetails
                             .Include(K => K.SalesQuotation)
                             .Include(o=>o.PaymentMode)
                             .Include(y => y.PaymentType)
                            // .Include(d => d.ItemMaster)
                            .ToList();
            }

            return _SalesQuotationDetailss;
        }

        public BusinessModels.SalesQuotationDetails GetAllBySalesQuotation(int reqID)
        {
            var _SalesQuotationDetailss = new BusinessModels.SalesQuotationDetails();
            using (var dbContext = new SalesQuotationDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _SalesQuotationDetailss = dbContext.SalesQuotationDetails
                            .Include(K => K.SalesQuotation)
                            .Include(o => o.PaymentMode)
                             .Include(y => y.PaymentType)
                             // .Include(d => d.ItemMaster)
                             .Where(p => p.SQID == reqID)
                            .FirstOrDefault(); 
            }

            return _SalesQuotationDetailss;
        }  

    

        public Boolean Update(BusinessModels.SalesQuotationDetails SalesQuotationDetails)
        {
            using (var dbContext = new SalesQuotationDetailsDbContext())
            {
                dbContext.Entry(SalesQuotationDetails).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new SalesQuotationDetailsDbContext())
            {
                dbContext.Entry(new BusinessModels.SalesQuotationDetails() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.SalesQuotationDetails Insert(BusinessModels.SalesQuotationDetails SalesQuotationDetails)
        {
            using (var dbContext = new SalesQuotationDetailsDbContext())
            {
                dbContext.Entry(SalesQuotationDetails).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return SalesQuotationDetails;
        }

    }
}
