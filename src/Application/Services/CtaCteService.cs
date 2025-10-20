using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CtaCteService : ICtaCteService
    {
        private readonly ICtaCteRepository _repository;

        public CtaCteService(ICtaCteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CtaCteDto>> GetAllAsync()
        {
            var ctaCtes = await _repository.GetAllAsync();
            return ctaCtes.Select(c => new CtaCteDto
            {
                Id = c.Id,
                Movimientos = c.Movimientos?.Select(m => new MovimientoDto
                {
                    Id = m.Id,
                    Fecha = m.Fecha,
                    Descripcion = m.Descripcion,
                    Haber = m.Haber,
                    Debe = m.Debe
                }).ToList() ?? new List<MovimientoDto>()
            });
        }

        public async Task<CtaCteDto?> GetByIdAsync(int id)
        {
            var c = await _repository.GetByIdAsync(id);
            if (c == null) return null;

            return new CtaCteDto
            {
                Id = c.Id,
                Movimientos = c.Movimientos?.Select(m => new MovimientoDto
                {
                    Id = m.Id,
                    Fecha = m.Fecha,
                    Descripcion = m.Descripcion,
                    Haber = m.Haber,
                    Debe = m.Debe
                }).ToList() ?? new List<MovimientoDto>()
            };
        }

        public async Task AddAsync(CtaCteDto dto)
        {
            var ctaCte = new CtaCte
            {
                Movimientos = dto.Movimientos?.Select(m => new Movimiento
                {
                    Fecha = m.Fecha,
                    Descripcion = m.Descripcion,
                    Haber = m.Haber,
                    Debe = m.Debe
                }).ToList() ?? new List<Movimiento>()
            };

            await _repository.AddAsync(ctaCte);
        }

        public async Task UpdateAsync(CtaCteDto dto)
        {
            var ctaCte = new CtaCte
            {
                Id = dto.Id,
                Movimientos = dto.Movimientos?.Select(m => new Movimiento
                {
                    Id = m.Id,
                    Fecha = m.Fecha,
                    Descripcion = m.Descripcion,
                    Haber = m.Haber,
                    Debe = m.Debe
                }).ToList() ?? new List<Movimiento>()
            };

            await _repository.UpdateAsync(ctaCte);
        }

        public async Task DeleteAsync(int id)
            => await _repository.DeleteAsync(id);

        public async Task<decimal> GetSaldoAsync(int id)
        {
            var ctaCte = await _repository.GetByIdAsync(id);
            if (ctaCte == null) return 0;

            var totalHaber = ctaCte.Movimientos?.Sum(m => m.Haber) ?? 0;
            var totalDebe = ctaCte.Movimientos?.Sum(m => m.Debe) ?? 0;

            return totalHaber - totalDebe;
        }
    }
}