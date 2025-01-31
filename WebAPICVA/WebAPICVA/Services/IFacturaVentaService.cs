using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IFacturaVentaService
    {
        Task<IEnumerable<FacturaVenta>> GetAllAsync();
        Task<FacturaVenta?> GetByIdAsync(int folio);
        Task AddAsync(FacturaVentaDTO facturaVentaDto);
        Task UpdateAsync(int folio, FacturaVentaDTO facturaVentaDto);
        Task DeleteAsync(int folio);
    }
}
