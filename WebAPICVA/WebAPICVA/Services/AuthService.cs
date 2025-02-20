using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPICVA.Data;
using WebAPICVA.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPICVA.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<string?> AuthenticateAsync(string usuario, string password)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioSistema == usuario);

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            bool passwordValida = BCrypt.Net.BCrypt.Verify(password, user.ClaveEncriptada.Trim());

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(password, user.ClaveEncriptada.Trim()))
            {
                return null; // Usuario no encontrado o contraseña incorrecta
            }

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(Usuarios usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            if (key.KeySize < 32)
            {
                throw new Exception("Clave JWT demasiado corta. Debe tener al menos 32 caracteres.");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.UserData, usuario.UsuarioSistema)
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /*public async Task<bool> LogoutAsync(string token, DateTime expiration)
        {
            // Guardar el token en la base de datos
            var tokenBlacklist = new TokenBlacklist
            {
                Token = token,
                Expiration = expiration
            };

            _context.TokenBlacklist.Add(tokenBlacklist);
            await _context.SaveChangesAsync();
            return true;
        }*/

        public async Task<bool> LogoutAsync(string token)
        {
            if (string.IsNullOrEmpty(token)) return false;

            var blacklistedToken = new TokenBlacklist
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(1) // Expira en 1 hora
            };

            _context.TokenBlacklist.Add(blacklistedToken);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsTokenBlacklisted(string token)
        {
            return await _context.TokenBlacklist.AnyAsync(t => t.Token == token);
        }
    }
}
