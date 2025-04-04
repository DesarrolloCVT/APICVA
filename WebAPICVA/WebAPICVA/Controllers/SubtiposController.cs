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
    public class SubtiposController : ControllerBase
    {
        private readonly ISubTiposService _subTipoService;
        private readonly ApplicationDbContext _context;

        public SubtiposController(ApplicationDbContext context, ISubTiposService subTipoService)
        {
            _context = context;
            _subTipoService = subTipoService;
        }

        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Subtipos>>> GetSubtipos() =>
            Ok(await _subTipoService.GetAllAsync());*/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subtipos>>> GetSubtipos()
        {
            return await _context.Subtipos.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostSubTipo(SubtiposDTO subTipoDTO)
        {
            await _subTipoService.AddAsync(subTipoDTO);
            return CreatedAtAction(nameof(GetSubtipos), new { codigo = subTipoDTO.Id_Subtipos }, subTipoDTO);
        }

        [HttpPut("{Id_Subtipos}")]
        public async Task<IActionResult> PutSubTipo(int Id_Subtipos, SubtiposDTO subTipoDTO)
        {
            await _subTipoService.UpdateAsync(Id_Subtipos, subTipoDTO);
            return NoContent();
        }

        [HttpDelete("{Id_Subtipos}")]
        public async Task<IActionResult> DeleteSubTipo(int Id_Subtipos)
        {
            await _subTipoService.DeleteAsync(Id_Subtipos);
            return NoContent();
        }

        [HttpGet("GetSubtipo")]
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
