using AppBibliotecaBitwise8.DAL.DataContext;
using AppBibliotecaBitwise8.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise8.DAL.Implementatios
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AplicationDataContext _dataContext;

        public GenericRepository(AplicationDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateAsync(T entity)
        {
            var result = false;
            _dataContext.Set<T>().Add(entity);
            result = await _dataContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            var result = false;
            _dataContext.Set<T>().Remove(entity);
            result = await _dataContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dataContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var result = false;
            _dataContext.Set<T>().Update(entity);
            result = await _dataContext.SaveChangesAsync() > 0;
            return true;
        }
    }
}
