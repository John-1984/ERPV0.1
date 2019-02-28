using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class PurposeDAL
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
        private static List<BusinessModels.Purpose> Purposes = new List<BusinessModels.Purpose>();

        public PurposeDAL()
        {
        }

        public BusinessModels.Purpose GetPurpose(Int32 identity)
        {
            var _Purpose = new BusinessModels.Purpose();
            using (var dbContext = new PurposeDbContext())
            {
                _Purpose = dbContext.Purpose
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Purpose;
        }

        public IEnumerable<BusinessModels.Purpose> GetAll()
        {
            var _Purposes = new List<BusinessModels.Purpose>();
            using (var dbContext = new PurposeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Purposes = dbContext.Purpose.ToList();
            }

            return _Purposes;
        }

        public Boolean Update(BusinessModels.Purpose Purpose)
        {
            using (var dbContext = new PurposeDbContext())
            {
                dbContext.Entry(Purpose).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new PurposeDbContext())
            {
                dbContext.Entry(new BusinessModels.Purpose() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.Purpose Purpose)
        {
            using (var dbContext = new PurposeDbContext())
            {
                dbContext.Entry(Purpose).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
