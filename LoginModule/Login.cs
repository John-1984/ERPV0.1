using System;
using MySql.Data.MySqlClient;
using BusinessLayer;
using System.Data;
using System.Web.Security;

namespace LoginModule
{
    public class Login: ILogin 
    {
        public Login()
        {
        }

        public bool AuthenticateUser(string userName, string password)
        {
            FormsAuthentication.SetAuthCookie(userName, true);
            return true;  //ValidateLogin(userName,password);
        }

        /// <summary>
        /// Validates the login.
        /// </summary>
        /// <returns><c>true</c>, if login was validated, <c>false</c> otherwise.</returns>
        /// <param name="userName">User name.</param>
        /// <param name="password">Password.</param>
        public bool ValidateLogin(string userName, string password)
        {
            //This method has to be implemented and called from DataLayer*******************
            return true;
            //bool check = false;
            //string strPassword = Encrypt.HashSHA(password);
            ////asecv@123#
            //DataTable dtbl = new DataTable();
            //try
            //{
               
            //    if (sqlcon.State == ConnectionState.Closed)
            //    {
            //        sqlcon.Open();
            //    }
            //    MySqlDataAdapter sdaadapter = new MySqlDataAdapter("VerifyUsernameAndPassword", sqlcon);
            //    sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    sdaadapter.SelectCommand.Parameters.Add("_name", MySqlDbType.VarChar).Value = userName;
            //    sdaadapter.SelectCommand.Parameters.Add("_password", MySqlDbType.VarChar).Value = strPassword;
            //    sdaadapter.Fill(dtbl);

            //    check = dtbl.Rows.Count > 0 ? true : false;
            //}
            //catch (Exception ex)
            //{
            //    var error = ex.Message;          
            //}
            //finally
            //{
            //    sqlcon.Close();
            //}
            //return check;
        }

    }
}
