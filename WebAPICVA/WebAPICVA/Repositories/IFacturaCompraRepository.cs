﻿using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IFacturaCompraRepository
    {
        Task<IEnumerable<FacturaCompra>> GetAllAsync();
        Task<FacturaCompra?> GetByIdAsync(int folio);
        Task<IEnumerable<FacturaCompra>> GetFilterFactCompra();
        Task AddAsync(FacturaCompra facturaCompra);
        Task UpdateAsync(FacturaCompra facturaCompra);
        Task DeleteAsync(int folio);
    }
}
