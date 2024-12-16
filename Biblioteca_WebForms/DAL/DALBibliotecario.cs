using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Biblioteca.Models;

namespace Biblioteca_WebForms.DAL
{
    public class DALBibliotecario
    {
        private BDConnection bdConnection;

        public DALBibliotecario()
        {
            bdConnection = new BDConnection();
        }

        public int Insert(Bibliotecario bibliotecario)
        {
            int numFilas = 0;
            object idBibliotecario = null;
            string sentenciaSQL = string.Empty;

            // Devuelve -1 si ha habido un error, 0 si no se ha insertado ninguna fila pero no ha habido error y
            // 1 si la fila se ha insertado correctamente, en el campo Id del objeto se coloca el número autogenerado
            // en la inserción

            try
            {
                sentenciaSQL = @"INSERT INTO dbo.Bibliotecario VALUES 
				(Apellido = @Apellido, Nombre = @Nombre, Email = @Email, Contrasenia = @Contrasenia); 
                SELECT SCOPE_IDENTITY();";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@Apellido", bibliotecario.Apellido);
                cmd.Parameters.AddWithValue("@Nombre", bibliotecario.Nombre);
                cmd.Parameters.AddWithValue("@Email", bibliotecario.Email);
                cmd.Parameters.AddWithValue("@Contrasenia", bibliotecario.Contrasenia);
                idBibliotecario = cmd.ExecuteScalar();

                if (idBibliotecario != null)
                {
                    bibliotecario.Id = (int)(decimal)idBibliotecario;
                    numFilas = 1;
                }
				else
					bibliotecario.Id = 0;
				
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
				bibliotecario.Id = 0;
                numFilas = -1;
            }

            bdConnection.DisconnectBD();
            return numFilas;
        }
        public int Delete(int idBibliotecario)
        {
            int numFilas = 0;
            string sentenciaSQL = string.Empty;

            // Devuelve 0 si no se ha borrado ninguna línea de la tabla, -1 si ha habido algún error o 1 si se ha borrado
            // la línea indicada en la variable idSocio

            try
            {
                sentenciaSQL = "DELETE FROM dbo.Socio WHERE IdBibliotecario = @Id;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@Id", idBibliotecario);
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
        public int Update(Bibliotecario bibliotecario)
        {
            int numFilas = 0;
            string sentenciaSQL = string.Empty;

            // Devuelve 0 si no se ha actualizado ninguna línea de la tabla, -1 si ha habido algún error o 1 si se ha actualizado
            // la línea indicada en la variable bibliotecario

            try
            {
                sentenciaSQL = @"UPDATE dbo.AlquilerEjemplar SET Apellido = @Apellido, Nombre = @Nombre, Email = @Email, 
                Contrasenia = @Contrasenia WHERE IdBibliotecario = @Id;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@Apellido", bibliotecario.Apellido);
                cmd.Parameters.AddWithValue("@Nombre", bibliotecario.Nombre);
                cmd.Parameters.AddWithValue("@Email", bibliotecario.Email);
                cmd.Parameters.AddWithValue("@Contrasenia", bibliotecario.Contrasenia);
                cmd.Parameters.AddWithValue("@Id", bibliotecario.Id);
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
        public List<Bibliotecario> Select()
        {
            SqlDataReader lector = null;
			string sentenciaSQL = "SELECT * FROM dbo.Bibliotecario;";
			List<Bibliotecario> listaBibliotecarios = new List<Bibliotecario>();

            try
            {
                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    Bibliotecario bibliotecario = new Bibliotecario();
                    bibliotecario.Id = lector.GetInt32(lector.GetOrdinal("IdBibliotecario"));
                    bibliotecario.Nombre = lector.GetString(lector.GetOrdinal("Nombre"));
                    bibliotecario.Apellido = lector.GetString(lector.GetOrdinal("Apellido"));
                    bibliotecario.Email = lector.GetString(lector.GetOrdinal("Email"));
                    bibliotecario.Contrasenia = lector.GetString(lector.GetOrdinal("Contrasenia"));
                    listaBibliotecarios.Add(bibliotecario);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            bdConnection.DisconnectBD();
            return listaBibliotecarios;
            ;
        }
        public Bibliotecario SelectById(int idBibliotecario)
        {
            SqlDataReader lector = null;
            Bibliotecario bibliotecario = null;
            string sentenciaSQL = string.Empty;

            try
            {
                sentenciaSQL = "SELECT * FROM dbo.Bibliotecario WHERE IdBibliotecario = @Id;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@Id", idBibliotecario);
                lector = cmd.ExecuteReader();

                if (lector.Read())
                {
                    bibliotecario = new Bibliotecario();
                    bibliotecario.Id = lector.GetInt32(lector.GetOrdinal("IdBibliotecario"));
                    bibliotecario.Nombre = lector.GetString(lector.GetOrdinal("Nombre"));
                    bibliotecario.Apellido = lector.GetString(lector.GetOrdinal("Apellido"));
                    bibliotecario.Email = lector.GetString(lector.GetOrdinal("Email"));
                    bibliotecario.Contrasenia = lector.GetString(lector.GetOrdinal("Contrasenia"));
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            bdConnection.DisconnectBD();
            return bibliotecario;
        }

        public Bibliotecario SelectByEmail(int email)
        {
            SqlDataReader lector = null;
            Bibliotecario bibliotecario = null;
            string sentenciaSQL = string.Empty;

            // La usaremos con el login, el campo email es único para cada bibliotecario

            try
            {
                sentenciaSQL = "SELECT * FROM dbo.Bibliotecario WHERE Email = @Email;";

                bdConnection.ConnectBD();
                SqlCommand cmd = new SqlCommand(sentenciaSQL, bdConnection.sqlConnection);
                cmd.Parameters.AddWithValue("@Email", email);
                lector = cmd.ExecuteReader();

                if (lector.Read())
                {
                    bibliotecario = new Bibliotecario();
                    bibliotecario.Id = lector.GetInt32(lector.GetOrdinal("IdBibliotecario"));
                    bibliotecario.Nombre = lector.GetString(lector.GetOrdinal("Nombre"));
                    bibliotecario.Apellido = lector.GetString(lector.GetOrdinal("Apellido"));
                    bibliotecario.Email = lector.GetString(lector.GetOrdinal("Email"));
                    bibliotecario.Contrasenia = lector.GetString(lector.GetOrdinal("Contrasenia"));
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            bdConnection.DisconnectBD();
            return bibliotecario;
        }
    }
}