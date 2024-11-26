using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace prjloginmetlagenoefenenenenenen.Helper
{
    public class Databank
    {
        public static MySqlConnection MakeConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "Localhost",
                Database = "login",
                UserID = "root",
                Password = "usbw",
                ConnectionTimeout = 60,
                Port = 3307,
                AllowZeroDateTime = true
            };

            MySqlConnection conn = new MySqlConnection(builder.ConnectionString);

            conn.Open();
            return conn;
        }

        public static void CloseConnection(MySqlConnection conn)
        {
            if(conn != null)
            {
                conn.Close();
                conn = null;
            }
        }
    }
}
