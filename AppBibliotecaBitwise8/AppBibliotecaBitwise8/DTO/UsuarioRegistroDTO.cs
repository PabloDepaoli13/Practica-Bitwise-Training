using System.ComponentModel.DataAnnotations;

namespace AppBibliotecaBitwise8.DTO
{
    public class UsuarioRegistroDTO
    {
        [Required(ErrorMessage ="El nombre de usuario es obligatorio")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "El password es obligatorio")]
        public string Password { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        public string Role { get; set; }
    }
}
