using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IFacturaCompraDetalleService
    {
        Task<IEnumerable<FacturaCompraDetalle>> GetAllAsync();
        Task<FacturaCompraDetalle?> GetByIdAsync(int folio);
        Task AddAsync(FacturaCompraDetalleDTO facturaCompraDetalleDto);
        Task UpdateAsync(int folio, FacturaCompraDetalleDTO facturaCompraDetalleDto);
        Task DeleteAsync(int folio);
    }
}
