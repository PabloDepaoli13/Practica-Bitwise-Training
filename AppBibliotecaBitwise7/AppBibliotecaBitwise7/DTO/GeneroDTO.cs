using AppBibliotecaBitwise7.Models;

namespace AppBibliotecaBitwise7.DTO
{
    public class GeneroDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public HashSet<LibroGeneroDTO> Libros { get; set; } = new HashSet<LibroGeneroDTO>();
    }
}
