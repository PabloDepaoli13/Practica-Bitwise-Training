namespace BibliotecaAPIBitwise1.Models
{
    public class Libro
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public bool ParaPrestar { get; set; }

        public DateTime FechaDeLanzamiento { get; set; }

        public int AutorId { get; set; }

        public Autor Autor { get; set; } = null!;

        public int GeneroId { get; set; }

        public Genero Genero { get; set; } = null!;

        public HashSet<Comentarios> Comentarios { get; set; } = new HashSet<Comentarios>();
    }
}
