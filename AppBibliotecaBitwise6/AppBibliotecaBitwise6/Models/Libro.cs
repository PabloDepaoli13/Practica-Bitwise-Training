using AppBibliotecaBitwise6.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBibliotecaBitwise6.Models
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public DateTime FechaPublicacion { get; set; }

        public bool ParaPresar { get; set; }

        public int IdGenero { get; set; }

        [ForeignKey("IdGenero")]
        public Genero Genero { get; set; } = null!;

        public int IdAutor { get; set; }

        [ForeignKey("IdAutor")]
        public Autor Autor { get; set; } = null!;

        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>();
    }
}
