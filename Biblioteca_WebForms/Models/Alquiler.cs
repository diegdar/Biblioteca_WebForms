using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Alquiler
    {
        /* 	IdAlquiler INT PRIMARY KEY IDENTITY(1,1),
	        FechaAlquiler DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	        FechaDevProbable DATE NOT NULL  DEFAULT DATEADD(DAY,15,GETDATE()),
	        FKSocio INT NOT NULL,
	        FKBibliotecario INT NOT NULL */
		
        public int Id { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaDevProbable { get; set; }
        public int SocioId { get; set; }
        public int BibliotecarioId { get; set; }

        public Alquiler() { }
        public Alquiler (int id, DateTime fechaAlquiler, DateTime fechaDevProbable, int socioId, int bibliotecarioId)
        {
            Id = id;
            FechaAlquiler = fechaAlquiler;
            FechaDevProbable = fechaDevProbable;
            SocioId = socioId;
            BibliotecarioId = bibliotecarioId;
        }
    }
}