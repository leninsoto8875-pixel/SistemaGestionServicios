using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Servicios
{
    public class ReparacionService
    {
        private readonly IReparacionRepository _repository;

        public ReparacionService(IReparacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Reparacion>> ObtenerReparacionesAsync()
        {
            return await _repository.ObtenerTodasAsync();
        }

        public async Task RegistrarReparacionAsync(int idEquipo, string problema)
        {
            var reparacion = new Reparacion(idEquipo, problema);
            await _repository.AgregarAsync(reparacion);
        }

        public async Task CambiarEstadoAsync(int id, string estado)
        {
            var reparacion = await _repository.ObtenerPorIdAsync(id);

            if (reparacion == null)
                throw new InvalidOperationException("La reparación no existe.");

            reparacion.ActualizarEstado(estado);
            await _repository.ActualizarAsync(reparacion);
        }
    }
}