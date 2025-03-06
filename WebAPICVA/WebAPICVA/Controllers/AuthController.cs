using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
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
        //[Consumes("application/json")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.AuthenticateAsync(request.Usuario, request.Password);

            Console.WriteLine($"Content-Type recibido: {Request.ContentType}");

            if (token == null)
            {
                return Unauthorized(new { message = "Credenciales inválidas" });
            }

            Console.WriteLine($"Usuario: {request.Usuario}, Password: {request.Password}");

            /*using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string body = await reader.ReadToEndAsync(); // ✅ Usar ReadToEndAsync()
                Console.WriteLine($"Cuerpo recibido: {body}");
            }*/

            return Ok(new { token });
        }

        [HttpPost("logout")]
        [Authorize] // Asegura que solo usuarios autenticados puedan cerrar sesión
        public async Task<IActionResult> Logout()
        {

            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(new { message = "Token no encontrado." });
            }

            Console.WriteLine($"Token recibido en Logout: {token}");


            /* Codigo Prueba*/

            Console.WriteLine($"🔍 Token recibido: {token}");
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jsonToken != null)
                {
                    Console.WriteLine($"✅ Token decodificado correctamente. Header: {jsonToken.Header.Alg}, Payload: {jsonToken.Payload}");
                }
                else
                {
                    Console.WriteLine("❌ No se pudo decodificar el token.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al decodificar el token: {ex.Message}");
            }



            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                {
                    return Unauthorized(new { message = "Token inválido." });
                }

                Console.WriteLine($"Token expira en: {jwtToken.ValidTo}");

                // Simula una verificación en lista negra
                if (await _tokenBlacklistService.IsTokenBlacklisted(token))
                {
                    return Unauthorized(new { message = "Token en lista negra." });
                }

                _tokenBlacklistService.AddToBlacklist(token);
                return Ok(new { message = "Logout exitoso" });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = "Token inválido o corrupto.", error = ex.Message });
            }

            /*Respaldo */

            /*var authHeader = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                return Unauthorized("No se encontró el token en la cabecera.");
                //return BadRequest(new { message = "Token no encontrado." });
            }

            var token = authHeader.Replace("Bearer ", "").Trim();

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(new { message = "Token no encontrado." });
            }

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

            //#region Codigo de Pruebas
            //Codigo de pruebas

            //var jwtHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            //var jwtToken = jwtHandler.ReadJwtToken(token);

            //Console.WriteLine($"Token expira en: {jwtToken.ValidTo}");
            //Console.WriteLine($"Fecha actual UTC: {DateTime.UtcNow}");

            //if (jwtToken.ValidTo < DateTime.UtcNow)
            //{
                //return Unauthorized("El token ha expirado.");
            //}
            //#endregion

            _tokenBlacklistService.AddToBlacklist(token);

            return Ok(new { message = "Sesión cerrada correctamente" });*/

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

        /* Codigo de Pruebas*/
        /* ----------------------- */
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
        /* ----------------------- */
    }
}