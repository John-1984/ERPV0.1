using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataLayer
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
            sqlcon = new MySqlConnection(ConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString);
        }
    }
}
