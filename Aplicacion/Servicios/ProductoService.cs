using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Servicios
{
    public class ProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            return await _repository.ObtenerTodosAsync();
        }

        public async Task RegistrarProductoAsync(
            string nombre,
            string? descripcion,
            decimal precio,
            int stock)
        {
            var producto = new Producto(
                nombre,
                descripcion,
                precio,
                stock);

            await _repository.AgregarAsync(producto);
        }
    }
}