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
    public class EgresosController : ControllerBase
    {
        private readonly IEgresosService _egresoService;
        private readonly ApplicationDbContext _context;

        public EgresosController(IEgresosService egresoService, ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _egresoService = egresoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Egresos>>> GetEgresos() =>
            Ok(await _egresoService.GetAllAsync());

        [HttpGet("{folio}")]
        public async Task<ActionResult<Egresos>> GetEgresos(int folio)
        {
            var egresos = await _egresoService.GetByIdAsync(folio);
            return egresos == null ? NotFound() : Ok(egresos);
        }

        [HttpPost]
        public async Task<IActionResult> PostEgresos(EgresosDTO egresosDto)
        {
            await _egresoService.AddAsync(egresosDto);
            return CreatedAtAction(nameof(GetEgresos), new { folio = egresosDto.Folio }, egresosDto);
        }

        [HttpPut("{id_egreso}")]
        public async Task<IActionResult> PutEgresos(int id_egreso, EgresosDTO egresosDto)
        {
            await _egresoService.UpdateAsync(id_egreso, egresosDto);
            return NoContent();
        }

        [HttpDelete("{folio}")]
        public async Task<IActionResult> DeleteEgresos(int folio)
        {
            await _egresoService.DeleteAsync(folio);
            return NoContent();
        }
    }
}
