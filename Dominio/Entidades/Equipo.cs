namespace Dominio.Entidades
{
    public class Equipo
    {
        public int IdEquipo { get; private set; }

        public int IdCliente { get; private set; }

        public string Tipo { get; private set; }

        public string Marca { get; private set; }

        public string? Modelo { get; private set; }

        public string? NumeroSerie { get; private set; }

        public string? Descripcion { get; private set; }

        public Equipo(
            int idCliente,
            string tipo,
            string marca,
            string? modelo,
            string? numeroSerie,
            string? descripcion)
        {
            if (idCliente <= 0)
                throw new ArgumentException("El cliente no es válido.");

            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("El tipo de equipo es obligatorio.");

            if (string.IsNullOrWhiteSpace(marca))
                throw new ArgumentException("La marca del equipo es obligatoria.");

            IdCliente = idCliente;
            Tipo = tipo;
            Marca = marca;
            Modelo = modelo;
            NumeroSerie = numeroSerie;
            Descripcion = descripcion;
        }
    }
}