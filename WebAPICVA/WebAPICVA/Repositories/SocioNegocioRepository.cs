using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class SocioNegocioRepository : ISocioNegocioRepository
    {
        private readonly ApplicationDbContext _context;

        public SocioNegocioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SocioNegocio>> GetAllAsync() =>
            await _context.SocioNegocio.ToListAsync();

        public async Task<SocioNegocio?> GetByIdAsync(int codigo) =>
            await _context.SocioNegocio.FindAsync(codigo);

        public async Task AddAsync(SocioNegocio socioNegocio)
        {
            _context.SocioNegocio.Add(socioNegocio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SocioNegocio socioNegocio)
        {
            _context.SocioNegocio.Update(socioNegocio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int codigo)
        {
            var socioNegocio = await _context.SocioNegocio.FindAsync(codigo);
            if (socioNegocio != null)
            {
                _context.SocioNegocio.Remove(socioNegocio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
