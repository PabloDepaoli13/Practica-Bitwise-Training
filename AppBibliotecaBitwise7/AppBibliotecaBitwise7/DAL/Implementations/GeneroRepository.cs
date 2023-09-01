using AppBibliotecaBitwise7.DAL.DataContext;
using AppBibliotecaBitwise7.DAL.Interfaces;
using AppBibliotecaBitwise7.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise7.DAL.Implementations
{
    public class GeneroRepository : GenericRepository<Genero>, IGeneroRepository
    {
        private readonly DataDbContext _dbContext;

        public GeneroRepository(DataDbContext dbContext) : base (dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Genero> GeneroWithList(int id)
        {
            var query = await _dbContext.Generos.
                Include(e => e.Libros).
                FirstOrDefaultAsync(e => e.Id == id);
            return query;
        }
    }
}
