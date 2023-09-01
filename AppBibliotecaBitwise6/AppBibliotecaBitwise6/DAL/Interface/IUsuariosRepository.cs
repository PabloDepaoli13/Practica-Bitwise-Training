using AppBibliotecaBitwise6.DTO;
using AppBibliotecaBitwise6.Models;

namespace AppBibliotecaBitwise6.DAL.Interface
{
    public interface IUsuariosRepository : IGenericRepository<Usuario> 
    {
        Task<bool> isUnique(string usuario);

        Task<bool> CargarUsuario(UsuarioRegistroDTO usuarioRegistroDTO);

        Task<UsuarioLoginRespuestaDTO> LoginUsuario(UsuarioLoginDTO usuario);
    }
}
