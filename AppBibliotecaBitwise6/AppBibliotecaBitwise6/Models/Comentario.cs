using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBibliotecaBitwise6.Models
{
    public class Comentario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Contenido { get; set; }

        public bool Recomendar { get; set; }

        public int IdLibro { get; set; }

        [ForeignKey("IdLibro")]
        public Libro Libro { get; set; } = null!;
    }
}
