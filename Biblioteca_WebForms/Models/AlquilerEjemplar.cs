using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Biblioteca.Models
{
    public class AlquilerEjemplar
    {
        public int Id { get; set; }
        public int AlquilerId { get; set; }
        public int EjemplarId { get; set; }
        public DateTime? FechaDevReal { get; set; }

        public AlquilerEjemplar() { }
        public AlquilerEjemplar (int id, int alquilerId, int ejemplarId, DateTime? fechaDevReal)
        {
            Id = id;
            AlquilerId = alquilerId;
            EjemplarId = ejemplarId;
            FechaDevReal = fechaDevReal;
        }
    }
}