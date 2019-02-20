using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class IdentificationsTypeDAL
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
        private static List<BusinessModels.IdentificationsType> IdentificationsTypes = new List<BusinessModels.IdentificationsType>();

        public IdentificationsTypeDAL()
        {
        }

        public BusinessModels.IdentificationsType GetIdentificationsType(Int32 identity)
        {
            var _IdentificationsType = new BusinessModels.IdentificationsType();
            using (var dbContext = new IdentificationsTypeDbContext())
            {
                _IdentificationsType = dbContext.IdentificationsType
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _IdentificationsType;
        }

        public IEnumerable<BusinessModels.IdentificationsType> GetAll()
        {
            var _IdentificationsTypes = new List<BusinessModels.IdentificationsType>();
            using (var dbContext = new IdentificationsTypeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _IdentificationsTypes = dbContext.IdentificationsType.ToList();
            }

            return _IdentificationsTypes;
        }

        public Boolean Update(BusinessModels.IdentificationsType IdentificationsType)
        {
            using (var dbContext = new IdentificationsTypeDbContext())
            {
                dbContext.Entry(IdentificationsType).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new IdentificationsTypeDbContext())
            {
                dbContext.Entry(new BusinessModels.IdentificationsType() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.IdentificationsType IdentificationsType)
        {
            using (var dbContext = new IdentificationsTypeDbContext())
            {
                dbContext.Entry(IdentificationsType).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
