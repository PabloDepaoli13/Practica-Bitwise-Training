namespace AppBibliotecaBitwise4.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        public string Contenido { get; set; }

        public bool Recomendar { get; set; }

        public int IdLibro { get; set; }

        public Libro Libro { get; set; } = null!;
    }
}
