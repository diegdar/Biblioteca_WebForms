﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Ejemplar
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string ISBN { get; set; }
        public int? AnioPublicacion { get; set; }
        public bool EstaBuenEstado { get; set; }
        public int? NumPaginas { get; set; }
        public bool EstaAlquilado { get; set; }
        public int EditorialId { get; set; }
        public int ObraId { get; set; }
        public int? UbicacionId { get; set; }
        public int IdiomaId { get; set; }

        public Ejemplar() { }
        public Ejemplar (
            int id,
            bool estaBuenEstado,
            bool estaAlquilado,
            int editorialId,
            int obraId,
            int idiomaId,
            int? anioPublicacion,
            int? numPaginas,
            int? ubicacionId,
            string codigoBarras = null,
            string isbn = null
           )
        {
            Id = id;
            CodigoBarras = codigoBarras;
            ISBN = isbn;
            AnioPublicacion = anioPublicacion;
            EstaBuenEstado = estaBuenEstado;
            NumPaginas = numPaginas;
            EstaAlquilado = estaAlquilado;
            EditorialId = editorialId;
            ObraId = obraId;
            UbicacionId = ubicacionId;
            IdiomaId = idiomaId;
        }

    }
}