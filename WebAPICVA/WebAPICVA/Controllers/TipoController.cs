using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Services;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly ITipoService _tipoService;

        public TipoController(ITipoService tipoService)
        {
            _tipoService = tipoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo>>> GetTipos() =>
            Ok(await _tipoService.GetAllAsync());

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Tipo>> GetTipo(int codigo)
        {
            var tipo = await _tipoService.GetByIdAsync(codigo);
            return tipo == null ? NotFound() : Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> PostTipo(TipoDTO tipoDto)
        {
            await _tipoService.AddAsync(tipoDto);
            return CreatedAtAction(nameof(GetTipo), new { codigo = tipoDto.Codigo }, tipoDto);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutTipo(int codigo, TipoDTO tipoDto)
        {
            await _tipoService.UpdateAsync(codigo, tipoDto);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteTipo(int codigo)
        {
            await _tipoService.DeleteAsync(codigo);
            return NoContent();
        }
    }
}
