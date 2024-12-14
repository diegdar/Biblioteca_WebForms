using Biblioteca.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Socio
    {
		public int Id { get; set; }
		public string Apellido { get; set; }
		public string Nombre { get; set; }
		public string Email { get; set; }
		public string Domicilio { get; set; }
		public string Telefono { get; set; }

        public Socio() { }
        public Socio(
            int id,
            string apellido,
            string nombre,
            string email,
            string domicilio = null,
            string telefono = null)
        {
            Id = id;
            Apellido = apellido;
            Nombre = nombre;
            Email = email;
            Domicilio = domicilio;
            Telefono = telefono;
        }
    }
}