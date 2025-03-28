using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class IngresosDetalleRepository : IIngresosDetalleRepository
    {
        private readonly ApplicationDbContext _context;

        public IngresosDetalleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IngresosDetalle>> GetAllAsync() =>
            await _context.IngresosDetalle.ToListAsync();

        public async Task<IngresosDetalle?> GetByIdAsync(int folio) =>
            await _context.IngresosDetalle.FindAsync(folio);

        public async Task AddAsync(IngresosDetalle ingresosDetalle)
        {
            _context.IngresosDetalle.Add(ingresosDetalle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IngresosDetalle ingresosDetalle)
        {
            _context.IngresosDetalle.Update(ingresosDetalle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int folio)
        {
            var ingresosDetalle = await _context.IngresosDetalle.FindAsync(folio);
            if (ingresosDetalle != null)
            {
                _context.IngresosDetalle.Remove(ingresosDetalle);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<IngresosDetalle>> GetFilterIngresosDetalle(int id) =>
            await _context.IngresosDetalle.ToListAsync();
    }
}
