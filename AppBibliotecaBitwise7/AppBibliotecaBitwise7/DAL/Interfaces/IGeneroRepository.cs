using AppBibliotecaBitwise7.Models;

namespace AppBibliotecaBitwise7.DAL.Interfaces
{
    public interface IGeneroRepository : IGenericRepository<Genero>
    {
        public Task<Genero> GeneroWithList(int id);
    }
}
