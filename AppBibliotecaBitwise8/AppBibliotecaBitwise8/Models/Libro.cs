using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBibliotecaBitwise8.Models
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public bool Recomendar { get; set; }

        public DateTime FechaPublic { get; set; }

        public int IdGenero { get; set; }
        [ForeignKey("IdGenero")]
        public Genero Generos { get; set; } = null!;

        public int IdAutor { get; set; }
        [ForeignKey("IdAutor")]
        public Autor Autor { get; set; } = null!;

        public HashSet<Comentarios> Comentarios { get; set; } = new HashSet<Comentarios>();

    }
}
