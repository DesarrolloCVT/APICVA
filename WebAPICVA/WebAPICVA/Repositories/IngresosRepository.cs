using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class IngresosRepository : IIngresosRepository
    {
        private readonly ApplicationDbContext _context;

        public IngresosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingresos>> GetAllAsync() =>
            await _context.Ingresos.ToListAsync();

        public async Task<Ingresos?> GetByIdAsync(int id_ingreso) =>
            await _context.Ingresos.FindAsync(id_ingreso);

        public async Task AddAsync(Ingresos ingresos)
        {
            _context.Ingresos.Add(ingresos);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ingresos ingresos)
        {
            _context.Ingresos.Update(ingresos);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id_ingreso)
        {
            var ingresos = await _context.Ingresos.FindAsync(id_ingreso);
            if (ingresos != null)
            {
                _context.Ingresos.Remove(ingresos);
                await _context.SaveChangesAsync();
            }
        }
    }
}
