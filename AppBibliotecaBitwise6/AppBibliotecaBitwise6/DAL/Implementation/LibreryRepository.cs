using AppBibliotecaBitwise6.DAL.DataContext;
using AppBibliotecaBitwise6.DAL.Interface;
using AppBibliotecaBitwise6.DTO;
using AppBibliotecaBitwise6.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise6.DAL.Implementation
{
    public class LibreryRepository : GenericRepository<Libro>, ILibreryRepository
    {
        private readonly AplicationDbContext _context;
        public LibreryRepository(AplicationDbContext context) : base(context) 
        {
              _context = context;
        }
        public async Task<Libro> GetWithRelacion(int id)
        {
            var query =  await _context.Libros.
                                Include(e => e.Genero).
                                Include(e => e.Autor).
                                Include(e => e.Comentarios).
                                FirstOrDefaultAsync(e => e.Id == id);

            return query;
        }
    }
}
