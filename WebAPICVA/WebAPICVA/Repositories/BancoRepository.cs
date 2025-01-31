using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly ApplicationDbContext _context;

        public BancoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Banco>> GetAllAsync() =>
            await _context.Banco.ToListAsync();

        public async Task<Banco?> GetByIdAsync(int codigo) =>
            await _context.Banco.FindAsync(codigo);

        public async Task AddAsync(Banco banco)
        {
            _context.Banco.Add(banco);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Banco banco)
        {
            _context.Banco.Update(banco);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int codigo)
        {
            var banco = await _context.Banco.FindAsync(codigo);
            if (banco != null)
            {
                _context.Banco.Remove(banco);
                await _context.SaveChangesAsync();
            }
        }
    }
}
