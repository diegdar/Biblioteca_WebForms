using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Autor
    {
        /*  IdAutor INT PRIMARY KEY IDENTITY(1,1),
	        Apellido1 VARCHAR(40) NOT NULL,
	        Apellido2 VARCHAR(40),
	        Nombre VARCHAR(40) */
        public int Id { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Nombre { get; set; }

        public Autor() { }
        public Autor (int id, string apellido1, string apellido2 = null, string nombre = null)
        {
            Id = id;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Nombre = nombre;
        }

    }
}