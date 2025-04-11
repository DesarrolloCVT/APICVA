using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class FacturaVentaDetalleRepository : IFacturaVentaDetalleRepository
    {
        private readonly ApplicationDbContext _context;

        public FacturaVentaDetalleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FacturaVentaDetalle>> GetAllAsync() =>
            await _context.FacturaVentaDetalle.ToListAsync();

        public async Task<FacturaVentaDetalle?> GetByIdAsync(int id) =>
            await _context.FacturaVentaDetalle.FindAsync(id);

        public async Task AddAsync(FacturaVentaDetalle facturaVentaDetalle)
        {
            _context.FacturaVentaDetalle.Add(facturaVentaDetalle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FacturaVentaDetalle facturaVentaDetalle)
        {
            _context.FacturaVentaDetalle.Update(facturaVentaDetalle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var facturaVentaDetalle = await _context.FacturaVentaDetalle.FindAsync(id);
            if (facturaVentaDetalle != null)
            {
                _context.FacturaVentaDetalle.Remove(facturaVentaDetalle);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FacturaVentaDetalle>> GetFilterFactVentaDetalle(int id) =>
            await _context.FacturaVentaDetalle.ToListAsync();
    }
}
