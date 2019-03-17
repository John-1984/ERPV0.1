using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace DataLayer
{
    public class PQAdvanceDetailsDAL
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
        private static List<BusinessModels.PQAdvanceDetails> PQAdvanceDetailss = new List<BusinessModels.PQAdvanceDetails>();

        public PQAdvanceDetailsDAL()
        {
        }

        public BusinessModels.PQAdvanceDetails GetPQAdvanceDetails(Int32 identity)
        {
            var _PQAdvanceDetails = new BusinessModels.PQAdvanceDetails();
            using (var dbContext = new PQAdvanceDetailsDbContext())
            {
                _PQAdvanceDetails = dbContext.PQAdvanceDetails
                     .Include(p => p.PurchaseQuotation)
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _PQAdvanceDetails;
        }

        public IEnumerable<BusinessModels.PQAdvanceDetails> GetAll()
        {
            var _PQAdvanceDetailss = new List<BusinessModels.PQAdvanceDetails>();
            using (var dbContext = new PQAdvanceDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PQAdvanceDetailss = dbContext.PQAdvanceDetails
                    
                    .Include(p=>p.PurchaseQuotation).ToList();
            }

            return _PQAdvanceDetailss;
        }

        public IEnumerable<BusinessModels.PQAdvanceDetails> GetAllAdvanceByPQ(int? identity)
        {
            var _PQAdvanceDetailss = new List<BusinessModels.PQAdvanceDetails>();
            using (var dbContext = new PQAdvanceDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PQAdvanceDetailss = dbContext.PQAdvanceDetails

                    .Include(p => p.PurchaseQuotation).Where(s=>s.PQID==identity).ToList();
            }

            return _PQAdvanceDetailss;
        }


        public Boolean Update(BusinessModels.PQAdvanceDetails PQAdvanceDetails)
        {
            using (var dbContext = new PQAdvanceDetailsDbContext())
            {
                dbContext.Entry(PQAdvanceDetails).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new PQAdvanceDetailsDbContext())
            {
                dbContext.Entry(new BusinessModels.PQAdvanceDetails() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.PQAdvanceDetails PQAdvanceDetails)
        {
            using (var dbContext = new PQAdvanceDetailsDbContext())
            {
                dbContext.Entry(PQAdvanceDetails).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
