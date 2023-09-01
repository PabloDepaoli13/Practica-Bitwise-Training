namespace AppBibliotecaBitwise8.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> CreateAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);
    }
}
