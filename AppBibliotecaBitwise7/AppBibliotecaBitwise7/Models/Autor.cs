using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBibliotecaBitwise7.Models
{
    public class Autor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaNac { get; set; }

        public HashSet<Libro> Libros { get; set; } = new HashSet<Libro>();
    }
}
