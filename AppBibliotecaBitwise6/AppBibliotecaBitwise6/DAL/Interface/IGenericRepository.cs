namespace AppBibliotecaBitwise6.DAL.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<bool> Subir(T entity);

        public Task<bool> Borrar(int id);

        public Task<bool> Actualizar(T entity);

        public Task<T> ObtenerId (int id);

        public Task<IEnumerable<T>> ObtenerTodos();
    }
}
