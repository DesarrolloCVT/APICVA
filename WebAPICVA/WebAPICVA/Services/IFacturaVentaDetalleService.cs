using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IFacturaVentaDetalleService
    {
        Task<IEnumerable<FacturaVentaDetalle>> GetAllAsync();
        Task<FacturaVentaDetalle?> GetByIdAsync(int id);
        Task<IEnumerable<FacturaVentaDetalle>> GetFilterFactVentaDetalle(int id);
        Task AddAsync(FacturaVentaDetalleDTO facturaVentaDetalleDto);
        Task UpdateAsync(int id, FacturaVentaDetalleDTO facturaVentaDetalleDto);
        Task DeleteAsync(int id);
    }
}
