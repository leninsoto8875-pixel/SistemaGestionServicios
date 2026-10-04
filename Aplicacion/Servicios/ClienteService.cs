using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Servicios
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            return await _clienteRepository.ObtenerTodosAsync();
        }

        public async Task<Cliente?> ObtenerClienteAsync(int id)
        {
            return await _clienteRepository.ObtenerPorIdAsync(id);
        }

        public async Task RegistrarClienteAsync(
            string nombre,
            string telefono,
            string? correo,
            string? direccion)
        {
            // La entidad Cliente valida las reglas de negocio.
            var cliente = new Cliente(
                nombre,
                telefono,
                correo,
                direccion);

            await _clienteRepository.AgregarAsync(cliente);
        }

        public async Task ActualizarClienteAsync(
            int id,
            string nombre,
            string telefono,
            string? correo,
            string? direccion)
        {
            var cliente = await _clienteRepository.ObtenerPorIdAsync(id);

            if (cliente == null)
                throw new InvalidOperationException("El cliente no existe.");

            cliente.ActualizarDatos(
                nombre,
                telefono,
                correo,
                direccion);

            await _clienteRepository.ActualizarAsync(cliente);
        }
    }
}
