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
        //[Authorize] // Asegura que solo usuarios autenticados puedan cerrar sesión
        public async Task<IActionResult> Logout()
        {

            var authHeader = Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                return Unauthorized("No se encontró el token en la cabecera.");
            }

            var token = authHeader.Replace("Bearer ", "").Trim();
            var jwtHandler = new JwtSecurityTokenHandler();

            try
            {
                var jwtToken = jwtHandler.ReadJwtToken(token);
                Console.WriteLine($"🟢 Token recibido: {jwtToken.RawData}");
                Console.WriteLine($"🔹 Expira en: {jwtToken.ValidTo}");
                Console.WriteLine($"🔹 Fecha actual UTC: {DateTime.UtcNow}");

                if (jwtToken.ValidTo < DateTime.UtcNow)
                {
                    return Unauthorized("El token ha expirado.");
                }
            }
            catch (Exception ex)
            {
                return Unauthorized($"Error al leer el token: {ex.Message}");
            }

            var identity = HttpContext.User.Identity;

            if (identity == null || !identity.IsAuthenticated)
            {
                Console.WriteLine("🔴 Usuario no autenticado en el contexto de la API.");
                return Unauthorized();
            }

            Console.WriteLine($"🟢 Usuario autenticado: {identity.Name}");

            if (string.IsNullOrEmpty(token))
                return BadRequest("Token no válido");

            #region Codigo de Pruebas
            /* Codigo de pruebas */

            //var jwtHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            //var jwtToken = jwtHandler.ReadJwtToken(token);

            //Console.WriteLine($"Token expira en: {jwtToken.ValidTo}");
            //Console.WriteLine($"Fecha actual UTC: {DateTime.UtcNow}");

            /*if (jwtToken.ValidTo < DateTime.UtcNow)
            {
                return Unauthorized("El token ha expirado.");
            }*/
            #endregion

            _tokenBlacklistService.AddToBlacklist(token);

            return Ok(new { message = "Sesión cerrada correctamente" });

            #region OFF
            /*var authHeader = Request.Headers["Authorization"].FirstOrDefault();

            if (authHeader == null || !authHeader.StartsWith("Bearer "))
                return BadRequest("Token no válido");

            var token = authHeader.Substring("Bearer ".Length).Trim();

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;
            var expiration = jwtToken?.ValidTo ?? DateTime.UtcNow;

            await _tokenBlacklistService.AddToBlacklist(token, expiration);

            return Ok(new { message = "Sesión cerrada correctamente" });*/
            #endregion
        }

        [HttpGet("test-auth")]
        [Authorize]
        public IActionResult TestAuth()
        {
            var identity = HttpContext.User.Identity;

            if (identity == null || !identity.IsAuthenticated)
            {
                Console.WriteLine("🔴 Usuario no autenticado en la API.");
                return Unauthorized();
            }

            var claims = HttpContext.User.Claims.Select(c => new { c.Type, c.Value }).ToList();

            Console.WriteLine("🟢 Usuario autenticado. Claims:");
            foreach (var claim in claims)
            {
                Console.WriteLine($"🔹 {claim.Type}: {claim.Value}");
            }

            return Ok(new { message = "Usuario autenticado", claims });
        }
    }
}