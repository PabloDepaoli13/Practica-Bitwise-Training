using AppBibliotecaBitwise3.DAL.DataContext;
using AppBibliotecaBitwise3.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise3.DAL.Implementaciones
{
    public class GenericInterface<T> : IGenericInterface<T> where T : class
    {
        private readonly DbAplicationContext _context;

        public GenericInterface(DbAplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            bool r = false;
            var element = await _context.Set<T>().FindAsync(id);
            _context.Remove(element);
            r = _context.SaveChanges() > 0;
            return r;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetId(int id)
        {
            var element = await _context.Set<T>().FindAsync(id);
            return element;
        }

        public async Task<bool> Post(T entity)
        {
            bool r = false;
            _context.Add(entity);
            r = await _context.SaveChangesAsync() > 0;
            return r;
        }

        public async Task<bool> Update(T entity)
        {
            bool r = false;
            _context.Update(entity);
            r = await _context.SaveChangesAsync() > 0;
            return r;
        }
    }
}
