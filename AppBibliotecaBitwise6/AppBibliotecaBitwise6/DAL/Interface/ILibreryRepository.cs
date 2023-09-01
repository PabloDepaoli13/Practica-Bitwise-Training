using AppBibliotecaBitwise6.DTO;
using AppBibliotecaBitwise6.Models;

namespace AppBibliotecaBitwise6.DAL.Interface
{
    public interface ILibreryRepository : IGenericRepository<Libro>
    {
        public Task<Libro> GetWithRelacion(int Id);
    }
}
