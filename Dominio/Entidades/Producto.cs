namespace Dominio.Entidades
{
    public class Producto
    {
        public int IdProducto { get; private set; }

        public string Nombre { get; private set; }

        public string? Descripcion { get; private set; }

        public decimal Precio { get; private set; }

        public int Stock { get; private set; }

        public Producto(
            string nombre,
            string? descripcion,
            decimal precio,
            int stock)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del producto es obligatorio.");

            if (precio <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero.");

            if (stock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");

            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
        }

        public void ActualizarPrecio(decimal nuevoPrecio)
        {
            if (nuevoPrecio <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero.");

            Precio = nuevoPrecio;
        }

        public void AgregarStock(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");

            Stock += cantidad;
        }

        public void ReducirStock(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");

            if (cantidad > Stock)
                throw new InvalidOperationException(
                    "No hay suficiente stock disponible.");

            Stock -= cantidad;
        }
    }
}
