using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public BancoDetalleController(IBancoDetalleService bancoDetalleService)
        {
            _bancoDetalleService = bancoDetalleService;
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

        [HttpPost]
        public async Task<IActionResult> PostBancoDetalle(BancoDetalleDTO bancoDetalleDto)
        {
            await _bancoDetalleService.AddAsync(bancoDetalleDto);
            return CreatedAtAction(nameof(GetBancoDetalle), new { codigo_banco = bancoDetalleDto.Codigo_Banco }, bancoDetalleDto);
        }

        [HttpPut("{codigo_banco}")]
        public async Task<IActionResult> PutBancoDetalle(int codigo_banco, BancoDetalleDTO bancoDetalleDto)
        {
            await _bancoDetalleService.UpdateAsync(codigo_banco, bancoDetalleDto);
            return NoContent();
        }

        [HttpDelete("{codigo_banco}")]
        public async Task<IActionResult> DeleteBancoDetalle(int codigo)
        {
            await _bancoDetalleService.DeleteAsync(codigo);
            return NoContent();
        }
    }
}
