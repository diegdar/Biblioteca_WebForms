using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Biblioteca_WebForms.DAL
{
    public class DALObra
    {
        public BDConnection BDConnection { get; set; }

        public DALObra()
        {
            BDConnection = new BDConnection();
        }

        public List<Obra> ListObra()
        {
            try
            {
                BDConnection.ConnectBD();
                List<Obra> obras = new List<Obra>();

                string query = @"SELECT * FROM Obra ORDER BY IdObra DESC";

                SqlCommand cmd = new SqlCommand(query, BDConnection.sqlConnection);

                SqlDataReader records = cmd.ExecuteReader();

                while (records.Read()) 
                {
                    Obra obra = new Obra();
                    obra.Id = records.GetInt32(records.GetOrdinal("IdObra"));
                    obra.Titulo = records.GetString(records.GetOrdinal("Titulo"));
                    obra.Sinopsis = records.IsDBNull(records.GetOrdinal("Sinopsis"))
                        ? null : records.GetString(records.GetOrdinal("Sinopsis"));

                    obras.Add(obra);
                }

                records.Close();

                BDConnection.DisconnectBD();

                return obras;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

    }
}