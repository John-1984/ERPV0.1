using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class LoginDAL
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
        private static List<BusinessModels.Login> Logins = new List<BusinessModels.Login>();

        public LoginDAL()
        {
        }

        public BusinessModels.Login GetLogin(Int32 identity)
        {
            var _Login = new BusinessModels.Login();
            using (var dbContext = new LoginDbContext())
            {
                _Login = dbContext.Login
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _Login;
        }

        public IEnumerable<BusinessModels.Login> GetAll()
        {
            var _Logins = new List<BusinessModels.Login>();
            using (var dbContext = new LoginDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _Logins = dbContext.Login.ToList();
            }

            return _Logins;
        }


        public Boolean Update(BusinessModels.Login Login)
        {
            using (var dbContext = new LoginDbContext())
            {
                dbContext.Entry(Login).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new LoginDbContext())
            {
                dbContext.Entry(new BusinessModels.Login() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.Login Insert(BusinessModels.Login Login)
        {
            using (var dbContext = new LoginDbContext())
            {
                dbContext.Entry(Login).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return Login;
        }

    }
}
