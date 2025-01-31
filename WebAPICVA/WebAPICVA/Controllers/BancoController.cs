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
        public async Task<ActionResult<IEnumerable<Banco>>> GetBanco() =>
            Ok(await _bancoService.GetAllAsync());

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Banco>> GetBanco(int codigo)
        {
            var banco = await _bancoService.GetByIdAsync(codigo);
            return banco == null ? NotFound() : Ok(banco);
        }

        [HttpPost]
        public async Task<IActionResult> PostBanco(BancoDTO bancoDto)
        {
            await _bancoService.AddAsync(bancoDto);
            return CreatedAtAction(nameof(GetBanco), new { codigo = bancoDto.Codigo }, bancoDto);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutBanco(int codigo, BancoDTO bancoDto)
        {
            await _bancoService.UpdateAsync(codigo, bancoDto);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteBanco(int codigo)
        {
            await _bancoService.DeleteAsync(codigo);
            return NoContent();
        }
    }
}
