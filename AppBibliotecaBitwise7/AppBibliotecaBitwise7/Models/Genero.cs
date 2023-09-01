using System.ComponentModel.DataAnnotations;

namespace AppBibliotecaBitwise7.Models
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public HashSet<Libro> Libros { get; set; } = new HashSet<Libro>();
    }
}
