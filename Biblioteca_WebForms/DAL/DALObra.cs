using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca_WebForms.DAL
{
    public class DALObra
    {
        private DataLinQ_BibliotecaDataContext dataDB = new DataLinQ_BibliotecaDataContext();
        public string Mensaje { get; set; }

        public Obra GetById(int idObra)
        {
            try
            {
                return dataDB.Obras.Where(ob=>ob.IdObra == idObra).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }
        }

        public List<Obra> GetList()
        {
            try
            {
                return from c in dataDB.Obras.ToList();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return null;
            }
        }

        public bool Insert(Obra obra, List<int> listaIdGenero, List<int> ListaIdAutor)
        {
            try
            {
                dataDB.Obras.InsertOnSubmit(obra);
                dataDB.SubmitChanges();

                foreach (var generoId in listaIdGenero)
                {
                    var obraGenero = new ObraGenero
                    {
                        FKObra = obra.IdObra,
                        FKGenero = generoId
                    };
                    dataDB.ObraGeneros.InsertOnSubmit(obraGenero);
                }

                foreach (var autorId in ListaIdAutor)
                {
                    var obraAutor = new AutorObra
                    {
                        FKObra = obra.IdObra,
                        FKAutor = autorId
                    };
                    dataDB.AutorObras.InsertOnSubmit(obraAutor);
                }

                dataDB.SubmitChanges(); // Guardar las dos relaciones, Autor y Genero

                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }

        public bool Update(Obra obra, List<int> listaIdGenero, List<int> ListaIdAutor)
        {
            try
            {
                var obraExistente = dataDB.Obras.Where(ob => ob.IdObra ==obra.IdObra).FirstOrDefault();
                obraExistente.Titulo = obra.Titulo;
                obraExistente.Sinopsis = obra.Sinopsis;

                // Primero, eliminar las relaciones existentes
                // Actualizar las relaciones con los géneros nuevos

                var generosExistentes = dataDB.ObraGeneros.Where(ob => ob.FKObra == obra.IdObra).ToList();
                dataDB.ObraGeneros.DeleteAllOnSubmit(generosExistentes);

                foreach (var generoId in listaIdGenero)
                {
                    var obraGenero = new ObraGenero
                    {
                        FKObra = obra.IdObra,
                        FKGenero = generoId
                    };
                    dataDB.ObraGeneros.InsertOnSubmit(obraGenero);
                }

                // Primero, eliminar las relaciones existentes
                // Actualizar las relaciones con los autores nuevos

                var autoresExistentes = dataDB.AutorObras.Where(oa => oa.FKObra == obra.IdObra).ToList();
                dataDB.AutorObras.DeleteAllOnSubmit(autoresExistentes);

                foreach (var autorId in ListaIdAutor)
                {
                    var obraAutor = new AutorObra
                    {
                        FKObra = obra.IdObra,
                        FKAutor = autorId
                    };
                    dataDB.AutorObras.InsertOnSubmit(obraAutor);
                }

                dataDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }

        public bool Delete(int idObra)
        {
            try
            {
                var obra = dataDB.Obras.Where(ob=>ob.IdObra == idObra).FirstOrDefault();

                // Eliminar las relaciones con los generos
                var generosExistentes = dataDB.ObraGeneros.Where(ob => ob.FKObra == idObra).ToList();
                dataDB.ObraGeneros.DeleteAllOnSubmit(generosExistentes);

                // Eliminar las relaciones con los autores
                var autoresExistentes = dataDB.AutorObras.Where(oa => oa.FKObra == idObra).ToList();
                dataDB.AutorObras.DeleteAllOnSubmit(autoresExistentes);

                // Eliminar la obra
                dataDB.Obras.DeleteOnSubmit(obra);

                // Guarda los cambios
                dataDB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
    }
}
    