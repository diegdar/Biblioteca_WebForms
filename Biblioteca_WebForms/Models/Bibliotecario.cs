using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Bibliotecario
    {
        /*  IdBibliotecario INT PRIMARY KEY IDENTITY(1,1),
	        Apellido VARCHAR(40) NOT NULL,
	        Nombre VARCHAR(40) NOT NULL,
	        Email VARCHAR(60) NOT NULL UNIQUE,
	        Contrasenia VARCHAR(20) NOT NULL */
			
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        public Bibliotecario() { }
        public Bibliotecario (int id, string apellido, string nombre, string email, 
            string contrasenia)
        {
            Id = id;
            Apellido = apellido;
            Nombre = nombre;
            Email = email;
            Contrasenia = contrasenia;
        }
		public override string ToString()
        {				
            return ($"[{Id}]/t{Nombre} {Apellido} {Email}");
        }
    }
}