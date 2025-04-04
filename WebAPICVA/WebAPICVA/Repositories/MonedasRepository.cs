using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class MonedasRepository : IMonedasRepository
    {
        private readonly ApplicationDbContext _context;

        public MonedasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Moneda>> GetAllAsync() =>
            await _context.Monedas.ToListAsync();

        public async Task<Moneda?> GetByIdAsync(int id) =>
            await _context.Monedas.FindAsync(id);

        public async Task AddAsync(Moneda moneda)
        {
            _context.Monedas.Add(moneda);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Moneda moneda)
        {
            _context.Monedas.Update(moneda);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var moneda = await _context.Monedas.FindAsync(id);
            if (moneda != null)
            {
                _context.Monedas.Remove(moneda);
                await _context.SaveChangesAsync();
            }
        }
    }
}
