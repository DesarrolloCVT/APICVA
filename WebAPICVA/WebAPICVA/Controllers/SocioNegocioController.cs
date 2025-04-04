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
    public class SocioNegocioController : ControllerBase
    {
        private readonly ISocioNegocioService _socioNegocioService;
        private readonly ApplicationDbContext _context;

        public SocioNegocioController(ISocioNegocioService socioNegocioService, ApplicationDbContext context)
        {
            _socioNegocioService = socioNegocioService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocioNegocio>>> GetSocioNegocio() =>
            Ok(await _socioNegocioService.GetAllAsync());

        [HttpGet("{codigo}")]
        public async Task<ActionResult<SocioNegocio>> GetSocioNegocio(int codigo)
        {
            var socioNegocio = await _socioNegocioService.GetByIdAsync(codigo);
            return socioNegocio == null ? NotFound() : Ok(socioNegocio);
        }

        [HttpPost]
        public async Task<IActionResult> PostSocioNegocio(SocioNegocioDTO socioNegocioDto)
        {
            await _socioNegocioService.AddAsync(socioNegocioDto);
            return CreatedAtAction(nameof(GetSocioNegocio), new { codigo = socioNegocioDto.Codigo }, socioNegocioDto);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutSocioNegocio(int codigo, SocioNegocioDTO socioNegocioDto)
        {
            await _socioNegocioService.UpdateAsync(codigo, socioNegocioDto);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteSocioNegocio(int codigo)
        {
            await _socioNegocioService.DeleteAsync(codigo);
            return NoContent();
        }
    }
}
