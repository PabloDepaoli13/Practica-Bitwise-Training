namespace AppBibliotecaBitwise6.DTO
{
    public class LibroNombresDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string FechaPublicacion { get; set; }

        public bool ParaPresar { get; set; }

        public string NombreGenero { get; set; }

        public string NombreAutor { get; set; }

        public HashSet<ComentarioDTO> Comentarios { get; set; } = new HashSet<ComentarioDTO>();
    }
}
