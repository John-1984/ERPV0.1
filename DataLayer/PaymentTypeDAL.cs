using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class PaymentTypeDAL
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
        private static List<BusinessModels.PaymentType> PaymentTypes = new List<BusinessModels.PaymentType>();

        public PaymentTypeDAL()
        {
        }

        public BusinessModels.PaymentType GetPaymentType(Int32 identity)
        {
            var _PaymentType = new BusinessModels.PaymentType();
            using (var dbContext = new PaymentTypeDbContext())
            {
                _PaymentType = dbContext.PaymentType                            
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _PaymentType;
        }

        public IEnumerable<BusinessModels.PaymentType> GetAll()
        {
            var _PaymentTypes = new List<BusinessModels.PaymentType>();
            using (var dbContext = new PaymentTypeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PaymentTypes = dbContext.PaymentType.ToList();
            }

            return _PaymentTypes;
        }

       
        public Boolean Update(BusinessModels.PaymentType PaymentType)
        {
            using (var dbContext = new PaymentTypeDbContext())
            {
                dbContext.Entry(PaymentType).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new PaymentTypeDbContext())
            {
                dbContext.Entry(new BusinessModels.PaymentType() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.PaymentType PaymentType)
        {
            using (var dbContext = new PaymentTypeDbContext())
            {
                dbContext.Entry(PaymentType).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
