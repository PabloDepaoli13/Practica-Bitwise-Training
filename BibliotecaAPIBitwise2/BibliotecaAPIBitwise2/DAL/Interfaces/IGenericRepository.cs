namespace BibliotecaAPIBitwise2.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetById(int id);

        Task<bool> Delete(int id);

        Task<bool> Update(T entity);

        Task<bool> Enviar(T entity);
        
    }
}
