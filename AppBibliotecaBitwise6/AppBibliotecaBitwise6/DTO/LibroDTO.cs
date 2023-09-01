using AppBibliotecaBitwise6.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBibliotecaBitwise6.DTO
{
    public class LibroDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string FechaPublicacion { get; set; }

        public bool ParaPresar { get; set; }

        public int IdGenero { get; set; }

        public int IdAutor { get; set; }
    }
}
