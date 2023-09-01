using AppBibliotecaBitwise6.DAL.DataContext;
using AppBibliotecaBitwise6.DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise6.DAL.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AplicationDbContext _context;

        public GenericRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Actualizar(T entity)
        {
            var result = false;
            _context.Update(entity);
            result = await _context.SaveChangesAsync() > 1;
            return result;
        }

        public async Task<bool> Borrar(int id)
        {
            var result = false;
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Remove(entity);
            result = await _context.SaveChangesAsync() > 1;
            return result;
        }

        public async Task<T> ObtenerId(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ObtenerTodos()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> Subir(T entity)
        {
            var result = false;
            _context.Add(entity);
            result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}
