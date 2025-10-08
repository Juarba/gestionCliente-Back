using Domain.Entities;
using Infrastructure.Data;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🔹 Obtener todos los clientes con su domicilio y cuenta corriente completa
        public async Task<IEnumerable<Cliente>> GetAllAsync()
            => await _context.Clientes
                .Include(c => c.Domicilio)
                .Include(c => c.CtaCte)
                    .ThenInclude(cta => cta.Movimientos)
                .ToListAsync();

        // 🔹 Obtener un cliente por Id con sus relaciones
        public async Task<Cliente?> GetByIdAsync(int id)
            => await _context.Clientes
                .Include(c => c.Domicilio)
                .Include(c => c.CtaCte)
                    .ThenInclude(cta => cta.Movimientos)
                .FirstOrDefaultAsync(c => c.Id == id);

        // 🔹 Agregar nuevo cliente
        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        // 🔹 Actualizar cliente existente
        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        // 🔹 Eliminar cliente
        public async Task DeleteAsync(int id)
        {
            var cliente = await GetByIdAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
