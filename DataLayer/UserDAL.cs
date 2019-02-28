using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class UserDAL
    {
        public UserDAL()
        {
        }

        public BusinessModels.User GetUser(string userName, string password) {
            var _user = new BusinessModels.User();
            using (var dbContext = new UserDbContext())
            {
                _user = dbContext.User
                                .FirstOrDefault(p => p.UserName.Equals(userName) && p.Password.Equals(password));
                             
            }
            return _user;
        }

        public BusinessModels.Login ValidateUser(string userName, string password)
        {
            var _user = new BusinessModels.Login();
            try             {                 using (var dbContext = new UserDbContext())                 {
                    _user = dbContext.Database.SqlQuery<BusinessModels.Login>("CALL VerifyUsernameAndPassword(@_userName, @_password)", new MySqlParameter("@_userName", userName), new MySqlParameter("@_password", password)).FirstOrDefault();                 }             }             catch (Exception ex)             {                 var test = ex.Message;             }
            return _user;
        }
    }
}
