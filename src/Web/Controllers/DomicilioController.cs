using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DomicilioController : ControllerBase
    {
        private readonly IDomicilioService _service;

        public DomicilioController(IDomicilioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var domicilio = await _service.GetByIdAsync(id);
            if (domicilio == null) return NotFound();
            return Ok(domicilio);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DomicilioDto dto)
        {
            await _service.AddAsync(dto);
            return Ok("Domicilio creado correctamente");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DomicilioDto dto)
        {
            dto.Id = id;
            await _service.UpdateAsync(dto);
            return Ok("Domicilio actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Domicilio eliminado correctamente");
        }
    }
}