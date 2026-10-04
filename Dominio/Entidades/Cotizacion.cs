namespace Dominio.Entidades
{
    public class Cotizacion
    {
        public int IdCotizacion { get; private set; }

        public int IdReparacion { get; private set; }

        public DateTime Fecha { get; private set; }

        public decimal ManoDeObra { get; private set; }

        public decimal Repuestos { get; private set; }

        public decimal Total
        {
            get
            {
                return ManoDeObra + Repuestos;
            }
        }

        public Cotizacion(
            int idReparacion,
            decimal manoDeObra,
            decimal repuestos)
        {
            if (idReparacion <= 0)
                throw new ArgumentException("La reparación no es válida.");

            if (manoDeObra < 0)
                throw new ArgumentException(
                    "La mano de obra no puede ser negativa.");

            if (repuestos < 0)
                throw new ArgumentException(
                    "El costo de repuestos no puede ser negativo.");

            IdReparacion = idReparacion;
            ManoDeObra = manoDeObra;
            Repuestos = repuestos;
            Fecha = DateTime.Now;
        }
    }
}