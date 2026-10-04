namespace Dominio.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; private set; }

        public string Nombre { get; private set; }

        public string Telefono { get; private set; }

        public string? Correo { get; private set; }

        public string? Direccion { get; private set; }

        public Cliente(
            string nombre,
            string telefono,
            string? correo,
            string? direccion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El teléfono del cliente es obligatorio.");

            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
        }

        public void ActualizarDatos(
            string nombre,
            string telefono,
            string? correo,
            string? direccion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El teléfono del cliente es obligatorio.");

            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
        }
    }
}