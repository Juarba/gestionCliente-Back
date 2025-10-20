using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class DomicilioService : IDomicilioService
    {
        private readonly IDomicilioRepository _repository;

        public DomicilioService(IDomicilioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DomicilioDto>> GetAllAsync()
        {
            var domicilios = await _repository.GetAllAsync();
            return domicilios.Select(d => new DomicilioDto
            {
                Id = d.Id,
                Direccion = d.Direccion,
                Ciudad = d.Ciudad,
                CodPostal = d.CodPostal,
                Provincia = d.Provincia
            });
        }

        public async Task<DomicilioDto?> GetByIdAsync(int id)
        {
            var d = await _repository.GetByIdAsync(id);
            if (d == null) return null;

            return new DomicilioDto
            {
                Id = d.Id,
                Direccion = d.Direccion,
                Ciudad = d.Ciudad,
                CodPostal = d.CodPostal,
                Provincia = d.Provincia
            };
        }

        public async Task AddAsync(DomicilioDto dto)
        {
            var domicilio = new Domicilio
            {
                Direccion = dto.Direccion,
                Ciudad = dto.Ciudad,
                CodPostal = dto.CodPostal,
                Provincia = dto.Provincia
            };

            await _repository.AddAsync(domicilio);
        }

        public async Task UpdateAsync(DomicilioDto dto)
        {
            var domicilio = new Domicilio
            {
                Id = dto.Id,
                Direccion = dto.Direccion,
                Ciudad = dto.Ciudad,
                CodPostal = dto.CodPostal,
                Provincia = dto.Provincia
            };

            await _repository.UpdateAsync(domicilio);
        }

        public async Task DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}