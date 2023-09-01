namespace AppBibliotecaBitwise3.Models
{
    public class Genero
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public HashSet<Libro> libros { get; set; } = new HashSet<Libro>();
    }
}
