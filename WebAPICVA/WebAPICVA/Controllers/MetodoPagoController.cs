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
    public class MetodoPagoController : ControllerBase
    {
        private readonly IMetodoPagoService _metodoPagoService;
        private readonly ApplicationDbContext _context;

        public MetodoPagoController(ApplicationDbContext context, IMetodoPagoService metodoPagoService)
        {
            _metodoPagoService = metodoPagoService;
            _context = context;
        }

        /*
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetodoPago>>> GetMetodoPago() =>
            Ok(await _metodoPagoService.GetAllAsync());
        */


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetodoPago>>> GetMetodoPago()
        {
            return await _context.MetodoPago.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostSocioNegocio(MetodoPagoDTO metodoPagoDTO)
        {
            await _metodoPagoService.AddAsync(metodoPagoDTO);
            return CreatedAtAction(nameof(GetMetodoPago), new { codigo = metodoPagoDTO.Id_Metodo_Pago }, metodoPagoDTO);
        }

        [HttpPut("{Id_Metodo_Pago}")]
        public async Task<IActionResult> PutMetodoPago(int Id_Metodo_Pago, MetodoPagoDTO metodoPagoDTO)
        {
            await _metodoPagoService.UpdateAsync(Id_Metodo_Pago, metodoPagoDTO);
            return NoContent();
        }

        [HttpDelete("{Id_Metodo_Pago}")]
        public async Task<IActionResult> DeleteSocioNegocio(int Id_Metodo_Pago)
        {
            await _metodoPagoService.DeleteAsync(Id_Metodo_Pago);
            return NoContent();
        }
    }
}
