using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class PaymentModeDAL
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
        private static List<BusinessModels.PaymentMode> PaymentModes = new List<BusinessModels.PaymentMode>();

        public PaymentModeDAL()
        {
        }

        public BusinessModels.PaymentMode GetPaymentMode(Int32 identity)
        {
            var _PaymentMode = new BusinessModels.PaymentMode();
            using (var dbContext = new PaymentModeDbContext())
            {
                _PaymentMode = dbContext.PaymentMode                            
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _PaymentMode;
        }

        public IEnumerable<BusinessModels.PaymentMode> GetAll()
        {
            var _PaymentModes = new List<BusinessModels.PaymentMode>();
            using (var dbContext = new PaymentModeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PaymentModes = dbContext.PaymentMode.ToList();
            }

            return _PaymentModes;
        }

       
        public Boolean Update(BusinessModels.PaymentMode PaymentMode)
        {
            using (var dbContext = new PaymentModeDbContext())
            {
                dbContext.Entry(PaymentMode).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new PaymentModeDbContext())
            {
                dbContext.Entry(new BusinessModels.PaymentMode() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.PaymentMode PaymentMode)
        {
            using (var dbContext = new PaymentModeDbContext())
            {
                dbContext.Entry(PaymentMode).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
