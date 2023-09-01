using AppBibliotecaBitwise8.Models;

namespace AppBibliotecaBitwise8.DTO
{
    public class LibroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public bool Recomendar { get; set; }

        public string FechaPublic { get; set; }

        public string nombreGenero { get; set; }

        public string nombreAutor { get; set; }

        public HashSet<ComentarioDTO> Comentarios { get; set; } = new HashSet<ComentarioDTO>();
    }
}
