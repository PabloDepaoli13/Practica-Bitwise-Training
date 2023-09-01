using AppBibliotecaBitwise4.DAL.DataContext;
using AppBibliotecaBitwise4.DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise4.DAL.Implementacion
{
    public class GenericInterface<T> : IGenericInterface<T> where T : class
    {
        private readonly AplicationContext _context;
             
        public GenericInterface(AplicationContext context) 
        {
            _context= context;
        }
        public async Task<bool> Delete(int id)
        {
            bool result= false;
            _context.Remove(id);
            result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> Post(T entity)
        {
            bool success= false;
            _context.Add(entity);
            success = await _context.SaveChangesAsync() > 0;
            return success;
        }

        public async Task<bool> Put(T entity)
        {
            bool success = false;
            _context.Update(entity);
            success = await _context.SaveChangesAsync() > 0;
            return success;
        }
    }
}
