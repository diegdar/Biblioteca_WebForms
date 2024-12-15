using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Biblioteca_WebForms.DAL
{
    public class BDConnection
    {
        public SqlConnection sqlConnection;

        public static string connectionString = "Data Source=200.234.233.187,54321;" +
            "Initial Catalog=PFBiblioteca;" +
            "User ID=sa;" +
            "Password=Sql#123456789";

        public void ConnectBD()
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DisconnectBD()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}