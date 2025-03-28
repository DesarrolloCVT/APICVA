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
    public class IngresosDetalleController : ControllerBase
    {
        private readonly IIngresosDetalleService _ingresoDetalleService;
        private readonly ApplicationDbContext _context;

        public IngresosDetalleController(IIngresosDetalleService ingresoDetalleService, ApplicationDbContext applicationDbContext)
        {
            _ingresoDetalleService = ingresoDetalleService;
            _context = applicationDbContext;
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

        [HttpGet("GetIngreso")]
        public async Task<ActionResult<IngresosDetalle>> GetFilterIngresosDetalle([FromQuery] int idIngreso)
        {
            var detalles = await _context.IngresosDetalle
        .Where(d => d.Id_Ingreso == idIngreso) // Filtrar por la clave foránea
        .ToListAsync();

            if (!detalles.Any())
            {
                return NotFound("No se encontraron detalles para este ingreso.");
            }

            return Ok(detalles);
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
