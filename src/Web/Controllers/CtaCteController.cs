using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CtaCteController : ControllerBase
    {
        private readonly ICtaCteService _service;

        public CtaCteController(ICtaCteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ctaCte = await _service.GetByIdAsync(id);
            if (ctaCte == null) return NotFound();
            return Ok(ctaCte);
        }

        [HttpGet("{id}/saldo")]
        public async Task<IActionResult> GetSaldo(int id)
        {
            var saldo = await _service.GetSaldoAsync(id);
            return Ok(new { Saldo = saldo });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CtaCteDto dto)
        {
            await _service.AddAsync(dto);
            return Ok("Cuenta corriente creada correctamente");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CtaCteDto dto)
        {
            dto.Id = id;
            await _service.UpdateAsync(dto);
            return Ok("Cuenta corriente actualizada correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Cuenta corriente eliminada correctamente");
        }
    }
}