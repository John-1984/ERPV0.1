using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class PurchaseRequestTypeDAL
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
        private static List<BusinessModels.PurchaseRequestType> PurchaseRequestTypes = new List<BusinessModels.PurchaseRequestType>();

        public PurchaseRequestTypeDAL()
        {
        }

        public BusinessModels.PurchaseRequestType GetPurchaseRequestType(Int32 identity)
        {
            var _PurchaseRequestType = new BusinessModels.PurchaseRequestType();
            using (var dbContext = new PurchaseRequestTypeDbContext())
            {
                _PurchaseRequestType = dbContext.PurchaseRequestType
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _PurchaseRequestType;
        }

        public IEnumerable<BusinessModels.PurchaseRequestType> GetAll()
        {
            var _PurchaseRequestTypes = new List<BusinessModels.PurchaseRequestType>();
            using (var dbContext = new PurchaseRequestTypeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _PurchaseRequestTypes = dbContext.PurchaseRequestType.ToList();
            }

            return _PurchaseRequestTypes;
        }

        public Boolean Update(BusinessModels.PurchaseRequestType PurchaseRequestType)
        {
            using (var dbContext = new PurchaseRequestTypeDbContext())
            {
                dbContext.Entry(PurchaseRequestType).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new PurchaseRequestTypeDbContext())
            {
                dbContext.Entry(new BusinessModels.PurchaseRequestType() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.PurchaseRequestType PurchaseRequestType)
        {
            using (var dbContext = new PurchaseRequestTypeDbContext())
            {
                dbContext.Entry(PurchaseRequestType).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
