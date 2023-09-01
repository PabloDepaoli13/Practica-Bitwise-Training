namespace AppBibliotecaBitwise4.Models
{
    public class Genero
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public HashSet<Libro> Libros { get; set; }  = new HashSet<Libro>();
    }
}
