using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Bibliotecario
    {
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
    }
}