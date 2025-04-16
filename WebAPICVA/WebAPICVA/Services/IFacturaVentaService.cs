using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IFacturaVentaService
    {
        Task<IEnumerable<FacturaVenta>> GetAllAsync();
        Task<FacturaVenta?> GetByIdAsync(int id);
        Task<IEnumerable<FacturaVenta>> GetFilterFactVenta();
        Task AddAsync(FacturaVentaDTO facturaVentaDto);
        Task UpdateAsync(int id, FacturaVentaDTO facturaVentaDto);
        Task DeleteAsync(int id);
    }
}
