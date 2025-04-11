using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Services;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentasService _cuentasService;

        public CuentasController(ICuentasService cuentasService)
        {
            _cuentasService = cuentasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuentas>>> GetCuentas() =>
            Ok(await _cuentasService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Cuentas>> GetCuentas(int id)
        {
            var cuentas = await _cuentasService.GetByIdAsync(id);
            return cuentas == null ? NotFound() : Ok(cuentas);
        }

        [HttpPost]
        public async Task<IActionResult> PostCuentas(CuentasDTO cuentasDto)
        {
            await _cuentasService.AddAsync(cuentasDto);
            return CreatedAtAction(nameof(GetCuentas), new { id = cuentasDto.Id_Cuenta }, cuentasDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuentas(int id, CuentasDTO cuentasDto)
        {
            await _cuentasService.UpdateAsync(id, cuentasDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuentas(int id)
        {
            await _cuentasService.DeleteAsync(id);
            return NoContent();
        }
    }
}
