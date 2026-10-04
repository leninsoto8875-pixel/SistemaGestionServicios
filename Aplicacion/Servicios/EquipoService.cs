using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Servicios
{
    public class EquipoService
    {
        private readonly IEquipoRepository _equipoRepository;

        public EquipoService(IEquipoRepository equipoRepository)
        {
            _equipoRepository = equipoRepository;
        }

        public async Task<List<Equipo>> ObtenerEquiposAsync()
        {
            return await _equipoRepository.ObtenerTodosAsync();
        }

        public async Task RegistrarEquipoAsync(
            int idCliente,
            string tipo,
            string marca,
            string? modelo,
            string? numeroSerie,
            string? descripcion)
        {
            var equipo = new Equipo(
                idCliente,
                tipo,
                marca,
                modelo,
                numeroSerie,
                descripcion);

            await _equipoRepository.AgregarAsync(equipo);
        }
    }
}