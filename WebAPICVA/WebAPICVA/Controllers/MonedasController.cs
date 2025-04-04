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
    public class MonedasController : ControllerBase
    {
        private readonly IMonedasService _monedasService;
        private readonly ApplicationDbContext _context;

        public MonedasController(ApplicationDbContext context, IMonedasService monedasService)
        {
            _context = context;
            _monedasService = monedasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moneda>>> GetMonedas()
        {
            return await _context.Monedas.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostMonedas(MonedaDTO monedasDTO)
        {
            await _monedasService.AddAsync(monedasDTO);
            return CreatedAtAction(nameof(GetMonedas), new { codigo = monedasDTO.Id_Monedas }, monedasDTO);
        }

        [HttpPut("{Id_Monedas}")]
        public async Task<IActionResult> PutMonedas(int Id_Monedas, MonedaDTO monedasDTO)
        {
            await _monedasService.UpdateAsync(Id_Monedas, monedasDTO);
            return NoContent();
        }

        [HttpDelete("{Id_Monedas}")]
        public async Task<IActionResult> DeleteMonedas(int Id_Monedas)
        {
            await _monedasService.DeleteAsync(Id_Monedas);
            return NoContent();
        }
    }
}
