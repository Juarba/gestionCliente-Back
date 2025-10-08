using Application.Models
    ;

using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Application.Dtos;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var clientes = await _repository.GetAllAsync();

            return clientes.Select(c => new ClienteDto
            {
                Id = c.Id,
                CUIT = c.CUIT,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Telefono = c.Telefono,
                Fecha = c.Fecha,
                Domicilio = c.Domicilio != null ? new DomicilioDto
                {
                    Id = c.Domicilio.Id,
                    Direccion = c.Domicilio.Direccion,
                    Ciudad = c.Domicilio.Ciudad,
                    CodPostal = c.Domicilio.CodPostal,
                    Provincia = c.Domicilio.Provincia
                } : null,
                CtaCte = c.CtaCte != null ? new CtaCteDto
                {
                    Id = c.CtaCte.Id,
                    Movimientos = c.CtaCte.Movimientos.Select(m => new MovimientoDto
                    {
                        Id = m.Id,
                        Fecha = m.Fecha,
                        Descripcion = m.Descripcion,
                        Debe = m.Debe,
                        Haber = m.Haber
                    }).ToList()
                } : null
            });
        }

        public async Task<ClienteDto?> GetByIdAsync(int id)
        {
            var c = await _repository.GetByIdAsync(id);
            if (c == null) return null;

            return new ClienteDto
            {
                Id = c.Id,
                CUIT = c.CUIT,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Telefono = c.Telefono,
                Fecha = c.Fecha,
                Domicilio = c.Domicilio != null ? new DomicilioDto
                {
                    Id = c.Domicilio.Id,
                    Direccion = c.Domicilio.Direccion,
                    Ciudad = c.Domicilio.Ciudad,
                    CodPostal = c.Domicilio.CodPostal,
                    Provincia = c.Domicilio.Provincia
                } : null,
                CtaCte = c.CtaCte != null ? new CtaCteDto
                {
                    Id = c.CtaCte.Id,
                    Movimientos = c.CtaCte.Movimientos.Select(m => new MovimientoDto
                    {
                        Id = m.Id,
                        Fecha = m.Fecha,
                        Descripcion = m.Descripcion,
                        Debe = m.Debe,
                        Haber = m.Haber
                    }).ToList()
                } : null
            };
        }

        public async Task AddAsync(ClienteDto dto)
        {
            var cliente = new Cliente
            {
                CUIT = dto.CUIT,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                Fecha = dto.Fecha,
                Domicilio = dto.Domicilio != null ? new Domicilio
                {
                    Direccion = dto.Domicilio.Direccion,
                    Ciudad = dto.Domicilio.Ciudad,
                    CodPostal = dto.Domicilio.CodPostal,
                    Provincia = dto.Domicilio.Provincia
                } : null,
                CtaCte = new CtaCte
                {
                    Movimientos = new List<Movimiento>()
                }
            };

            await _repository.AddAsync(cliente);
        }

        public async Task UpdateAsync(ClienteDto dto)
        {
            var cliente = new Cliente
            {
                Id = dto.Id,
                CUIT = dto.CUIT,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                Fecha = dto.Fecha,
                Domicilio = dto.Domicilio != null ? new Domicilio
                {
                    Id = dto.Domicilio.Id,
                    Direccion = dto.Domicilio.Direccion,
                    Ciudad = dto.Domicilio.Ciudad,
                    CodPostal = dto.Domicilio.CodPostal,
                    Provincia = dto.Domicilio.Provincia
                } : null,
                CtaCte = dto.CtaCte != null ? new CtaCte
                {
                    Id = dto.CtaCte.Id,
                    Movimientos = dto.CtaCte.Movimientos.Select(m => new Movimiento
                    {
                        Id = m.Id,
                        Fecha = m.Fecha,
                        Descripcion = m.Descripcion,
                        Debe = m.Debe,
                        Haber = m.Haber
                    }).ToList()
                } : null
            };

            await _repository.UpdateAsync(cliente);
        }

        public async Task DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}
