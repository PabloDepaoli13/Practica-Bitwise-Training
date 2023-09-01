using System.ComponentModel.DataAnnotations;

namespace AppBibliotecaBitwise7.DTO
{
    public class UsuarioRegistroDTO
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Password es obligatorio")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
