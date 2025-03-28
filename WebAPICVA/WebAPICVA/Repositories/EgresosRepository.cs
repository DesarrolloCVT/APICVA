using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class EgresosRepository : IEgresosRepository
    {
        private readonly ApplicationDbContext _context;

        public EgresosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Egresos>> GetAllAsync() =>
            await _context.Egresos.ToListAsync();

        /*public async Task<IActionResult> GetFilterAsync([FromQuery] int? filtro)
        {
            var egresos = _context.Egresos.AsQueryable();

            if (filtro != 0)
            {
                egresos = egresos.Where(i => i.Id_Egreso == filtro);
            }

            var resultado = await egresos.ToListAsync();
            return (IActionResult)resultado;
        }*/
            

        public async Task<Egresos?> GetByIdAsync(int folio) =>
            await _context.Egresos.FindAsync(folio);

        public async Task AddAsync(Egresos egresos)
        {
            _context.Egresos.Add(egresos);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Egresos egresos)
        {   
            _context.Egresos.Update(egresos);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int folio)
        {
            var egresos = await _context.Egresos.FindAsync(folio);
            if (egresos != null)
            {
                _context.Egresos.Remove(egresos);
                await _context.SaveChangesAsync();
            }
        }
    }
}
