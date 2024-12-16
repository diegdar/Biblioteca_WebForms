using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Idioma
    {
		/*  IdIdioma INT PRIMARY KEY IDENTITY(1,1),
            Descripcion VARCHAR(25) NOT NULL */
		
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Idioma () { }
        public Idioma (int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
		public override string ToString()
        {
            return ($"[{Id}]/t{Descripcion}");
        }
	}
}