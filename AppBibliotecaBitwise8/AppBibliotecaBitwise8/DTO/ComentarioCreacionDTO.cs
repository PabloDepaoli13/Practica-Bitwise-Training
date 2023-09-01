using AppBibliotecaBitwise8.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppBibliotecaBitwise8.DTO
{
    public class ComentarioCreacionDTO
    {
        public string Contenido { get; set; }

        public bool Recomendar { get; set; }

        public int IdLibro { get; set; }

    }
}
