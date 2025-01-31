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
        public async Task<ActionResult<IEnumerable<Tipo>>> GetBanco() =>
            Ok(await _tipoService.GetAllAsync());

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Tipo>> GetBanco(int codigo)
        {
            var banco = await _tipoService.GetByIdAsync(codigo);
            return banco == null ? NotFound() : Ok(banco);
        }

        [HttpPost]
        public async Task<IActionResult> PostBanco(TipoDTO tipoDto)
        {
            await _tipoService.AddAsync(tipoDto);
            return CreatedAtAction(nameof(GetBanco), new { codigo = tipoDto.Codigo }, tipoDto);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutBanco(int codigo, TipoDTO tipoDto)
        {
            await _tipoService.UpdateAsync(codigo, tipoDto);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteBanco(int codigo)
        {
            await _tipoService.DeleteAsync(codigo);
            return NoContent();
        }
    }
}
