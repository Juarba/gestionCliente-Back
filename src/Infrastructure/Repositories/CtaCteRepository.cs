using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CtaCteRepository : ICtaCteRepository
    {
        private readonly ApplicationDbContext _context;

        public CtaCteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CtaCte>> GetAllAsync()
            => await _context.CtaCtes
                .Include(c => c.Movimientos)
                .ToListAsync();

        public async Task<CtaCte?> GetByIdAsync(int id)
            => await _context.CtaCtes
                .Include(c => c.Movimientos)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task AddAsync(CtaCte ctaCte)
        {
            await _context.CtaCtes.AddAsync(ctaCte);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CtaCte ctaCte)
        {
            _context.CtaCtes.Update(ctaCte);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ctaCte = await GetByIdAsync(id);
            if (ctaCte != null)
            {
                _context.CtaCtes.Remove(ctaCte);
                await _context.SaveChangesAsync();
            }
        }
    }
}