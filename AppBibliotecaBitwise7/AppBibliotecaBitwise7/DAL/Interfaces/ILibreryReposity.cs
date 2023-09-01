using AppBibliotecaBitwise7.DTO;
using AppBibliotecaBitwise7.Models;

namespace AppBibliotecaBitwise7.DAL.Interfaces
{
    public interface ILibreryReposity : IGenericRepository<Libro>
    {
        public Task<Libro> GetWithRelacion(int id);
    }
}
