using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class EnquiryLevelDAL
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
        private static List<BusinessModels.EnquiryLevel> EnquiryLevels = new List<BusinessModels.EnquiryLevel>();

        public EnquiryLevelDAL()
        {
        }

        public BusinessModels.EnquiryLevel GetEnquiryLevel(Int32 identity)
        {
            var _EnquiryLevel = new BusinessModels.EnquiryLevel();
            using (var dbContext = new EnquiryLevelDbContext())
            {
                _EnquiryLevel = dbContext.EnquiryLevel                            
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _EnquiryLevel;
        }

        public IEnumerable<BusinessModels.EnquiryLevel> GetAll()
        {
            var _EnquiryLevels = new List<BusinessModels.EnquiryLevel>();
            using (var dbContext = new EnquiryLevelDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _EnquiryLevels = dbContext.EnquiryLevel.ToList();
            }

            return _EnquiryLevels;
        }

        public IEnumerable<BusinessModels.EnquiryLevel> GetAbroadEnquiryLevels()
        {
            var _EnquiryLevels = new List<BusinessModels.EnquiryLevel>();
            using (var dbContext = new EnquiryLevelDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _EnquiryLevels = dbContext.EnquiryLevel.ToList();
            }

            return _EnquiryLevels;
        }

        public Boolean Update(BusinessModels.EnquiryLevel EnquiryLevel)
        {
            using (var dbContext = new EnquiryLevelDbContext())
            {
                dbContext.Entry(EnquiryLevel).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new EnquiryLevelDbContext())
            {
                dbContext.Entry(new BusinessModels.EnquiryLevel() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.EnquiryLevel EnquiryLevel)
        {
            using (var dbContext = new EnquiryLevelDbContext())
            {
                dbContext.Entry(EnquiryLevel).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
