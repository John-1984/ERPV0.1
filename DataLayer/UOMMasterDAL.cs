using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class UOMMasterDAL
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
        private static List<BusinessModels.UOMMaster> UOMMasters = new List<BusinessModels.UOMMaster>();

        public UOMMasterDAL()
        {
        }

        public BusinessModels.UOMMaster GetUOMMaster(Int32 identity)
        {
            var _UOMMaster = new BusinessModels.UOMMaster();
            using (var dbContext = new UOMMasterDbContext())
            {
                _UOMMaster = dbContext.UOMMaster
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _UOMMaster;
        }

        public IEnumerable<BusinessModels.UOMMaster> GetAll()
        {
            var _UOMMasters = new List<BusinessModels.UOMMaster>();
            using (var dbContext = new UOMMasterDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _UOMMasters = dbContext.UOMMaster.ToList();
            }

            return _UOMMasters;
        }

        public Boolean Update(BusinessModels.UOMMaster UOMMaster)
        {
            using (var dbContext = new UOMMasterDbContext())
            {
                dbContext.Entry(UOMMaster).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new UOMMasterDbContext())
            {
                dbContext.Entry(new BusinessModels.UOMMaster() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.UOMMaster UOMMaster)
        {
            using (var dbContext = new UOMMasterDbContext())
            {
                dbContext.Entry(UOMMaster).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
