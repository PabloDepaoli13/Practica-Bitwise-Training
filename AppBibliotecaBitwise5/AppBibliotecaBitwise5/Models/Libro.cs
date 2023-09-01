using System.ComponentModel.DataAnnotations.Schema;

namespace AppBibliotecaBitwise5.Models
{
    public class Libro
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public bool ParaPrestar { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public int IdGenero { get; set; }
        [ForeignKey("IdGenero")]
        public Genero Genero { get; set; } = null!;
        
        public int IdAutor { get; set; }
        [ForeignKey("IdAutor")]
        public Autor Autor { get; set; } = null!;

        public HashSet<Comentarios > Comentarios { get; set; }  = new HashSet<Comentarios>();
    }
}
