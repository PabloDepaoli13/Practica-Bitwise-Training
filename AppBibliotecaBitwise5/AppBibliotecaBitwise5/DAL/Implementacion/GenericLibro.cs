using AppBibliotecaBitwise5.DAL.DataContext;
using AppBibliotecaBitwise5.DAL.Interface;
using AppBibliotecaBitwise5.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise5.DAL.Implementacion
{
    public class GenericLibro : GenericImplementation<Libro>, ILibroRepository
    {
        private readonly AplicationContext _context;
        public GenericLibro(AplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Libro> ObtenerPorIdConRelacion(int id)
        {
            var query = await _context.Libro.
                        Include(a => a.Autor).
                        Include(a => a.Genero).
                        FirstOrDefaultAsync(l => l.Id == id);
            return query;
        }
    }
}
