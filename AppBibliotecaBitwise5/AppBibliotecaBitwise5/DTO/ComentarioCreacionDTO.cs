﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AppBibliotecaBitwise5.DTO
{
    public class ComentarioCreacionDTO
    {

        public string Contenido { get; set; }


        public bool Recomendar { get; set; }


        public int IdLibro { get; set; }
        
    }
}
