using AppBibliotecaBitwise8.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppBibliotecaBitwise8.DTO
{
    public class GeneroDTO
    { 
        public int Id { get; set; }

        public string Nombre { get; set; }

        public HashSet<LibroDTO> Libros { get; set; } = new HashSet<LibroDTO>();
    }
}
