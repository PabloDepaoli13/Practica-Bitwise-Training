namespace AppBibliotecaBitwise3.Models
{
    public class Libro
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public bool ParaPrestar { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public int IdAutor { get; set; }

        public Autor autor { get;set; }

        public int IdGenero { get; set; }

        public Genero genero { get; set; }

        public HashSet<Comentario> comentarios { get; set; } = new HashSet<Comentario>();
    }
}
