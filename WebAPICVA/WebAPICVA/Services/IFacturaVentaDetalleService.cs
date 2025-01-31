using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IFacturaVentaDetalleService
    {
        Task<IEnumerable<FacturaVentaDetalle>> GetAllAsync();
        Task<FacturaVentaDetalle?> GetByIdAsync(int folio);
        Task AddAsync(FacturaVentaDetalleDTO facturaVentaDetalleDto);
        Task UpdateAsync(int folio, FacturaVentaDetalleDTO facturaVentaDetalleDto);
        Task DeleteAsync(int folio);
    }
}
