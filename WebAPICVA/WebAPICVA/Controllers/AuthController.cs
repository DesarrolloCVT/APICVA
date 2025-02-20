using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WebAPICVA.Models;
using WebAPICVA.Services;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly TokenBlacklistService _tokenBlacklistService;

        public AuthController(AuthService authService, TokenBlacklistService tokenBlacklistService)
        {
            _authService = authService;
            _tokenBlacklistService = tokenBlacklistService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.AuthenticateAsync(request.Usuario, request.Password);

            if (token == null)
            {
                return Unauthorized(new { message = "Credenciales inválidas" });
            }

            return Ok(new { token });
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var authHeader = Request.Headers["Authorization"].FirstOrDefault();

            if (authHeader == null || !authHeader.StartsWith("Bearer "))
                return BadRequest("Token no válido");

            var token = authHeader.Substring("Bearer ".Length).Trim();

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;
            var expiration = jwtToken?.ValidTo ?? DateTime.UtcNow;

            await _tokenBlacklistService.AddToBlacklist(token, expiration);

            return Ok(new { message = "Sesión cerrada correctamente" });
        }
    }
}