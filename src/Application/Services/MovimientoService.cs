using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository _repository;

        public MovimientoService(IMovimientoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MovimientoDto>> GetAllAsync()
        {
            var movimientos = await _repository.GetAllAsync();
            return movimientos.Select(m => new MovimientoDto
            {
                Id = m.Id,
                Fecha = m.Fecha,
                Descripcion = m.Descripcion,
                Haber = m.Haber,
                Debe = m.Debe
            });
        }

        public async Task<MovimientoDto?> GetByIdAsync(int id)
        {
            var m = await _repository.GetByIdAsync(id);
            if (m == null) return null;

            return new MovimientoDto
            {
                Id = m.Id,
                Fecha = m.Fecha,
                Descripcion = m.Descripcion,
                Haber = m.Haber,
                Debe = m.Debe
            };
        }

        public async Task<IEnumerable<MovimientoDto>> GetByCtaCteIdAsync(int ctaCteId)
        {
            var movimientos = await _repository.GetByCtaCteIdAsync(ctaCteId);
            return movimientos.Select(m => new MovimientoDto
            {
                Id = m.Id,
                Fecha = m.Fecha,
                Descripcion = m.Descripcion,
                Haber = m.Haber,
                Debe = m.Debe
            });
        }

        public async Task AddAsync(MovimientoDto dto)
        {
            var movimiento = new Movimiento
            {
                Fecha = dto.Fecha,
                Descripcion = dto.Descripcion,
                Haber = dto.Haber,
                Debe = dto.Debe
            };

            await _repository.AddAsync(movimiento);
        }

        public async Task UpdateAsync(MovimientoDto dto)
        {
            var movimiento = new Movimiento
            {
                Id = dto.Id,
                Fecha = dto.Fecha,
                Descripcion = dto.Descripcion,
                Haber = dto.Haber,
                Debe = dto.Debe
            };

            await _repository.UpdateAsync(movimiento);
        }

        public async Task DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}