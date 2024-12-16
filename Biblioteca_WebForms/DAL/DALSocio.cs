using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Biblioteca.Models;

namespace Biblioteca_WebForms.DAL
{
    public class DALSocio
    {
        private BDConnection bdConnection;

        public DALSocio()
        {
            bdConnection = new BDConnection();
        }

        public int Insert(Socio socio)
        {
            int numFilas = 0;
            object idSocio = null;
            string sentenciaSQL = string.Empty;

            // Devuelve -1 si ha habido un error, 0 si no se ha insertado ninguna fila pero no ha habido error y
            // 1 si la fila se ha insertado correctamente, en el campo Id del objeto se coloca el número autogenerado
            // en la inserción

            try
            {
                sentenciaSQL = @"INSERT INTO dbo.Socio VALUES 
				(Apellido = @Apellido, Nombre = @Nombre, Email = @Email, Domicilio = @Domicilio, Telefono = @Telefono); 
                SELECT SCOPE_IDENTITY();";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@Apellido", socio.Apellido);
                cmd.Parameters.AddWithValue("@Nombre", socio.Nombre);
				
				if (socio.Email == null)
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                else
					cmd.Parameters.AddWithValue("@Email", socio.Email);

                if (socio.Domicilio == null)
                    cmd.Parameters.AddWithValue("@Domicilio", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Domicilio", socio.Domicilio);

                if (socio.Telefono == null)
                    cmd.Parameters.AddWithValue("@Telefono", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Telefono", socio.Telefono);

                idSocio = cmd.ExecuteScalar();

                if (idSocio != null)
                {
                    socio.Id = (int)(decimal)idSocio;
                    numFilas = 1;
                }
				else
					socio.Id = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                numFilas = -1;
				socio.Id = 0;
            }

            bdConnection.DisconnectBD();
            return numFilas;
        }
        public int Delete(int idSocio)
        {
            int numFilas = 0;
            string sentenciaSQL = string.Empty;

            // Devuelve 0 si no se ha borrado ninguna línea de la tabla, -1 si ha habido algún error o 1 si se ha borrado
            // la línea indicada en la variable idSocio

            try
            {
                sentenciaSQL = "DELETE FROM dbo.Socio WHERE IdSocio = @Id;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@Id", idSocio);
                numFilas = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                numFilas = -1;
            }

            bdConnection.DisconnectBD();
            return numFilas;
        }
        public int Update(Socio socio)
        {
            int numFilas = 0;
            string sentenciaSQL = string.Empty;

            // Devuelve 0 si no se ha actualizado ninguna línea de la tabla, -1 si ha habido algún error o 1 si se ha actualizado
            // la línea indicada en la variable socio

            try
            {
                sentenciaSQL = @"UPDATE dbo.AlquilerEjemplar SET Apellido = @Apellido, Nombre = @Nombre, Email = @Email, 
                Domicilio = @Domicilio, Telefono = @Telefono WHERE IdSocio = @Id;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@Apellido", socio.Apellido);
                cmd.Parameters.AddWithValue("@Nombre", socio.Nombre);
				
				if (socio.Email == null)
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                else
					cmd.Parameters.AddWithValue("@Email", socio.Email);

                if (socio.Domicilio == null)
                    cmd.Parameters.AddWithValue("@Domicilio", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Domicilio", socio.Domicilio);

                if (socio.Telefono == null)
                    cmd.Parameters.AddWithValue("@Telefono", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Telefono", socio.Telefono);

                cmd.Parameters.AddWithValue("@Id", socio.Id);
                numFilas = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                numFilas = -1;
            }

            bdConnection.DisconnectBD();
            return numFilas;
        }
        public List<Socio> Select()
        {
            SqlDataReader lector = null;
            List<Socio> listaSocios = new List<Socio>();
            string sentenciaSQL = "SELECT * FROM dbo.Socio;";

            try
            {
                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    Socio socio = new Socio();
                    socio.Id = lector.GetInt32(lector.GetOrdinal("IdSocio"));
                    socio.Nombre = lector.GetString(lector.GetOrdinal("Nombre"));
                    socio.Apellido = lector.GetString(lector.GetOrdinal("Apellido"));
					
					if (lector.IsDBNull(lector.GetOrdinal("Email")))
                        socio.Email = null;
                    else
						socio.Email = lector.GetString(lector.GetOrdinal("Email"));

                    if (lector.IsDBNull(lector.GetOrdinal("Domicilio")))
                        socio.Domicilio = null;
                    else
                        socio.Domicilio = lector.GetString(lector.GetOrdinal("Domicilio"));

                    if (lector.IsDBNull(lector.GetOrdinal("Telefono")))
                        socio.Domicilio = null;
                    else
                        socio.Domicilio = lector.GetString(lector.GetOrdinal("Telefono"));

                    listaSocios.Add(socio);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            bdConnection.DisconnectBD();
            return listaSocios;
        }
        public Socio SelectById(int idSocio)
        {
            Socio socio = null;
            SqlDataReader lector = null;
            string sentenciaSQL = string.Empty;

            try
            {
                sentenciaSQL = "SELECT * FROM dbo.Socio WHERE IdSocio = @Id;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@Id", idSocio);
                lector = cmd.ExecuteReader();

                if (lector.Read())
                {
                    socio = new Socio();
                    socio.Id = lector.GetInt32(lector.GetOrdinal("IdSocio"));
                    socio.Nombre = lector.GetString(lector.GetOrdinal("Nombre"));
                    socio.Apellido = lector.GetString(lector.GetOrdinal("Apellido"));
					
					if (lector.IsDBNull(lector.GetOrdinal("Email")))
                        socio.Email = null;
                    else
						socio.Email = lector.GetString(lector.GetOrdinal("Email"));

                    if (lector.IsDBNull(lector.GetOrdinal("Domicilio")))
                        socio.Domicilio = null;
                    else
                        socio.Domicilio = lector.GetString(lector.GetOrdinal("Domicilio"));

                    if (lector.IsDBNull(lector.GetOrdinal("Telefono")))
                        socio.Domicilio = null;
                    else
                        socio.Domicilio = lector.GetString(lector.GetOrdinal("Telefono"));
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            bdConnection.DisconnectBD();
            return socio;
        }
    }
}