using AppBibliotecaBitwise7.DAL.DataContext;
using AppBibliotecaBitwise7.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise7.DAL.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataDbContext _dbContext;

        public GenericRepository(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var result = false;
            var entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Remove(entity);
            result = await _dbContext.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetId(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> PostAsync(T entity)
        {
            var result = false;
            await _dbContext.AddAsync(entity);
            result = await _dbContext.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> Update(T entity)
        {
            var result = false;
            _dbContext.Update(entity);
            result = await _dbContext.SaveChangesAsync() > 0;
            return result;
        }
    }

}
