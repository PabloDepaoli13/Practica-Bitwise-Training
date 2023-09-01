using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBibliotecaBitwise7.Models
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public bool EsParaPrestar { get; set; }

        public DateTime FechaPublic { get; set; }

        public int IdGenero { get; set; }
        [ForeignKey("IdGenero")]
        public Genero Genero { get; set; } = null!;

        public int IdAutor { get; set; }
        [ForeignKey("IdAutor")]
        public Autor Autor { get; set; } = null!;

        public HashSet<Comentario> Comentarios { get; set; } =  new HashSet<Comentario>();
    }
}
