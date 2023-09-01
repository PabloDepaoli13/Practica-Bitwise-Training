namespace AppBibliotecaBitwise4.Models
{
    public class Libro
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public bool ParaPrestar { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public int IdAutor { get; set; }

        public Autor autor { get; set; } = null!;

        public int IdGenero { get; set; }

        public Genero Genero { get; set; } = null!;

        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>(); 
    }
}
