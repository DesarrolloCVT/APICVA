using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public class TokenBlacklistService
    {
        private readonly ApplicationDbContext _context;

        public TokenBlacklistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddToBlacklist(string token, DateTime expiration)
        {
            _context.TokenBlacklist.Add(new TokenBlacklist { Token = token, Expiration = expiration });
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsTokenBlacklisted(string token)
        {
            return await _context.TokenBlacklist.AnyAsync(t => t.Token == token);
        }
    }
}
