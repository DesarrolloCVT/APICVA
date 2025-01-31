using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class TipoRepository : ITipoRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tipo>> GetAllAsync() =>
            await _context.Tipo.ToListAsync();

        public async Task<Tipo?> GetByIdAsync(int codigo) =>
            await _context.Tipo.FindAsync(codigo);

        public async Task AddAsync(Tipo tipo)
        {
            _context.Tipo.Add(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tipo tipo)
        {
            _context.Tipo.Update(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int codigo)
        {
            var tipo = await _context.Tipo.FindAsync(codigo);
            if (tipo != null)
            {
                _context.Tipo.Remove(tipo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
