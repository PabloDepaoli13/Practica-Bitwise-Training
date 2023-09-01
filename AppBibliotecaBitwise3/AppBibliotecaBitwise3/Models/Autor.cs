namespace AppBibliotecaBitwise3.Models
{
    public class Autor
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public HashSet<Libro> libros { get; set; } = new HashSet<Libro>();
    }
}
