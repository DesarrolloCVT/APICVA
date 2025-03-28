using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubtiposController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubtiposController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subtipos>>> GetSubtipos()
        {
            return await _context.Subtipos.ToListAsync();
        }

        [HttpGet("GetSubtipos")]
        public async Task<ActionResult<Subtipos>> GetFilterSubtipos([FromQuery] string identificador)
        {
            var filtro = await _context.Subtipos
        .Where(d => d.Identificador == identificador) // Filtrar por la clave foránea
        .ToListAsync();

            if (!filtro.Any())
            {
                return NotFound("No se encontraron detalles para este ingreso.");
            }

            return Ok(filtro);
        }
    }
}
