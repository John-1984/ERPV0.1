using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace BusinessLayer
{
    public class DBConnection
    {
        protected MySqlConnection sqlcon = new MySqlConnection();
        public DBConnection()
        {
            if (sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Close();
            }           
            sqlcon = new MySqlConnection(ConfigurationManager.ConnectionStrings["erpconnectionstring"].ConnectionString);
        }
    }


}
