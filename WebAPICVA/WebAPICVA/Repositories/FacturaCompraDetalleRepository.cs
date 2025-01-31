using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class FacturaCompraDetalleRepository : IFacturaCompraDetalleRepository
    {
        private readonly ApplicationDbContext _context;

        public FacturaCompraDetalleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FacturaCompraDetalle>> GetAllAsync() =>
            await _context.FacturaCompraDetalle.ToListAsync();

        public async Task<FacturaCompraDetalle?> GetByIdAsync(int folio) =>
            await _context.FacturaCompraDetalle.FindAsync(folio);

        public async Task AddAsync(FacturaCompraDetalle facturaCompraDetalle)
        {
            _context.FacturaCompraDetalle.Add(facturaCompraDetalle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FacturaCompraDetalle facturaCompraDetalle)
        {
            _context.FacturaCompraDetalle.Update(facturaCompraDetalle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int folio)
        {
            var facturaCompraDetalle = await _context.FacturaCompraDetalle.FindAsync(folio);
            if (facturaCompraDetalle != null)
            {
                _context.FacturaCompraDetalle.Remove(facturaCompraDetalle);
                await _context.SaveChangesAsync();
            }
        }
    }
}
