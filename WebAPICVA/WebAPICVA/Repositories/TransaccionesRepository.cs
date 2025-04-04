using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class TransaccionesRepository : ITransaccionesRepository
    {
        private readonly ApplicationDbContext _context;

        public TransaccionesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transacciones>> GetAllAsync() =>
            await _context.Transacciones.ToListAsync();

        public async Task<Transacciones?> GetByIdAsync(int id_transaccion) =>
            await _context.Transacciones.FindAsync(id_transaccion);

        public async Task AddAsync(Transacciones transacciones)
        {
            _context.Transacciones.Add(transacciones);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transacciones transacciones)
        {
            _context.Transacciones.Update(transacciones);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id_transaccion)
        {
            var transacciones = await _context.Ingresos.FindAsync(id_transaccion);
            if (transacciones != null)
            {
                _context.Ingresos.Remove(transacciones);
                await _context.SaveChangesAsync();
            }
        }
    }
}
