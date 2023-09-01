using AppBibliotecaBitwise3.DAL.DataContext;

namespace AppBibliotecaBitwise3.DAL.Interfaces
{
    public interface IGenericInterface<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetId(int id);

        Task<bool> Update(T entity);

        Task<bool> Delete(int id);

        Task<bool> Post(T entity);


    }
}
