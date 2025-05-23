﻿using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public class CuentasRepository : ICuentasRepository
    {
        private readonly ApplicationDbContext _context;

        public CuentasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cuentas>> GetAllAsync() =>
            await _context.Cuentas.ToListAsync();

        public async Task<Cuentas?> GetByIdAsync(int id) =>
            await _context.Cuentas.FindAsync(id);

        public async Task AddAsync(Cuentas cuentas)
        {
            _context.Cuentas.Add(cuentas);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cuentas cuentas)
        {
            _context.Cuentas.Update(cuentas);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cuentas = await _context.Cuentas.FindAsync(id);
            if (cuentas != null)
            {
                _context.Cuentas.Remove(cuentas);
                await _context.SaveChangesAsync();
            }
        }
    }
}
