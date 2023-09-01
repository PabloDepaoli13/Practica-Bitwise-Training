using AppBibliotecaBitwise8.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppBibliotecaBitwise8.DTO
{
    public class LibroCreacionDTO
    {

        public string Titulo { get; set; }

        public bool Recomendar { get; set; }

        public string FechaPublic { get; set; }

        public int IdGenero { get; set; }

        public int IdAutor { get; set; }

    }
}
