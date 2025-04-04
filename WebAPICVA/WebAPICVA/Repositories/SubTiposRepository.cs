using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class SubTiposRepository : ISubTiposRepository
    {
        private readonly ApplicationDbContext _context;

        public SubTiposRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subtipos>> GetAllAsync() =>
            await _context.Subtipos.ToListAsync();

        public async Task<Subtipos?> GetByIdAsync(int id) =>
            await _context.Subtipos.FindAsync(id);

        public async Task AddAsync(Subtipos subTipos)
        {
            _context.Subtipos.Add(subTipos);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Subtipos metodoPago)
        {
            _context.Subtipos.Update(metodoPago);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subTipo = await _context.Subtipos.FindAsync(id);
            if (subTipo != null)
            {
                _context.Subtipos.Remove(subTipo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
