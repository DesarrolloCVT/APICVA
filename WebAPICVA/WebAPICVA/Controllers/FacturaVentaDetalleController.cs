using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
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
        private readonly ApplicationDbContext _context;

        public FacturaVentaDetalleController(IFacturaVentaDetalleService facturaVentaDetalleService, ApplicationDbContext dbContext)
        {
            _facturaVentaDetalleService = facturaVentaDetalleService;
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaVentaDetalle>>> GetFacturaVentaDetalle() =>
            Ok(await _facturaVentaDetalleService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaVentaDetalle>> GetFacturaVentaDetalle(int id)
        {
            var facturaVentaDetalle = await _facturaVentaDetalleService.GetByIdAsync(id);
            return facturaVentaDetalle == null ? NotFound() : Ok(facturaVentaDetalle);
        }

        [HttpGet("GetFacturaVentaDetalle")]
        public async Task<ActionResult<FacturaVentaDetalle>> GetFilterFactVentaDetalle([FromQuery] int idFactVenta)
        {
            var detalles = await _context.FacturaVentaDetalle
        .Where(d => d.Id_Factura_Venta == idFactVenta)
        .ToListAsync();

            if (!detalles.Any())
            {
                return NotFound("No se encontraron detalles para esta factura.");
            }

            return Ok(detalles);
        }

        [HttpPost]
        public async Task<IActionResult> PostFacturaVentaDetalle(FacturaVentaDetalleDTO facturaVentaDetalleDto)
        {
            await _facturaVentaDetalleService.AddAsync(facturaVentaDetalleDto);
            return CreatedAtAction(nameof(GetFacturaVentaDetalle), new { folio = facturaVentaDetalleDto.Folio }, facturaVentaDetalleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaVentaDetalle(int id, FacturaVentaDetalleDTO facturaVentaDetalleDto)
        {
            await _facturaVentaDetalleService.UpdateAsync(id, facturaVentaDetalleDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaVentaDetalle(int id)
        {
            await _facturaVentaDetalleService.DeleteAsync(id);
            return NoContent();
        }
    }
}
