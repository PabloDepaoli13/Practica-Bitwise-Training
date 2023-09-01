namespace AppBibliotecaBitwise7.DTO
{
    public class LibroCreacionDTO
    {
        public string Nombre { get; set; } = null!;

        public bool EsParaPrestar { get; set; }

        public string FechaPublic { get; set; }

        public int IdGenero { get; set; }

        public int IdAutor { get; set; }
    }
}
