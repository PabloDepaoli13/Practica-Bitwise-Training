using System.ComponentModel.DataAnnotations;

namespace AppBibliotecaBitwise7.DTO
{
    public class UsuarioLoginDTO
    {
        [Required(ErrorMessage = "El Usuario es obligatorio")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "El Password es obligatorio")]
        public string Password { get; set; }
    }
}
