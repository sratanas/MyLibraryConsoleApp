using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Data
{
    public class DBConnection
    {

        public static string ConnectionString
        {
            get
            {
                string connStr = ConfigurationManager.ConnectionStrings["LibraryConsoleConnection"].ToString();

                //Allows to parse automatically a connection string and manage the individual properties
                //of a class. Makes it easy to manipulate a connection string
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connStr);

                return sb.ToString();
            }
        }
        /// <summary>
        /// returns an open connection that can be used elsewhere
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

    }
}
