using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> ObtenerTodosAsync();
        Task<Cliente?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Cliente cliente);
        Task ActualizarAsync(Cliente cliente);
    }
}