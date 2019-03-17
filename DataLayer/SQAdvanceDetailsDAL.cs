using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace DataLayer
{
    public class SQAdvanceDetailsDAL
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
        private static List<BusinessModels.SQAdvanceDetails> SQAdvanceDetailss = new List<BusinessModels.SQAdvanceDetails>();

        public SQAdvanceDetailsDAL()
        {
        }

        public BusinessModels.SQAdvanceDetails GetSQAdvanceDetails(Int32 identity)
        {
            var _SQAdvanceDetails = new BusinessModels.SQAdvanceDetails();
            using (var dbContext = new SQAdvanceDetailsDbContext())
            {
                _SQAdvanceDetails = dbContext.SQAdvanceDetails
                     .Include(p => p.SalesQuotation)
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _SQAdvanceDetails;
        }

        public IEnumerable<BusinessModels.SQAdvanceDetails> GetAll()
        {
            var _SQAdvanceDetailss = new List<BusinessModels.SQAdvanceDetails>();
            using (var dbContext = new SQAdvanceDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _SQAdvanceDetailss = dbContext.SQAdvanceDetails
                    
                    .Include(p=>p.SalesQuotation).ToList();
            }

            return _SQAdvanceDetailss;
        }

        public IEnumerable<BusinessModels.SQAdvanceDetails> GetAllAdvanceBySQ(int? identity)
        {
            var _SQAdvanceDetailss = new List<BusinessModels.SQAdvanceDetails>();
            using (var dbContext = new SQAdvanceDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _SQAdvanceDetailss = dbContext.SQAdvanceDetails

                    .Include(p => p.SalesQuotation).Where(s=>s.SQID==identity).ToList();
            }

            return _SQAdvanceDetailss;
        }


        public Boolean Update(BusinessModels.SQAdvanceDetails SQAdvanceDetails)
        {
            using (var dbContext = new SQAdvanceDetailsDbContext())
            {
                dbContext.Entry(SQAdvanceDetails).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new SQAdvanceDetailsDbContext())
            {
                dbContext.Entry(new BusinessModels.SQAdvanceDetails() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.SQAdvanceDetails SQAdvanceDetails)
        {
            using (var dbContext = new SQAdvanceDetailsDbContext())
            {
                dbContext.Entry(SQAdvanceDetails).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
