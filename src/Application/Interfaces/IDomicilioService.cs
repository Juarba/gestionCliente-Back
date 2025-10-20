using Application.Models;

namespace Application.Interfaces
{
    public interface IDomicilioService
    {
        Task<IEnumerable<DomicilioDto>> GetAllAsync();
        Task<DomicilioDto?> GetByIdAsync(int id);
        Task AddAsync(DomicilioDto domicilioDto);
        Task UpdateAsync(DomicilioDto domicilioDto);
        Task DeleteAsync(int id);
    }
}