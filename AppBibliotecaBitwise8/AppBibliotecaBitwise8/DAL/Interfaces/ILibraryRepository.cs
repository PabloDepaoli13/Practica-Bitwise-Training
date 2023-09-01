using AppBibliotecaBitwise8.Models;

namespace AppBibliotecaBitwise8.DAL.Interfaces
{
    public interface ILibraryRepository : IGenericRepository<Libro>
    {
        Task<Libro> GetWithRelacion(int id);
    }
}
