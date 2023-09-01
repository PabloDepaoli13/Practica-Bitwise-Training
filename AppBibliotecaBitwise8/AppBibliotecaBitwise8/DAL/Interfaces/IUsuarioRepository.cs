using AppBibliotecaBitwise8.DTO;
using AppBibliotecaBitwise8.Models;

namespace AppBibliotecaBitwise8.DAL.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<UsuarioLoginRespuestaDTO> LoginUser(UsuarioLoginDTO usuario);

        Task<bool> RegisterUser(UsuarioRegistroDTO usuario);

        Task<bool> isUnique(string nombreUser);
    }
}
