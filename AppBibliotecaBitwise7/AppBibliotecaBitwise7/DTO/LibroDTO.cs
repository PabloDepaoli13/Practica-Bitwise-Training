using AppBibliotecaBitwise7.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBibliotecaBitwise7.DTO
{
    public class LibroDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public bool EsParaPrestar { get; set; }

        public string FechaPublic { get; set; }

        public string nombreGenero { get; set; }
        
        public string nombreAutor { get; set; }

        public HashSet<ComentarioDTO> Comentarios { get; set; } = new HashSet<ComentarioDTO>();
    }
}
