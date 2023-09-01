using AppBibliotecaBitwise5.Models;

namespace AppBibliotecaBitwise5.DTO
{
    public class LibroDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public bool ParaPrestar { get; set; }

        public string FechaPublicacion { get; set; }

        public string nombreGenero { get; set; }

        public string nombreAutor { get; set; }

        public HashSet<ComentarioDTO> Comentarios { get; set; } = new HashSet<ComentarioDTO>();

    }
}
