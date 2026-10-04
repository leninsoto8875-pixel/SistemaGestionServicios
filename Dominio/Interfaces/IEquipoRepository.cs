using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IEquipoRepository
    {
        Task<List<Equipo>> ObtenerTodosAsync();
        Task<Equipo?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Equipo equipo);
    }
}
