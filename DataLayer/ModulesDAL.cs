using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class ModulesDAL
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
        private static List<BusinessModels.Modules> Moduless = new List<BusinessModels.Modules>();

        public ModulesDAL()
        {
        }

        public BusinessModels.Modules GetModules(Int32 identity)
        {
            var _Modules = new BusinessModels.Modules();
            using (var dbContext = new ModulesDbContext())
            {
                _Modules = dbContext.Modules
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Modules;
        }

        public IEnumerable<BusinessModels.Modules> GetAll()
        {
            var _Moduless = new List<BusinessModels.Modules>();
            using (var dbContext = new ModulesDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Moduless = dbContext.Modules.ToList();
            }

            return _Moduless;
        }

        public Boolean Update(BusinessModels.Modules Modules)
        {
            using (var dbContext = new ModulesDbContext())
            {
                dbContext.Entry(Modules).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new ModulesDbContext())
            {
                dbContext.Entry(new BusinessModels.Modules() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.Modules Modules)
        {
            using (var dbContext = new ModulesDbContext())
            {
                dbContext.Entry(Modules).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
