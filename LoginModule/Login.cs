using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.Security;

namespace LoginModule
{
    public class Login: ILogin 
    {
        private BusinessLayer.User _userBL = null;
        public Login()
        {
            _userBL = new BusinessLayer.User();
        }

        public bool AuthenticateUser(string userName, string password)
        {
            FormsAuthentication.SetAuthCookie(userName, true);
            return ValidateLogin(userName,password);
        }

        /// <summary>
        /// Validates the login.
        /// </summary>
        /// <returns><c>true</c>, if login was validated, <c>false</c> otherwise.</returns>
        /// <param name="userName">User name.</param>
        /// <param name="password">Password.</param>
        public bool ValidateLogin(string userName, string password)
        {
            //bool check = false;
            //string strPassword = Encrypt.HashSHA(password);
            var _user = _userBL.ValidateUser(userName, password);
            if (_user == null || _user.UserName.Equals(string.Empty))
                return false;
            else
                return true;
        }

    }
}
