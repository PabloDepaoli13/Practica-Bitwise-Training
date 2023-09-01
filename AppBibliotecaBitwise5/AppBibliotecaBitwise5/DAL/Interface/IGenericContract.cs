namespace AppBibliotecaBitwise5.DAL.Interface
{
    public interface IGenericContract<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<bool> Delete(int id);

        Task<bool> Update(T entity);

        Task<bool> Post(T entity);
    }
}
