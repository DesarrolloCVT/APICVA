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

        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaCompra>> GetFacturaCompraDetalle(int id)
        {
            var facturaCompraDetalle = await _facturaCompraDetalleService.GetByIdAsync(id);
            return facturaCompraDetalle == null ? NotFound() : Ok(facturaCompraDetalle);
        }

        [HttpPost]
        public async Task<IActionResult> PostFacturaCompraDetalle(FacturaCompraDetalleDTO facturaCompraDetalleDto)
        {
            await _facturaCompraDetalleService.AddAsync(facturaCompraDetalleDto);
            return CreatedAtAction(nameof(GetFacturaCompraDetalle), new { folio = facturaCompraDetalleDto.Folio }, facturaCompraDetalleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaCompraDetalle(int id, FacturaCompraDetalle facturaCompraDetalleDto)
        {
            await _facturaCompraDetalleService.UpdateAsync(id, facturaCompraDetalleDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaCompraDetalle(int id)
        {
            await _facturaCompraDetalleService.DeleteAsync(id);
            return NoContent();
        }
    }
}
