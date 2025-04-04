using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Services;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
        private readonly ITransaccionesService _transaccionesService;

        public TransaccionesController(ITransaccionesService transaccionesService)
        {
            _transaccionesService = transaccionesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transacciones>>> GetTransacciones() =>
            Ok(await _transaccionesService.GetAllAsync());

        [HttpGet("{id_transaccion}")]
        public async Task<ActionResult<Transacciones>> GetTransacciones(int id_transaccion)
        {
            var transaccion = await _transaccionesService.GetByIdAsync(id_transaccion);
            return transaccion == null ? NotFound() : Ok(transaccion);
        }

        [HttpPost]
        public async Task<IActionResult> PostTransacciones(TransaccionesDTO transaccionesDto)
        {
            await _transaccionesService.AddAsync(transaccionesDto);
            return CreatedAtAction(nameof(GetTransacciones), new { folio = transaccionesDto.Folio }, transaccionesDto);
        }

        [HttpPut("{id_transaccion}")]
        public async Task<IActionResult> PutTransacciones(int id_transaccion, TransaccionesDTO transaccionesDto)
        {
            await _transaccionesService.UpdateAsync(id_transaccion, transaccionesDto);
            return NoContent();
        }

        [HttpDelete("{id_transaccion}")]
        public async Task<IActionResult> DeleteTransacciones(int id_transaccion)
        {
            await _transaccionesService.DeleteAsync(id_transaccion);
            return NoContent();
        }
    }
}
