using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IReparacionRepository
    {
        Task<List<Reparacion>> ObtenerTodasAsync();
        Task<Reparacion?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Reparacion reparacion);
        Task ActualizarAsync(Reparacion reparacion);
    }
}
