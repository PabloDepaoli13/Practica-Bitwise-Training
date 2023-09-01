using AppBibliotecaBitwise7.DTO;
using AppBibliotecaBitwise7.Models;

namespace AppBibliotecaBitwise7.DAL.Interfaces
{
    public interface IUsuaryRepository : IGenericRepository<Usuario>
    {
        Task<bool> IsUniqueUser(string usuario);

        Task<bool> Register(UsuarioRegistroDTO usuarioRegistroDTO);

        Task<UsuarioLoginRespuestaDTO> Login(UsuarioLoginDTO usuarioLogin);
    }
}
