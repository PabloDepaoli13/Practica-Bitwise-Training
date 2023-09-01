namespace AppBibliotecaBitwise6.DTO
{
    public class ComentarioDTO
    {
        public int Id { get; set; }

        public string Contenido { get; set; }

        public bool Recomendar { get; set; }

        public int IdLibro { get; set; }
    }
}
