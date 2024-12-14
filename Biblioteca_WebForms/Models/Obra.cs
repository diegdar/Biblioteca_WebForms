using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Obra
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }

        public Obra () { }
        public Obra(int id, string titulo, string sinopsis = null)
        {
            Id = id;
            Titulo = titulo;
            Sinopsis = sinopsis;
        }
    }
}