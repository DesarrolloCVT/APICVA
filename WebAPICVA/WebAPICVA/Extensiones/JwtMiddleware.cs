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
            /*
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

            #region Codigo OFF
            
            _tokenBlacklistService = tokenBlacklistService;
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {   
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (!string.IsNullOrEmpty(token) && await _tokenBlacklistService.IsTokenBlacklisted(token))
                {
                    Console.WriteLine("🔴 Tokken no es Nulo pero se encuentra en la lista negra.");
                    context.Response.StatusCode = 401;
                    return;
                }

                var jwtHandler = new JwtSecurityTokenHandler();

                try
                {
                    var jwtToken = jwtHandler.ReadJwtToken(token);
                    Console.WriteLine($"🟢 Token recibido: {jwtToken.RawData}");
                    Console.WriteLine($"🔹 Expira en: {jwtToken.ValidTo}");

                    Console.WriteLine($"🔍 Claims en el token:");
                    foreach (var claim in jwtToken.Claims)
                    {
                        Console.WriteLine($"{claim.Type}: {claim.Value}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"🔴 Error al leer el token: {ex.Message}");
                    context.Response.StatusCode = 401;
                    return;
                }

                /*var token = authHeader.Substring("Bearer ".Length).Trim();

                if (await tokenBlacklistService.IsTokenBlacklisted(token))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Token inválido");
                    return;
                }*/
            }
            else
            {
                Console.WriteLine("🔴 No se recibió un token válido en la cabecera.");
            }

            await _next(context);
            #endregion
        }
    }
}
