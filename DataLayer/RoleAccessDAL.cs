using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class RoleAccessDAL
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
        private static List<BusinessModels.RoleAccess> RoleAccesss = new List<BusinessModels.RoleAccess>();

        public RoleAccessDAL()
        {
        }

        public BusinessModels.RoleAccess GetRoleAccess(Int32 identity)
        {
            var _RoleAccess = new BusinessModels.RoleAccess();
            using (var dbContext = new RoleAccessDbContext())
            {
                _RoleAccess = dbContext.RoleAccess                            
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _RoleAccess;
        }

        public IEnumerable<BusinessModels.RoleAccess> GetAll()
        {
            var _RoleAccesss = new List<BusinessModels.RoleAccess>();
            using (var dbContext = new RoleAccessDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _RoleAccesss = dbContext.RoleAccess.ToList();
            }

            return _RoleAccesss;
        }        

        public Boolean Update(BusinessModels.RoleAccess RoleAccess)
        {
            using (var dbContext = new RoleAccessDbContext())
            {
                dbContext.Entry(RoleAccess).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new RoleAccessDbContext())
            {
                dbContext.Entry(new BusinessModels.RoleAccess() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.RoleAccess RoleAccess)
        {
            using (var dbContext = new RoleAccessDbContext())
            {
                dbContext.Entry(RoleAccess).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
