using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Editorial
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Editorial() { }
        public Editorial (int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}