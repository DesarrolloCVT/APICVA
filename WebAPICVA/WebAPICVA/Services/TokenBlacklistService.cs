using System.Collections.Concurrent;

namespace WebAPICVA.Services
{
    public class TokenBlacklistService
    {
        private static readonly ConcurrentDictionary<string, DateTime> _blacklist = new();

    public void AddToBlacklist(string token)
    {
        _blacklist[token] = DateTime.UtcNow.AddHours(1); // Expira en 1 hora
    }

    public bool IsTokenBlacklisted(string token)
    {
        return _blacklist.ContainsKey(token);
    }
    }
}
