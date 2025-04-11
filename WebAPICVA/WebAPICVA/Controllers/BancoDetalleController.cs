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
    public class BancoDetalleController : ControllerBase
    {
        private readonly IBancoDetalleService _bancoDetalleService;
        private readonly ApplicationDbContext _context;

        public BancoDetalleController(IBancoDetalleService bancoDetalleService, ApplicationDbContext applicationDbContext)
        {
            _bancoDetalleService = bancoDetalleService;
            _context = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BancoDetalle>>> GetBancoDetalle() =>
            Ok(await _bancoDetalleService.GetAllAsync());

        [HttpGet("{codigo_banco}")]
        public async Task<ActionResult<BancoDetalle>> GetBancoDetalle(int codigo)
        {
            var bancoDetalle = await _bancoDetalleService.GetByIdAsync(codigo);
            return bancoDetalle == null ? NotFound() : Ok(bancoDetalle);
        }

        [HttpGet("GetBancoDetalle")]
        public async Task<ActionResult<BancoDetalle>> GetFilterFactVentaDetalle([FromQuery] int idBanco)
        {
            var detalles = await _context.BancoDetalle
        .Where(d => d.Id_Banco == idBanco)
        .ToListAsync();

            if (!detalles.Any())
            {
                return NotFound("No se encontraron detalles para esta factura.");
            }

            return Ok(detalles);
        }

        [HttpPost]
        public async Task<IActionResult> PostBancoDetalle(BancoDetalleDTO bancoDetalleDto)
        {
            await _bancoDetalleService.AddAsync(bancoDetalleDto);
            return CreatedAtAction(nameof(GetBancoDetalle), new { id = bancoDetalleDto.Id_Banco_Detalle }, bancoDetalleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBancoDetalle(int id, BancoDetalleDTO bancoDetalleDto)
        {
            await _bancoDetalleService.UpdateAsync(id, bancoDetalleDto);
            return NoContent();
        }

        [HttpDelete("{codigo_banco}")]
        public async Task<IActionResult> DeleteBancoDetalle(int codigo_banco)
        {
            await _bancoDetalleService.DeleteAsync(codigo_banco);
            return NoContent();
        }
    }
}
