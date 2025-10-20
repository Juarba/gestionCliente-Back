using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMovimientoRepository
    {
        Task<IEnumerable<Movimiento>> GetAllAsync();
        Task<Movimiento?> GetByIdAsync(int id);
        Task<IEnumerable<Movimiento>> GetByCtaCteIdAsync(int ctaCteId);
        Task AddAsync(Movimiento movimiento);
        Task UpdateAsync(Movimiento movimiento);
        Task DeleteAsync(int id);
    }
}