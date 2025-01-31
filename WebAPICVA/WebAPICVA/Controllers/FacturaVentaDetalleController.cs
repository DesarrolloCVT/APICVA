using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Services;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaVentaDetalleController : ControllerBase
    {
        private readonly IFacturaVentaDetalleService _facturaVentaDetalleService;

        public FacturaVentaDetalleController(IFacturaVentaDetalleService facturaVentaDetalleService)
        {
            _facturaVentaDetalleService = facturaVentaDetalleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaVentaDetalle>>> GetFacturaVentaDetalle() =>
            Ok(await _facturaVentaDetalleService.GetAllAsync());

        [HttpGet("{folio}")]
        public async Task<ActionResult<FacturaVentaDetalle>> GetFacturaVentaDetalle(int folio)
        {
            var facturaVenta = await _facturaVentaDetalleService.GetByIdAsync(folio);
            return facturaVenta == null ? NotFound() : Ok(facturaVenta);
        }

        [HttpPost]
        public async Task<IActionResult> PostFacturaVentaDetalle(FacturaVentaDetalleDTO facturaVentaDetalleDto)
        {
            await _facturaVentaDetalleService.AddAsync(facturaVentaDetalleDto);
            return CreatedAtAction(nameof(GetFacturaVentaDetalle), new { folio = facturaVentaDetalleDto.Folio }, facturaVentaDetalleDto);
        }

        [HttpPut("{folio}")]
        public async Task<IActionResult> PutFacturaVentaDetalle(int folio, FacturaVentaDetalleDTO facturaVentaDetalleDto)
        {
            await _facturaVentaDetalleService.UpdateAsync(folio, facturaVentaDetalleDto);
            return NoContent();
        }

        [HttpDelete("{folio}")]
        public async Task<IActionResult> DeleteFacturaVentaDetalle(int folio)
        {
            await _facturaVentaDetalleService.DeleteAsync(folio);
            return NoContent();
        }
    }
}
