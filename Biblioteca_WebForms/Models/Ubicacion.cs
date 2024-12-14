using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Ubicacion
    {
        public int Id { get; set; }
        public int Estanteria { get; set; }
        public string Fila { get; set; }
        public string Columna { get; set; }

        public Ubicacion() { }
        Ubicacion (int id, int estanteria, string fila, string columna)
        {
            Id = id;
            Estanteria = estanteria;
            Fila = fila;
            Columna = columna;
        }
    }
}