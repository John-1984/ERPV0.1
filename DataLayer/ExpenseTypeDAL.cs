using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class ExpenseTypeDAL
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
        private static List<BusinessModels.ExpenseType> ExpenseTypes = new List<BusinessModels.ExpenseType>();

        public ExpenseTypeDAL()
        {
        }

        public BusinessModels.ExpenseType GetExpenseType(Int32 identity)
        {
            var _ExpenseType = new BusinessModels.ExpenseType();
            using (var dbContext = new ExpenseTypeDbContext())
            {
                _ExpenseType = dbContext.ExpenseType                            
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _ExpenseType;
        }

        public IEnumerable<BusinessModels.ExpenseType> GetAll()
        {
            var _ExpenseTypes = new List<BusinessModels.ExpenseType>();
            using (var dbContext = new ExpenseTypeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _ExpenseTypes = dbContext.ExpenseType.ToList();
            }

            return _ExpenseTypes;
        }

        public IEnumerable<BusinessModels.ExpenseType> GetAbroadExpenseTypes()
        {
            var _ExpenseTypes = new List<BusinessModels.ExpenseType>();
            using (var dbContext = new ExpenseTypeDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _ExpenseTypes = dbContext.ExpenseType.ToList();
            }

            return _ExpenseTypes;
        }

        public Boolean Update(BusinessModels.ExpenseType ExpenseType)
        {
            using (var dbContext = new ExpenseTypeDbContext())
            {
                dbContext.Entry(ExpenseType).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new ExpenseTypeDbContext())
            {
                dbContext.Entry(new BusinessModels.ExpenseType() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.ExpenseType ExpenseType)
        {
            using (var dbContext = new ExpenseTypeDbContext())
            {
                dbContext.Entry(ExpenseType).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
