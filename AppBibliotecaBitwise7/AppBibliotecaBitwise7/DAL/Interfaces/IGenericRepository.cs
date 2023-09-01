namespace AppBibliotecaBitwise7.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<bool> PostAsync(T entity);

        public Task<IEnumerable<T>> GetAll();

        public Task<T> GetId(int id);

        public Task<bool> Delete(int id);

        public Task<bool> Update(T entity);
    }
}
