using WebAPICVA.Services;

namespace WebAPICVA.Extensiones
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, TokenBlacklistService tokenBlacklistService)
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length).Trim();

                if (await tokenBlacklistService.IsTokenBlacklisted(token))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Token inválido");
                    return;
                }
            }

            await _next(context);
        }
    }
}
