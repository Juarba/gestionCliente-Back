using Application.Dtos;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> GetAllAsync();
        Task<ClienteDto?> GetByIdAsync(int id);
        Task AddAsync(ClienteDto clienteDto);
        Task UpdateAsync(ClienteDto clienteDto);
        Task DeleteAsync(int id);
    }
}
