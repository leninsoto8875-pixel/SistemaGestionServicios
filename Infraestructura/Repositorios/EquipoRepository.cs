using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorios
{
    public class EquipoRepository : IEquipoRepository
    {
        private readonly AppDbContext _context;

        public EquipoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Equipo>> ObtenerTodosAsync()
        {
            return await _context.Equipos.ToListAsync();
        }

        public async Task<Equipo?> ObtenerPorIdAsync(int id)
        {
            return await _context.Equipos
                .FirstOrDefaultAsync(e => e.IdEquipo == id);
        }

        public async Task AgregarAsync(Equipo equipo)
        {
            await _context.Equipos.AddAsync(equipo);
            await _context.SaveChangesAsync();
        }
    }
}