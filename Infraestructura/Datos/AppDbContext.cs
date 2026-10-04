using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Reparacion> Reparaciones { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cotizacion> Cotizaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CLIENTES
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes");
                entity.HasKey(e => e.IdCliente);
            });

            // EQUIPOS
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.ToTable("Equipos");
                entity.HasKey(e => e.IdEquipo);
            });

            // REPARACIONES
            modelBuilder.Entity<Reparacion>(entity =>
            {
                entity.ToTable("Reparaciones");
                entity.HasKey(e => e.IdReparacion);
            });

            // PRODUCTOS
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos");
                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.Precio)
                    .HasPrecision(10, 2);
            });

            // COTIZACIONES
            modelBuilder.Entity<Cotizacion>(entity =>
            {
                entity.ToTable("Cotizaciones");
                entity.HasKey(e => e.IdCotizacion);

                entity.Property(e => e.ManoDeObra)
                    .HasPrecision(10, 2);

                entity.Property(e => e.Repuestos)
                    .HasPrecision(10, 2);

                // Total lo calcula SQL Server
                entity.Ignore(e => e.Total);
            });
        }
    }
}