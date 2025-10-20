using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICtaCteRepository
    {
        Task<IEnumerable<CtaCte>> GetAllAsync();
        Task<CtaCte?> GetByIdAsync(int id);
        Task AddAsync(CtaCte ctaCte);
        Task UpdateAsync(CtaCte ctaCte);
        Task DeleteAsync(int id);
    }
}