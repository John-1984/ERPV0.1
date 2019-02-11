using System;
using MySql.Data.MySqlClient;
using BusinessLayer;
using System.Data;
namespace LoginModule
{
    public class Login: DBConnection, ILogin 
    {
        public Login()
        {
        }

        public bool AuthenticateUser(string userName, string password)
        {
            return ValidateLogin(userName,password);
        }

        public bool ValidateLogin(string userName, string password)
        {
            bool check = false;
            string strPassword = Encrypt.HashSHA(password);
            //asecv@123#
            DataTable dtbl = new DataTable();
            try
            {
               
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                MySqlDataAdapter sdaadapter = new MySqlDataAdapter("VerifyUsernameAndPassword", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sdaadapter.SelectCommand.Parameters.Add("_name", MySqlDbType.VarChar).Value = userName;
                sdaadapter.SelectCommand.Parameters.Add("_password", MySqlDbType.VarChar).Value = strPassword;
                sdaadapter.Fill(dtbl);

                check = dtbl.Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {               
            }
            finally
            {
                sqlcon.Close();
            }
            return check;
        }

    }
}
