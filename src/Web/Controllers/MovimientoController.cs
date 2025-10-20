using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService _service;

        public MovimientoController(IMovimientoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movimiento = await _service.GetByIdAsync(id);
            if (movimiento == null) return NotFound();
            return Ok(movimiento);
        }

        [HttpGet("ctacte/{ctaCteId}")]
        public async Task<IActionResult> GetByCtaCteId(int ctaCteId)
            => Ok(await _service.GetByCtaCteIdAsync(ctaCteId));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MovimientoDto dto)
        {
            await _service.AddAsync(dto);
            return Ok("Movimiento creado correctamente");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MovimientoDto dto)
        {
            dto.Id = id;
            await _service.UpdateAsync(dto);
            return Ok("Movimiento actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Movimiento eliminado correctamente");
        }
    }
}