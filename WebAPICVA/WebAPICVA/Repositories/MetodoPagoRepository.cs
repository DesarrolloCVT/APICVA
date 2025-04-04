using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class MetodoPagoRepository : IMetodoPagoRepository
    {
        private readonly ApplicationDbContext _context;

        public MetodoPagoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MetodoPago>> GetAllAsync() =>
            await _context.MetodoPago.ToListAsync();

        public async Task<MetodoPago?> GetByIdAsync(int id) =>
            await _context.MetodoPago.FindAsync(id);

        public async Task AddAsync(MetodoPago metodoPago)
        {
            _context.MetodoPago.Add(metodoPago);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MetodoPago metodoPago)
        {
            _context.MetodoPago.Update(metodoPago);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var metodoPago = await _context.MetodoPago.FindAsync(id);
            if (metodoPago != null)
            {
                _context.MetodoPago.Remove(metodoPago);
                await _context.SaveChangesAsync();
            }
        }
    }
}
