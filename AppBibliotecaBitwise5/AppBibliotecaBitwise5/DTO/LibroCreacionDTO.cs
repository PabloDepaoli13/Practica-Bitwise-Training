using System.ComponentModel.DataAnnotations.Schema;

namespace AppBibliotecaBitwise5.DTO
{
    public class LibroCreacionDTO
    {

        public string Titulo { get; set; } = null!;

        public bool ParaPrestar { get; set; }

        public string FechaPublicacion { get; set; }

        public int IdGenero { get; set; }
       
        public int IdAutor { get; set; }
        
    }
}
