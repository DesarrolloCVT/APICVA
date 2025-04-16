using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class FacturaCompraRepository : IFacturaCompraRepository
    {
        private readonly ApplicationDbContext _context;

        public FacturaCompraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FacturaCompra>> GetAllAsync() =>
            await _context.FacturaCompra.ToListAsync();

        public async Task<FacturaCompra?> GetByIdAsync(int folio) =>
            await _context.FacturaCompra.FindAsync(folio);

        public async Task AddAsync(FacturaCompra facturaCompra)
        {
            _context.FacturaCompra.Add(facturaCompra);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FacturaCompra facturaCompra)
        {
            _context.FacturaCompra.Update(facturaCompra);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int folio)
        {
            var facturaCompra = await _context.FacturaCompra.FindAsync(folio);
            if (facturaCompra != null)
            {
                _context.FacturaCompra.Remove(facturaCompra);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FacturaCompra>> GetFilterFactCompra() =>
            await _context.FacturaCompra.ToListAsync();
    }
}
