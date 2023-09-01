namespace AppBibliotecaBitwise6.DTO
{
    public class LibroCreacionDTO
    {
        public string Titulo { get; set; } = null!;

        public string FechaPublicacion { get; set; }

        public bool ParaPresar { get; set; }

        public int IdGenero { get; set; }

        public int IdAutor { get; set; }
    }
}
