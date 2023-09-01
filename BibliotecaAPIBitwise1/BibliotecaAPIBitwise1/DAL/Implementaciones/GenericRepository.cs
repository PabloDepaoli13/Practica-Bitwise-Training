using BibliotecaAPIBitwise1.DAL.DataContext;
using BibliotecaAPIBitwise1.DAL.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPIBitwise1.DAL.Implementaciones
{
    public class GenericRepository<E> : IGenericRepository<E> where E : class
    {
        private readonly DataAplicationContext _context;

        public GenericRepository(DataAplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            bool resultado = false;
            var alumno = _context.Set<E>().Find(id);
            if (alumno != null)
            {
                _context.Remove(alumno);
                resultado = await _context.SaveChangesAsync()>0;
                
            }
            return resultado;
        }

        public async Task<IEnumerable<E>> GetAll()
        {
            return await _context.Set<E>().ToListAsync();
        }

        public async Task<E> GetId(int id)
        {
            return await _context.Set<E>().FindAsync(id);
        }

        public async Task<bool> Post(E entity)
        {
            bool resultado = false;
            _context.Set<E>().Add(entity);
            resultado = await _context.SaveChangesAsync() > 0;
            return resultado;
        }

        public async Task<bool> Update(E entity)
        {
            bool resultado = false;
            _context.Set<E>().Update(entity);
            resultado = await _context.SaveChangesAsync() > 0;
            return resultado;
        }
    }
}
