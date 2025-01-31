using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Services;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaCompraController : ControllerBase
    {
        private readonly IFacturaCompraService _facturaCompraService;

        public FacturaCompraController(IFacturaCompraService facturaCompraService)
        {
            _facturaCompraService = facturaCompraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaCompra>>> GetFacturaCompra() =>
            Ok(await _facturaCompraService.GetAllAsync());

        [HttpGet("{folio}")]
        public async Task<ActionResult<FacturaCompra>> GetFacturaCompra(int folio)
        {
            var banco = await _facturaCompraService.GetByIdAsync(folio);
            return banco == null ? NotFound() : Ok(banco);
        }

        [HttpPost]
        public async Task<IActionResult> PostFacturaCompra(FacturaCompraDTO facturaCompraDto)
        {
            await _facturaCompraService.AddAsync(facturaCompraDto);
            return CreatedAtAction(nameof(GetFacturaCompra), new { folio = facturaCompraDto.Folio }, facturaCompraDto);
        }

        [HttpPut("{folio}")]
        public async Task<IActionResult> PutFacturaCompra(int folio, FacturaCompraDTO facturaCompraDto)
        {
            await _facturaCompraService.UpdateAsync(folio, facturaCompraDto);
            return NoContent();
        }

        [HttpDelete("{folio}")]
        public async Task<IActionResult> DeleteFacturaCompra(int folio)
        {
            await _facturaCompraService.DeleteAsync(folio);
            return NoContent();
        }
    }
}
