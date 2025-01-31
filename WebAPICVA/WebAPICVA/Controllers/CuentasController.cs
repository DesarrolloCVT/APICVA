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

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Cuentas>> GetCuentas(int codigo)
        {
            var cuentas = await _cuentasService.GetByIdAsync(codigo);
            return cuentas == null ? NotFound() : Ok(cuentas);
        }

        [HttpPost]
        public async Task<IActionResult> PostCuentas(CuentasDTO cuentasDto)
        {
            await _cuentasService.AddAsync(cuentasDto);
            return CreatedAtAction(nameof(GetCuentas), new { codigo = cuentasDto.Codigo }, cuentasDto);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutCuentas(int codigo, CuentasDTO cuentasDto)
        {
            await _cuentasService.UpdateAsync(codigo, cuentasDto);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteCuentas(int codigo)
        {
            await _cuentasService.DeleteAsync(codigo);
            return NoContent();
        }
    }
}
