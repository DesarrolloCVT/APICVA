﻿using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface ISocioNegocioRepository
    {
        Task<IEnumerable<SocioNegocio>> GetAllAsync();
        Task<SocioNegocio?> GetByIdAsync(int id);
        Task AddAsync(SocioNegocio socioNegocio);
        Task UpdateAsync(SocioNegocio socioNegocio);
        Task DeleteAsync(int id);
    }
}
