using BibliotecaAPIBitwise2.DAL.DataContext;
using BibliotecaAPIBitwise2.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPIBitwise2.DAL.Implementaciones
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataAplicationContext _context;

        public GenericRepository(DataAplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            bool resultado = false;
            var objeto = _context.Set<T>().Find(id);
            if (objeto != null) 
            {
                _context.Remove(objeto);
                resultado = await _context.SaveChangesAsync() > 0; 
            }
            return resultado;
        }

        public async Task<bool> Enviar(T entity)
        {
            bool resultado = false;
            await _context.AddAsync(entity);
            resultado =  await _context.SaveChangesAsync() > 0;
            return resultado;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
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
