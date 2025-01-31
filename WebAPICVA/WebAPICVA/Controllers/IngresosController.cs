using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Services;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        private readonly IIngresosService _ingresoService;

        public IngresosController(IIngresosService ingresoService)
        {
            _ingresoService = ingresoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingresos>>> GetIngresos() =>
            Ok(await _ingresoService.GetAllAsync());

        [HttpGet("{folio}")]
        public async Task<ActionResult<Ingresos>> GetIngresos(int folio)
        {
            var ingresos = await _ingresoService.GetByIdAsync(folio);
            return ingresos == null ? NotFound() : Ok(ingresos);
        }

        [HttpPost]
        public async Task<IActionResult> PostIngresos(IngresosDTO ingresosDto)
        {
            await _ingresoService.AddAsync(ingresosDto);
            return CreatedAtAction(nameof(GetIngresos), new { folio = ingresosDto.Folio }, ingresosDto);
        }

        [HttpPut("{folio}")]
        public async Task<IActionResult> PutIngresos(int folio, IngresosDTO ingresosDto)
        {
            await _ingresoService.UpdateAsync(folio, ingresosDto);
            return NoContent();
        }

        [HttpDelete("{folio}")]
        public async Task<IActionResult> DeleteIngresos(int folio)
        {
            await _ingresoService.DeleteAsync(folio);
            return NoContent();
        }
    }
}
