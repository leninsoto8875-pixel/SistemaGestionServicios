using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorios
{
    public class ReparacionRepository : IReparacionRepository
    {
        private readonly AppDbContext _context;

        public ReparacionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reparacion>> ObtenerTodasAsync()
        {
            return await _context.Reparaciones.ToListAsync();
        }

        public async Task<Reparacion?> ObtenerPorIdAsync(int id)
        {
            return await _context.Reparaciones
                .FirstOrDefaultAsync(r => r.IdReparacion == id);
        }

        public async Task AgregarAsync(Reparacion reparacion)
        {
            await _context.Reparaciones.AddAsync(reparacion);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Reparacion reparacion)
        {
            _context.Reparaciones.Update(reparacion);
            await _context.SaveChangesAsync();
        }
    }
}