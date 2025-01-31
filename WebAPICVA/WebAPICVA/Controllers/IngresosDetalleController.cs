using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Services;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosDetalleController : ControllerBase
    {
        private readonly IIngresosDetalleService _ingresoDetalleService;

        public IngresosDetalleController(IIngresosDetalleService ingresoDetalleService)
        {
            _ingresoDetalleService = ingresoDetalleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngresosDetalle>>> GetIngresosDetalle() =>
            Ok(await _ingresoDetalleService.GetAllAsync());

        [HttpGet("{folio}")]
        public async Task<ActionResult<IngresosDetalle>> GetIngresosDetalle(int folio)
        {
            var ingresosDetalle = await _ingresoDetalleService.GetByIdAsync(folio);
            return ingresosDetalle == null ? NotFound() : Ok(ingresosDetalle);
        }

        [HttpPost]
        public async Task<IActionResult> PostIngresosDetalle(IngresosDetalleDTO ingresosDetalleDto)
        {
            await _ingresoDetalleService.AddAsync(ingresosDetalleDto);
            return CreatedAtAction(nameof(GetIngresosDetalle), new { folio = ingresosDetalleDto.Folio_FacturaVenta }, ingresosDetalleDto);
        }

        [HttpPut("{folio}")]
        public async Task<IActionResult> PutIngresosDetalle(int folio, IngresosDetalleDTO ingresosDetalleDto)
        {
            await _ingresoDetalleService.UpdateAsync(folio, ingresosDetalleDto);
            return NoContent();
        }

        [HttpDelete("{folio}")]
        public async Task<IActionResult> DeleteIngresosDetalle(int folio)
        {
            await _ingresoDetalleService.DeleteAsync(folio);
            return NoContent();
        }
    }
}
