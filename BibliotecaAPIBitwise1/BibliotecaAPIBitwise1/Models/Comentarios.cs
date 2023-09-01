namespace BibliotecaAPIBitwise1.Models
{
    public class Comentarios
    {
        public int Id { get; set; }

        public string? Contenido { get; set; }

        public bool Recomendar { get; set; }

        public int LibroId { get; set; }

        public Libro Libro { get; set; } = null!;
    }
}
