using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class ObraGenero
    {
        public int Id { get; set; }
        public int ObraId {get; set; }

        public int GeneroId { get; set; }

        public ObraGenero() { }
        public ObraGenero (int id, int obraId, int generoId)
        {
            Id = id;
            ObraId = obraId;
            GeneroId = generoId;
        }
    }
}