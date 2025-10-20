using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDomicilioRepository
    {
        Task<IEnumerable<Domicilio>> GetAllAsync();
        Task<Domicilio?> GetByIdAsync(int id);
        Task AddAsync(Domicilio domicilio);
        Task UpdateAsync(Domicilio domicilio);
        Task DeleteAsync(int id);
    }
}