using AppBibliotecaBitwise5.Models;

namespace AppBibliotecaBitwise5.DAL.Interface
{
    public interface ILibroRepository :  IGenericContract<Libro>
    {
        public Task<Libro> ObtenerPorIdConRelacion(int id);
    }
}
