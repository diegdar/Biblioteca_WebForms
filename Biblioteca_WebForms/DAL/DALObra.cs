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

        //public List<Obra> ListObra()
        //{
        //    try
        //    {
        //        BDConnection.ConnectBD();
        //        List<Obra> obras = new List<Obra>();

        //        string query = @"SELECT * FROM Obra ORDER BY IdObra DESC";

        //        SqlCommand cmd = new SqlCommand(query, BDConnection.sqlConnection);

        //        SqlDataReader records = cmd.ExecuteReader();

        //        while (records.Read()) 
        //        {
        //            Obra obra = new Obra();
        //            obra.Id = records.GetInt32(records.GetOrdinal("IdObra"));
        //            obra.Titulo = records.GetString(records.GetOrdinal("Titulo"));
        //            obra.Sinopsis = records.IsDBNull(records.GetOrdinal("Sinopsis"))
        //                ? null : records.GetString(records.GetOrdinal("Sinopsis"));

        //            obras.Add(obra);
        //        }

        //        records.Close();

        //        BDConnection.DisconnectBD();

        //        return obras;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return null;
        //    }
        //}

        public bool InsertObra(Obra obra)
        {
            try
            {
                BDConnection.ConnectBD();

                string sql = @"
                    INSERT INTO obra(Titulo, Sinopsis)
                    VALUES (@pTitulo, @pSinopsis);
                    SELECT SCOPE_IDENTITY();";//SCOPE IDENTITY: nos devuelve el id del registro creado

                SqlCommand cmd = new SqlCommand(sql, BDConnection.sqlConnection);

                cmd.Parameters.AddWithValue("@pTitulo", obra.Titulo);
                cmd.Parameters.AddWithValue("@pSinopsis", obra.Sinopsis);

                object result = cmd.ExecuteScalar();
                obra.Id = Convert.ToInt32(result);//obtenemos el id del registro

                BDConnection.DisconnectBD();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateObra(Obra obra)
        {
            try
            {
                BDConnection.ConnectBD();

                string sql = @"
                    UPDATE obra
                    SET Titulo=@pTitulo, Sinopsis=@pSinopsis
                    WHERE IdObra = @pId";

                SqlCommand cmd = new SqlCommand(sql, BDConnection.sqlConnection);


                cmd.Parameters.AddWithValue("@pId", obra.Id);
                cmd.Parameters.AddWithValue("@pTitulo", obra.Titulo);
                cmd.Parameters.AddWithValue("@pSinopsis", obra.Sinopsis);

                cmd.ExecuteNonQuery();

                BDConnection.ConnectBD();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool DeleteJob(int IdObra)
        {
            try
            {
                BDConnection.ConnectBD();

                string sql = @"
                    DELETE obra
                    WHERE IdObra = @pId";

                SqlCommand cmd = new SqlCommand(sql, BDConnection.sqlConnection);


                cmd.Parameters.AddWithValue("@pId", IdObra);

                cmd.ExecuteNonQuery();

                BDConnection.DisconnectBD();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }




    }
}