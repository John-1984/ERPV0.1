using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class RoleTypeDAL
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
        private static List<BusinessModels.RoleType> RoleTypes = new List<BusinessModels.RoleType>();

        public RoleTypeDAL()
        {
        }

        public BusinessModels.RoleType GetRoleType(Int32 identity)
        {
            var _RoleType = new BusinessModels.RoleType();
            using (var dbContext = new RoleTypeDbContext())
            {
                _RoleType = dbContext.RoleType
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _RoleType;
        }

        public IEnumerable<BusinessModels.RoleType> GetAll()
        {
            var _RoleTypes = new List<BusinessModels.RoleType>();
            using (var dbContext = new RoleTypeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _RoleTypes = dbContext.RoleType.ToList();
            }

            return _RoleTypes;
        }

        public Boolean Update(BusinessModels.RoleType RoleType)
        {
            using (var dbContext = new RoleTypeDbContext())
            {
                dbContext.Entry(RoleType).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new RoleTypeDbContext())
            {
                dbContext.Entry(new BusinessModels.RoleType() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.RoleType RoleType)
        {
            using (var dbContext = new RoleTypeDbContext())
            {
                dbContext.Entry(RoleType).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
