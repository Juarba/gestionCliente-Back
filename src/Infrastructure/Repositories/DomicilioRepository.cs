using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DomicilioRepository : IDomicilioRepository
    {
        private readonly ApplicationDbContext _context;

        public DomicilioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domicilio>> GetAllAsync()
            => await _context.Domicilios.ToListAsync();

        public async Task<Domicilio?> GetByIdAsync(int id)
            => await _context.Domicilios.FirstOrDefaultAsync(d => d.Id == id);

        public async Task AddAsync(Domicilio domicilio)
        {
            await _context.Domicilios.AddAsync(domicilio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domicilio domicilio)
        {
            _context.Domicilios.Update(domicilio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var domicilio = await GetByIdAsync(id);
            if (domicilio != null)
            {
                _context.Domicilios.Remove(domicilio);
                await _context.SaveChangesAsync();
            }
        }
    }
}