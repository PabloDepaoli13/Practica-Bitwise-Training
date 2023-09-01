namespace BibliotecaAPIBitwise2.Models
{
    public class Libro
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public bool ParaPrestar { get; set; }

        public DateTime FechaDeLanzamiento { get; set; }

        public int IdAutor { get; set; }

        public Autor Autor { get; set; } = null!;

        public int IdGenero { get; set; }

        public Genero Genero { get; set; } = null!;

        public HashSet<Comentarios> Comentario { get; set; } = new HashSet<Comentarios>();
    }
}
