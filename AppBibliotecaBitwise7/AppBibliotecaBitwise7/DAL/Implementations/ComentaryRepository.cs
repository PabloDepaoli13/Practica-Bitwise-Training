using AppBibliotecaBitwise7.DAL.DataContext;
using AppBibliotecaBitwise7.DAL.Interfaces;
using AppBibliotecaBitwise7.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise7.DAL.Implementations
{
    public class ComentaryRepository : GenericRepository<Comentario>, IComentaryRepository
    {
        private readonly DataDbContext _dbContext;

        public ComentaryRepository(DataDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Comentario> GetComentaryWithName(int id)
        {
            var comentary = await _dbContext.Comentarios.Include(e => e.Libro).FirstOrDefaultAsync(e => e.Id == id);
            return comentary;
        }
    }
}
