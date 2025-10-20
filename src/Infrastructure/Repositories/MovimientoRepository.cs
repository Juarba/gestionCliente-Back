using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly ApplicationDbContext _context;

        public MovimientoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movimiento>> GetAllAsync()
            => await _context.Movimientos.ToListAsync();

        public async Task<Movimiento?> GetByIdAsync(int id)
            => await _context.Movimientos.FirstOrDefaultAsync(m => m.Id == id);

        public async Task<IEnumerable<Movimiento>> GetByCtaCteIdAsync(int ctaCteId)
            => await _context.Movimientos
                .Where(m => m.CtaCteId == ctaCteId)
                .OrderByDescending(m => m.Fecha)
                .ToListAsync();

        public async Task AddAsync(Movimiento movimiento)
        {
            await _context.Movimientos.AddAsync(movimiento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movimiento movimiento)
        {
            _context.Movimientos.Update(movimiento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movimiento = await GetByIdAsync(id);
            if (movimiento != null)
            {
                _context.Movimientos.Remove(movimiento);
                await _context.SaveChangesAsync();
            }
        }
    }
}