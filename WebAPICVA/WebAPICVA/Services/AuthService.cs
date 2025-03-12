using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace WebAPICVA.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        #region Key
        //private readonly string secretKey = "v@8vG3#xU!9zP$YkW6rE^tM2L&dC7qN%"; // 🔥 DEBE COINCIDIR CON Program.cs
        #endregion

        public AuthService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public string GenerateToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]); // 🔥 La clave usada para firmar el token

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            }),
                Expires = DateTime.Now.AddHours(1), // Token válido por 1 hora
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string?> AuthenticateAsync(string usuario, string password)
        {
            try
            {
                var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioSistema == usuario);

                if (user != null)
                {

                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    bool passwordValida = BCrypt.Net.BCrypt.Verify(password, user.ClaveEncriptada.Trim());

                    if (usuario == null || !BCrypt.Net.BCrypt.Verify(password, user.ClaveEncriptada.Trim()))
                    {
                        return null; // Usuario no encontrado o contraseña incorrecta
                    }

                    return GenerateJwtToken(user);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {   
                return null;
            }
            
        }

        private string GenerateJwtToken(Usuarios usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
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
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            var TokenFormat = new JwtSecurityTokenHandler().WriteToken(token);

            return TokenFormat;
        }

        public async Task<bool> IsTokenBlacklisted(string token)
        {
            return await _context.TokenBlacklist.AnyAsync(t => t.Token == token);
        }
    }
}
