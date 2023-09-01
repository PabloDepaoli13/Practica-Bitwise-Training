using AppBibliotecaBitwise8.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppBibliotecaBitwise8.DTO
{
    public class AutorDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string FechaNacimiento { get; set; }

    }
}
