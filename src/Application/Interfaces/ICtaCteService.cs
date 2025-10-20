using Application.Models;

namespace Application.Interfaces
{
    public interface ICtaCteService
    {
        Task<IEnumerable<CtaCteDto>> GetAllAsync();
        Task<CtaCteDto?> GetByIdAsync(int id);
        Task AddAsync(CtaCteDto ctaCteDto);
        Task UpdateAsync(CtaCteDto ctaCteDto);
        Task DeleteAsync(int id);
        Task<decimal> GetSaldoAsync(int id);
    }
}