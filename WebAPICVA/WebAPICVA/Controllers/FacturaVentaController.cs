using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Services;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaVentaController : ControllerBase
    {
        private readonly IFacturaVentaService _facturaVentaService;

        public FacturaVentaController(IFacturaVentaService facturaVentaService)
        {
            _facturaVentaService = facturaVentaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaVenta>>> GetFacturaVenta() =>
            Ok(await _facturaVentaService.GetAllAsync());

        [HttpGet("{folio}")]
        public async Task<ActionResult<FacturaVenta>> GetFacturaVenta(int folio)
        {
            var facturaVenta = await _facturaVentaService.GetByIdAsync(folio);
            return facturaVenta == null ? NotFound() : Ok(facturaVenta);
        }

        [HttpPost]
        public async Task<IActionResult> PostFacturaVenta(FacturaVentaDTO facturaVentaDto)
        {
            await _facturaVentaService.AddAsync(facturaVentaDto);
            return CreatedAtAction(nameof(GetFacturaVenta), new { folio = facturaVentaDto.Folio }, facturaVentaDto);
        }

        [HttpPut("{folio}")]
        public async Task<IActionResult> PutFacturaVenta(int folio, FacturaVentaDTO facturaVentaDto)
        {
            await _facturaVentaService.UpdateAsync(folio, facturaVentaDto);
            return NoContent();
        }

        [HttpDelete("{folio}")]
        public async Task<IActionResult> DeleteFacturaVenta(int folio)
        {
            await _facturaVentaService.DeleteAsync(folio);
            return NoContent();
        }
    }
}
