using System;
using System.Collections.Generic;

#nullable disable

namespace Cine.Models
{
    public partial class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }
        public int Puntuacion { get; set; }
        public string Rating { get; set; }
        public DateTime AñoPublicacion { get; set; }
    }
}
