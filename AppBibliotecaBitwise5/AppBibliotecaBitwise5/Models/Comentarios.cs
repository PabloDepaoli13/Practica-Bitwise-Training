using System.ComponentModel.DataAnnotations.Schema;

namespace AppBibliotecaBitwise5.Models
{
    public class Comentarios
    {
        public int Id { get; set; } 

        public string Contenido { get; set; }


        public bool Recomendar { get; set; }


        public int IdLibro { get; set; }
        [ForeignKey("IdLibro")]


        public Libro Libro { get; set; } = null!;
    }
}
