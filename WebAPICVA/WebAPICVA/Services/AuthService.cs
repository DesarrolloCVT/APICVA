using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPICVA.Data;
using WebAPICVA.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPICVA.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly string secretKey = "EstaEsUnaClaveMuySeguraDe32Caracteres!"; // 🔥 DEBE COINCIDIR CON Program.cs

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

            var token = GenerateToken(1);
            Console.WriteLine($"🔍 Token generado: {token}");

            return GenerateToken(user.IdUsuario);
        }

        public string GenerateToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.UTF8.GetBytes(secretKey); // 🔥 La clave usada para firmar el token
            /*Codigo de Pruebas*/
            Console.WriteLine($"🔍 Clave secreta usada: {secretKey}");



            /* Codigo de prueba*/
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // 🔥 Importante: HmacSha256

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Name, "NombreDeUsuario")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = creds
            };


            /*var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(1), // Token válido por 1 hora
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };*/

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> IsTokenBlacklisted(string token)
        {
            return await _context.TokenBlacklist.AnyAsync(t => t.Token == token);
        }

        /*private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly string _secretKey = "EstaEsUnaClaveMuySeguraDe32Caracteres!"; // Debe coincidir con Program.cs

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

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
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
                _config["JwtSettings:Issuer"],
                _config["JwtSettings:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> IsTokenBlacklisted(string token)
        {
            return await _context.TokenBlacklist.AnyAsync(t => t.Token == token);
        }*/
    }
}
