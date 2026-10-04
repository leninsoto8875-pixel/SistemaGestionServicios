namespace Dominio.Entidades
{
    public class Reparacion
    {
        public int IdReparacion { get; private set; }

        public int IdEquipo { get; private set; }

        public DateTime FechaIngreso { get; private set; }

        public DateTime? FechaEntrega { get; private set; }

        public string ProblemaReportado { get; private set; }

        public string? Diagnostico { get; private set; }

        public string? ActividadesRealizadas { get; private set; }

        public string Estado { get; private set; }

        public Reparacion(
            int idEquipo,
            string problemaReportado)
        {
            if (idEquipo <= 0)
                throw new ArgumentException("El equipo no es válido.");

            if (string.IsNullOrWhiteSpace(problemaReportado))
                throw new ArgumentException("El problema reportado es obligatorio.");

            IdEquipo = idEquipo;
            ProblemaReportado = problemaReportado;
            FechaIngreso = DateTime.Now;
            Estado = "Recibido";
        }

        public void RegistrarDiagnostico(string diagnostico)
        {
            if (string.IsNullOrWhiteSpace(diagnostico))
                throw new ArgumentException("El diagnóstico es obligatorio.");

            Diagnostico = diagnostico;
            Estado = "En reparacion";
        }

        public void ActualizarEstado(string nuevoEstado)
        {
            string[] estadosPermitidos =
            {
                "Recibido",
                "En diagnostico",
                "En reparacion",
                "Listo",
                "Entregado"
            };

            if (!estadosPermitidos.Contains(nuevoEstado))
                throw new ArgumentException("El estado indicado no es válido.");

            Estado = nuevoEstado;

            if (nuevoEstado == "Entregado")
                FechaEntrega = DateTime.Now;
        }
    }
}