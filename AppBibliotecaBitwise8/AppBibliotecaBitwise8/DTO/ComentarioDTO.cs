using AppBibliotecaBitwise8.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppBibliotecaBitwise8.DTO
{
    public class ComentarioDTO
    {
        public int Id { get; set; }

        public string Contenido { get; set; }

        public bool Recomendar { get; set; }


    }
}
