using AppBibliotecaBitwise7.Models;

namespace AppBibliotecaBitwise7.DAL.Interfaces
{
    public interface IComentaryRepository : IGenericRepository<Comentario>
    {
        public Task<Comentario> GetComentaryWithName(int id);
    }
}
