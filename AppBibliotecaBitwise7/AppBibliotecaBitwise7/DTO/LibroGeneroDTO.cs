namespace AppBibliotecaBitwise7.DTO
{
    public class LibroGeneroDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public bool EsParaPrestar { get; set; }

        public string FechaPublic { get; set; }

        public string nombreGenero { get; set; }
    }
}
