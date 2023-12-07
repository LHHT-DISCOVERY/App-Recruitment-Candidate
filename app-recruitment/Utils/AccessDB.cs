using app_recruitment.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace app_recruitment.Utils
{
    internal class AccessDB
    {
        static string connectionString = "Data Source=DESKTOP-LPUT7IK\\SQLEXPRESS;Initial Catalog=app_recruitment ;User ID=sa;Password=12345";

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                //Console.WriteLine("Connect Successful");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Connect Fail");
                Console.WriteLine(e.Message);
            }
            return connection;
        }
    }
}
