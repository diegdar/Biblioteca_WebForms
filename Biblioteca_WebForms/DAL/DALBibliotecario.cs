using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Biblioteca_WebForms.DAL
{
    public class DALBibliotecario
    {
        private DataLinQ_BibliotecaDataContext dataDB = new DataLinQ_BibliotecaDataContext();
        public string Mensaje { get; set; }

        public bool Insert(Bibliotecario bibliotecario)
        {
            // Devuelve true si se ha insertado el objeto y false si no se
            // ha conseguido

            try
            {
                dataDB.Bibliotecarios.InsertOnSubmit(bibliotecario);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public bool Delete(int idBibliotecario)
        {
            // Devuelve true si se ha borrado el objeto o false si no lo ha
            // conseguido

            try
            {
                var bibliotecario = (from bi in dataDB.Bibliotecarios
                                     where bi.IdBibliotecario == idBibliotecario
                                     select bi).FirstOrDefault();

                dataDB.Bibliotecarios.DeleteOnSubmit(bibliotecario);
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public bool Update(Bibliotecario newBibliotecario)
        {
            // Devuelve true si se ha modificado el objeto o false si no se
            // ha conseguido

            try
            {
                var bibliotecario = (from bi in dataDB.Bibliotecarios
                                     where bi.IdBibliotecario == newBibliotecario.IdBibliotecario
                                     select bi).FirstOrDefault();

                if (bibliotecario == null)
                    return false;

                bibliotecario.Apellido = newBibliotecario.Apellido;
                bibliotecario.Nombre = newBibliotecario.Nombre;
                bibliotecario.Email = newBibliotecario.Email;
                bibliotecario.Contrasenia = newBibliotecario.Contrasenia;
                dataDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }

            return true;
        }
        public List<Bibliotecario> GetList()
        {
            // Devuelve null si se ha producido un error o la lista de
            // de objetos si no se ha producido

            List<Bibliotecario> listaBibliotecario = new List<Bibliotecario>();

            try
            {
                var lstBibliotecario = from bibliotecario in dataDB.Bibliotecarios
                                       select bibliotecario;

                foreach (var bibliotecario in lstBibliotecario)
                {
                    listaBibliotecario.Add(bibliotecario);
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return listaBibliotecario;
        }
        public Bibliotecario GetById(int idBibliotecario)
        {
            // Devuelve null si se ha producido un error o el objeto
            // buscado si no se ha producido

            Bibliotecario bibliotecario = new Bibliotecario();

            try
            {
                var bibliotecarioById = (from bi in dataDB.Bibliotecarios
                                         where bi.IdBibliotecario == idBibliotecario
                                         select bi).FirstOrDefault();

                if (bibliotecarioById == null)
                    return null;

                bibliotecario.IdBibliotecario = bibliotecarioById.IdBibliotecario;
                bibliotecario.Apellido = bibliotecarioById.Apellido;
                bibliotecario.Nombre = bibliotecarioById.Nombre;
                bibliotecario.Email = bibliotecarioById.Email;
                bibliotecario.Contrasenia = bibliotecarioById.Contrasenia;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return bibliotecario;
        }
        public Bibliotecario GetByEmail(string email)
        {
            // La usaremos con el login, el campo email es único
            // y no puede tomar un valor nulo para cada bibliotecario
            // Es clave candidata

            // Devuelve null si se ha producido un error o el objeto
            // buscado si no se ha producido

            Bibliotecario bibliotecario = new Bibliotecario();

            try
            {
                var bibliotecarioById = (from bi in dataDB.Bibliotecarios
                                         where bi.Email == email
                                         select bi).FirstOrDefault();

                if (bibliotecarioById == null)
                    return null;

                bibliotecario.IdBibliotecario = bibliotecarioById.IdBibliotecario;
                bibliotecario.Apellido = bibliotecarioById.Apellido;
                bibliotecario.Nombre = bibliotecarioById.Nombre;
                bibliotecario.Email = bibliotecarioById.Email;
                bibliotecario.Contrasenia = bibliotecarioById.Contrasenia;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }

            return bibliotecario;
        }

        public List<Bibliotecario> GetFilter(string texto)
        {
            return dataDB.Bibliotecarios.Where(bi=>bi.Apellido.StartsWith(texto))
                                        .OrderBy(bi=>bi.Apellido)
                                        .ToList();
        }

        public bool VerifyExist(int idBiblio)
        {
            var resul = dataDB.Alquilers.Where(ob => ob.FKBibliotecario == idBiblio).ToList();
            if (resul.Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}