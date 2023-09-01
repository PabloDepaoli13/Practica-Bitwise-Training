using AppBibliotecaBitwise7.DAL.DataContext;
using AppBibliotecaBitwise7.DAL.Interfaces;
using AppBibliotecaBitwise7.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise7.DAL.Implementations
{
    public class LibreryRepository : GenericRepository<Libro>, ILibreryReposity
    {
        private readonly DataDbContext _dbContext;
        public LibreryRepository(DataDbContext options) : base(options)
        {
            _dbContext = options;
        }
        public async Task<Libro> GetWithRelacion(int id)
        {
            var query = await _dbContext.Libros.
                                    Include(e => e.Autor).
                                    Include(e => e.Genero).
                                    Include(l => l.Comentarios).
                                    FirstOrDefaultAsync(e => e.Id == id);
            return query;

        }
    }
}
