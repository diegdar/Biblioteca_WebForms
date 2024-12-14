using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Idioma
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Idioma () { }
        public Idioma (int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}