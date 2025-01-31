using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class FacturaVentaRepository : IFacturaVentaRepository
    {
        private readonly ApplicationDbContext _context;

        public FacturaVentaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FacturaVenta>> GetAllAsync() =>
            await _context.FacturaVenta.ToListAsync();

        public async Task<FacturaVenta?> GetByIdAsync(int folio) =>
            await _context.FacturaVenta.FindAsync(folio);

        public async Task AddAsync(FacturaVenta facturaVenta)
        {
            _context.FacturaVenta.Add(facturaVenta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FacturaVenta facturaVenta)
        {
            _context.FacturaVenta.Update(facturaVenta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int folio)
        {
            var facturaVenta = await _context.FacturaVenta.FindAsync(folio);
            if (facturaVenta != null)
            {
                _context.FacturaVenta.Remove(facturaVenta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
