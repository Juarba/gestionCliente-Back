using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovimientoService
    {
        Task<IEnumerable<MovimientoDto>> GetAllAsync();
        Task<MovimientoDto?> GetByIdAsync(int id);
        Task<IEnumerable<MovimientoDto>> GetByCtaCteIdAsync(int ctaCteId);
        Task AddAsync(MovimientoDto movimientoDto);
        Task UpdateAsync(MovimientoDto movimientoDto);
        Task DeleteAsync(int id);
    }
}
