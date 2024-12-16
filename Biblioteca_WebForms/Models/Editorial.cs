using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Editorial
    {
        /*  IdEditorial INT PRIMARY KEY IDENTITY(1,1),
	        Descripcion VARCHAR(25) NOT NULL */
		
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Editorial() { }
        public Editorial (int id, string descripcion)
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