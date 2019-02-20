using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class SalesRoleTypeDAL
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
        private static List<BusinessModels.SalesRoleType> SalesRoleTypes = new List<BusinessModels.SalesRoleType>();

        public SalesRoleTypeDAL()
        {
        }

        public BusinessModels.SalesRoleType GetSalesRoleType(Int32 identity)
        {
            var _SalesRoleType = new BusinessModels.SalesRoleType();
            using (var dbContext = new SalesRoleTypeDbContext())
            {
                _SalesRoleType = dbContext.SalesRoleType
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _SalesRoleType;
        }

        public IEnumerable<BusinessModels.SalesRoleType> GetAll()
        {
            var _SalesRoleTypes = new List<BusinessModels.SalesRoleType>();
            using (var dbContext = new SalesRoleTypeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _SalesRoleTypes = dbContext.SalesRoleType.ToList();
            }

            return _SalesRoleTypes;
        }

        public Boolean Update(BusinessModels.SalesRoleType SalesRoleType)
        {
            using (var dbContext = new SalesRoleTypeDbContext())
            {
                dbContext.Entry(SalesRoleType).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new SalesRoleTypeDbContext())
            {
                dbContext.Entry(new BusinessModels.SalesRoleType() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.SalesRoleType SalesRoleType)
        {
            using (var dbContext = new SalesRoleTypeDbContext())
            {
                dbContext.Entry(SalesRoleType).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
