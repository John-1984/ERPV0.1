using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class StatusDAL
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
        private static List<BusinessModels.Status> Statuss = new List<BusinessModels.Status>();

        public StatusDAL()
        {
        }

        public BusinessModels.Status GetStatus(Int32 identity)
        {
            var _Status = new BusinessModels.Status();
            using (var dbContext = new StatusDbContext())
            {
                _Status = dbContext.Status
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Status;
        }

        public IEnumerable<BusinessModels.Status> GetAll()
        {
            var _Statuss = new List<BusinessModels.Status>();
            using (var dbContext = new StatusDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Statuss = dbContext.Status.ToList();
            }

            return _Statuss;
        }

        public Boolean Update(BusinessModels.Status Status)
        {
            using (var dbContext = new StatusDbContext())
            {
                dbContext.Entry(Status).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new StatusDbContext())
            {
                dbContext.Entry(new BusinessModels.Status() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.Status Status)
        {
            using (var dbContext = new StatusDbContext())
            {
                dbContext.Entry(Status).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
