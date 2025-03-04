using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Services;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios() =>
            Ok(await _usuarioService.GetAllAsync());

        [HttpGet("id/{idUsuario}")]
        public async Task<ActionResult<Usuarios>> GetUsuario(int idUsuario)
        {
            var usuario = await _usuarioService.GetByIdAsync(idUsuario);
            return usuario == null ? NotFound() : Ok(usuario);
        }

        [HttpGet("name/{UsuarioSistema}")]
        public async Task<ActionResult<Usuarios>> GetNameUsuario(string UsuarioSistema)
        {
            var usuario = await _usuarioService.GetByNameAsync(UsuarioSistema);
            if (usuario == null)
            {
                Console.WriteLine($"🔴 Usuario '{UsuarioSistema}' no encontrado.");
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuario(UsuariosDTO usuarioDto)
        {
            await _usuarioService.AddAsync(usuarioDto);
            return CreatedAtAction(nameof(GetUsuario), new { idUsuario = usuarioDto.NombreUsuario }, usuarioDto);
        }

        [HttpPut("{idUsuario}")]
        public async Task<IActionResult> PutUsuario(int idUsuario, UsuariosDTO usuarioDto)
        {
            await _usuarioService.UpdateAsync(idUsuario, usuarioDto);
            return NoContent();
        }

        [HttpDelete("{idUsuario}")]
        public async Task<IActionResult> DeleteUsuario(int idUsuario)
        {
            await _usuarioService.DeleteAsync(idUsuario);
            return NoContent();
        }
    }
}