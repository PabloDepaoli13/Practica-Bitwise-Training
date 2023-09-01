namespace BibliotecaAPIBitwise1.DAL.Interfaces
{
    public interface IGenericRepository<E> where E : class 
    {
        Task<IEnumerable<E>> GetAll();

        Task<E> GetId(int id);

        Task<bool> Post(E entity);

        Task<bool> Update(E entity);

        Task<bool> Delete(int id);

       
    }
}
