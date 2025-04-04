using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class TransaccionDetalleRepository : ITransaccionDetalleRepository
    {
        private readonly ApplicationDbContext _context;

        public TransaccionDetalleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransaccionDetalle>> GetAllAsync() =>
            await _context.TransaccionDetalle.ToListAsync();

        public async Task<TransaccionDetalle?> GetByIdAsync(int id_transaccion_detalle) =>
            await _context.TransaccionDetalle.FindAsync(id_transaccion_detalle);

        public async Task AddAsync(TransaccionDetalle transaccionDetalle)
        {
            _context.TransaccionDetalle.Add(transaccionDetalle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TransaccionDetalle transaccionDetalle)
        {
            _context.TransaccionDetalle.Update(transaccionDetalle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id_transaccion_detalle)
        {
            var transaccionDetalle = await _context.TransaccionDetalle.FindAsync(id_transaccion_detalle);
            if (transaccionDetalle != null)
            {
                _context.TransaccionDetalle.Remove(transaccionDetalle);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TransaccionDetalle>> GetFilterTransaccionDetalle(int id) =>
            await _context.TransaccionDetalle.ToListAsync();
    }
}
