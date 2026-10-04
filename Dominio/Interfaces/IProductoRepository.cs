using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<Producto>> ObtenerTodosAsync();
        Task<Producto?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Producto producto);
        Task ActualizarAsync(Producto producto);
    }
}