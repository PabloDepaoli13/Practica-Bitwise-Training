using AppBibliotecaBitwise5.DAL.DataContext;
using AppBibliotecaBitwise5.DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise5.DAL.Implementacion
{
    public class GenericImplementation<T> : IGenericContract<T> where T : class
    {
        private readonly AplicationContext _context;

        public GenericImplementation(AplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            bool resultado = false;
            var entidad = await _context.Set<T>().FindAsync(id);
            if (entidad != null) 
            {
                _context.Remove(entidad);
                resultado = await _context.SaveChangesAsync() > 0;
            }
            
            return resultado;
        }

        public async Task<T> Get(int id)
        {
           return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> Post(T entity)
        {
            bool resultado = false;
            _context.Add(entity);
            resultado = await _context.SaveChangesAsync() > 0;
            return resultado;
        }

         public async Task<bool> Update(T entity)
        {
            bool resultado = false;
            _context.Update(entity);
            resultado = await _context.SaveChangesAsync() > 0;
            return resultado;
        }
    }
}
