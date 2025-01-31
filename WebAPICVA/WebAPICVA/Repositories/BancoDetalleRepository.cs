using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class BancoDetalleRepository : IBancoDetalleRepository
    {
        private readonly ApplicationDbContext _context;

        public BancoDetalleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BancoDetalle>> GetAllAsync() =>
            await _context.BancoDetalle.ToListAsync();

        public async Task<BancoDetalle?> GetByIdAsync(int codigo) =>
            await _context.BancoDetalle.FindAsync(codigo);

        public async Task AddAsync(BancoDetalle bancoDetalle)
        {
            _context.BancoDetalle.Add(bancoDetalle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BancoDetalle bancoDetalle)
        {
            _context.BancoDetalle.Update(bancoDetalle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int codigo)
        {
            var bancoDetalle = await _context.BancoDetalle.FindAsync(codigo);
            if (bancoDetalle != null)
            {
                _context.BancoDetalle.Remove(bancoDetalle);
                await _context.SaveChangesAsync();
            }
        }
    }
}
