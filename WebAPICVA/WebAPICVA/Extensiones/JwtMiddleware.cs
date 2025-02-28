using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebAPICVA.Services;

namespace WebAPICVA.Extensiones
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private TokenBlacklistService _tokenBlacklistService;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, TokenBlacklistService tokenBlacklistService)
        {

            /* ------ */
            /* Codigo de Obsoleto 
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                Console.WriteLine("🔴 No se recibió token o tiene formato incorrecto.");
                context.Response.StatusCode = 401;
                return;
            }

            var token = authHeader.Replace("Bearer ", "");
            Console.WriteLine($"🟢 Token recibido: {token}");

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _configuration["JwtSettings:Issuer"],
                    ValidAudience = _configuration["JwtSettings:Audience"],
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                Console.WriteLine("✅ Token validado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🔴 Error validando el token: {ex.Message}");
                context.Response.StatusCode = 401;
                return;
            }

            await _next(context);
            */
            /* ------ */

            _tokenBlacklistService = tokenBlacklistService;
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                /* Validacion Tokken Valido o Lista negra */
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                Console.WriteLine($"Token recibido en Middleware: {token}");

                if (string.IsNullOrEmpty(token) || !token.Contains("."))
                {
                    Console.WriteLine("🔴 El token no tiene un formato válido.");
                    context.Response.StatusCode = 401;
                    return;
                }


                var isBlacklisted = await _tokenBlacklistService.IsTokenBlacklisted(token);

                Console.WriteLine($"🔍 ¿El token está en la lista negra? {isBlacklisted}");

                if (!string.IsNullOrEmpty(token) && isBlacklisted)
                {
                    Console.WriteLine("🔴 Tokken no es Nulo pero se encuentra en la lista negra.");
                    context.Response.StatusCode = 401;
                    return;
                }

                var jwtHandler = new JwtSecurityTokenHandler();
                Console.WriteLine("🔴 StatusCode: " + context.Response.StatusCode);

                try
                {
                    var jwtToken = jwtHandler.ReadJwtToken(token);
                    Console.WriteLine($"🟢 Token recibido: {jwtToken.RawData}");
                    Console.WriteLine($"🔹 Expira en: {jwtToken.ValidTo}");
                    Console.WriteLine($"🔍 Claims en el token:");

                    Console.WriteLine("🔴 StatusCode: " + context.Response.StatusCode);

                    foreach (var claim in jwtToken.Claims)
                    {
                        Console.WriteLine($"{claim.Type}: {claim.Value}");
                    }

                    Console.WriteLine("🔴 StatusCode: " + context.Response.StatusCode);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"🔴 Error al leer el token: {ex.Message}");
                    context.Response.StatusCode = 401;
                    return;
                }
                /* Codigo de Respaldo */
                /* ----------------------------------------------------------------*/
                /*var token = authHeader.Substring("Bearer ".Length).Trim();

                if (await tokenBlacklistService.IsTokenBlacklisted(token))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Token inválido");
                    return;
                }*/
                /* ----------------------------------------------------------------*/
            }
            else
            {
                Console.WriteLine("🔴 No se recibio un token valido en la cabecera.");
            }

            await _next(context);
        }
    }
}
