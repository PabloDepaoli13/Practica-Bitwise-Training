using AppBibliotecaBitwise8.DAL.DataContext;
using AppBibliotecaBitwise8.DAL.Interfaces;
using AppBibliotecaBitwise8.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise8.DAL.Implementatios
{
    public class LibraryRepository : GenericRepository<Libro>, ILibraryRepository
    {
        private readonly AplicationDataContext _dataContext;
        public LibraryRepository(AplicationDataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Libro> GetWithRelacion(int id)
        {
            var llamada = await _dataContext.libros.Include(e => e.Generos)
                .Include(e => e.Autor)
                .Include(e => e.Comentarios)
                .FirstOrDefaultAsync(e => e.Id == id);

            return llamada;
        }
    }
}
