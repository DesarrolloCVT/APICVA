using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Services;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _bancoService;

        public BancoController(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banco>>> GetBancoDetalle() =>
            Ok(await _bancoService.GetAllAsync());

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Banco>> GetBancoDetalle(int codigo)
        {
            var banco = await _bancoService.GetByIdAsync(codigo);
            return banco == null ? NotFound() : Ok(banco);
        }

        [HttpPost]
        public async Task<IActionResult> PostBancoDetalle(BancoDTO bancoDto)
        {
            await _bancoService.AddAsync(bancoDto);
            return CreatedAtAction(nameof(GetBancoDetalle), new { codigo = bancoDto.Codigo }, bancoDto);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutBancoDetalle(int codigo, BancoDTO bancoDto)
        {
            await _bancoService.UpdateAsync(codigo, bancoDto);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteBancoDetalle(int codigo)
        {
            await _bancoService.DeleteAsync(codigo);
            return NoContent();
        }
    }
}
