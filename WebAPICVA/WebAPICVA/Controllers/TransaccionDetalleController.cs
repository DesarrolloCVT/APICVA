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
    public class TransaccionDetalleController : ControllerBase
    {
        private readonly ITransaccionDetalleService _transaccionDetalleService;
        private readonly ApplicationDbContext _context;

        public TransaccionDetalleController(ITransaccionDetalleService transaccionDetalleService, ApplicationDbContext applicationDbContext)
        {
            _transaccionDetalleService = transaccionDetalleService;
            _context = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransaccionDetalle>>> GetTransaccionDetalle() =>
            Ok(await _transaccionDetalleService.GetAllAsync());

        [HttpGet("{id_transaccion_detalle}")]
        public async Task<ActionResult<TransaccionDetalle>> GetTransaccionesDetalle(int id_transaccion_detalle)
        {
            var transaccionDetalle = await _transaccionDetalleService.GetByIdAsync(id_transaccion_detalle);
            return transaccionDetalle == null ? NotFound() : Ok(transaccionDetalle);
        }

        [HttpGet("GetTransaccion")]
        public async Task<ActionResult<TransaccionDetalle>> GetFilterTransaccionDetalle([FromQuery] int idTransaccion)
        {
            var detalles = await _context.TransaccionDetalle
        .Where(d => d.Id_Transaccion == idTransaccion) // Filtrar por la clave foránea
        .ToListAsync();

            if (!detalles.Any())
            {
                return NotFound("No se encontraron detalles para este ingreso.");
            }

            return Ok(detalles);
        }

        [HttpPost]
        public async Task<IActionResult> PostTransaccionDetalle(TransaccionDetalleDTO transaccionDetalleDto)
        {
            await _transaccionDetalleService.AddAsync(transaccionDetalleDto);
            return CreatedAtAction(nameof(GetTransaccionDetalle), new { folio = transaccionDetalleDto.Folio_Factura }, transaccionDetalleDto);
        }

        [HttpPut("{folio}")]
        public async Task<IActionResult> PutTransaccionDetalle(int folio, TransaccionDetalleDTO transaccionDetalleDto)
        {
            await _transaccionDetalleService.UpdateAsync(folio, transaccionDetalleDto);
            return NoContent();
        }

        [HttpDelete("{id_transaccion_detalle}")]
        public async Task<IActionResult> DeleteTransaccionDetalle(int id_transaccion_detalle)
        {
            await _transaccionDetalleService.DeleteAsync(id_transaccion_detalle);
            return NoContent();
        }
    }
}
