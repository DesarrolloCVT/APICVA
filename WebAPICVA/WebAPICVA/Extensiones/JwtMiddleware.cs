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

    public async Task Invoke(HttpContext context)
    {
        var authService = context.RequestServices.GetRequiredService<AuthService>();
        var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

        if (authHeader != null && authHeader.StartsWith("Bearer "))
        {
            string token = authHeader.Substring("Bearer ".Length).Trim();

            if (await authService.IsTokenBlacklisted(token))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Token inválido o expirado.");
                return;
            }
        }

        await _next(context);
    }
}
}
