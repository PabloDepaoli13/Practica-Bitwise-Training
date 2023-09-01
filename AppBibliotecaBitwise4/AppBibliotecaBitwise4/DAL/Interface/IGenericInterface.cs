namespace AppBibliotecaBitwise4.DAL.Interface
{
    public interface IGenericInterface<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        Task<bool> Post(T entity);

        Task<bool> Put(T entity);

        Task<bool> Delete(int id);
    }
}
