using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Services;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaCompraDetalleController : ControllerBase
    {
        private readonly IFacturaCompraDetalleService _facturaCompraDetalleService;

        public FacturaCompraDetalleController(IFacturaCompraDetalleService facturaCompraDetalleService)
        {
            _facturaCompraDetalleService = facturaCompraDetalleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaCompra>>> GetFacturaCompraDetalle() =>
            Ok(await _facturaCompraDetalleService.GetAllAsync());

        [HttpGet("{folio}")]
        public async Task<ActionResult<FacturaCompra>> GetFacturaCompraDetalle(int folio)
        {
            var banco = await _facturaCompraDetalleService.GetByIdAsync(folio);
            return banco == null ? NotFound() : Ok(banco);
        }

        [HttpPost]
        public async Task<IActionResult> PostFacturaCompraDetalle(FacturaCompraDetalleDTO facturaCompraDetalleDto)
        {
            await _facturaCompraDetalleService.AddAsync(facturaCompraDetalleDto);
            return CreatedAtAction(nameof(GetFacturaCompraDetalle), new { folio = facturaCompraDetalleDto.Folio }, facturaCompraDetalleDto);
        }

        [HttpPut("{folio}")]
        public async Task<IActionResult> PutFacturaCompraDetalle(int folio, FacturaCompraDetalleDTO facturaCompraDetalleDto)
        {
            await _facturaCompraDetalleService.UpdateAsync(folio, facturaCompraDetalleDto);
            return NoContent();
        }

        [HttpDelete("{folio}")]
        public async Task<IActionResult> DeleteFacturaCompraDetalle(int folio)
        {
            await _facturaCompraDetalleService.DeleteAsync(folio);
            return NoContent();
        }
    }
}
