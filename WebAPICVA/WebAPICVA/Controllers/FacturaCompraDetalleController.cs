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
    public class FacturaCompraDetalleController : ControllerBase
    {
        private readonly IFacturaCompraDetalleService _facturaCompraDetalleService;
        private readonly ApplicationDbContext _context;

        public FacturaCompraDetalleController(IFacturaCompraDetalleService facturaCompraDetalleService, ApplicationDbContext dbContext)
        {
            _facturaCompraDetalleService = facturaCompraDetalleService;
            _context = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaCompraDetalle>>> GetFacturaCompraDetalle() =>
            Ok(await _facturaCompraDetalleService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaCompraDetalle>> GetFacturaCompraDetalle(int id)
        {
            var facturaCompraDetalle = await _facturaCompraDetalleService.GetByIdAsync(id);
            return facturaCompraDetalle == null ? NotFound() : Ok(facturaCompraDetalle);
        }

        [HttpGet("GetFacturaCompraDetalle")]
        public async Task<ActionResult<FacturaCompraDetalle>> GetFilterFactCompraDetalle([FromQuery] int idFactCompra)
        {
            var detalles = await _context.FacturaCompraDetalle
        .Where(d => d.Id_Factura_Compra == idFactCompra)
        .ToListAsync();

            if (!detalles.Any())
            {
                return NotFound("No se encontraron detalles para esta factura.");
            }

            return Ok(detalles);
        }

        [HttpPost]
        public async Task<IActionResult> PostFacturaCompraDetalle(FacturaCompraDetalleDTO facturaCompraDetalleDto)
        {
            await _facturaCompraDetalleService.AddAsync(facturaCompraDetalleDto);
            return CreatedAtAction(nameof(GetFacturaCompraDetalle), new { folio = facturaCompraDetalleDto.Folio }, facturaCompraDetalleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaCompraDetalle(int id, FacturaCompraDetalleDTO facturaCompraDetalleDto)
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
