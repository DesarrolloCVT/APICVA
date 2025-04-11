using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaVenta>> GetFacturaVenta(int id)
        {
            var facturaVenta = await _facturaVentaService.GetByIdAsync(id);
            return facturaVenta == null ? NotFound() : Ok(facturaVenta);
        }

        [HttpPost]
        public async Task<IActionResult> PostFacturaVenta(FacturaVentaDTO facturaVentaDto)
        {
            await _facturaVentaService.AddAsync(facturaVentaDto);
            return CreatedAtAction(nameof(GetFacturaVenta), new { id = facturaVentaDto.Id_Factura_Venta }, facturaVentaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaVenta(int id, FacturaVentaDTO facturaVentaDto)
        {
            await _facturaVentaService.UpdateAsync(id, facturaVentaDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaVenta(int id)
        {
            await _facturaVentaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
