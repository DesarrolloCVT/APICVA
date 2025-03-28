using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IFacturaCompraDetalleService
    {
        Task<IEnumerable<FacturaCompraDetalle>> GetAllAsync();
        Task<FacturaCompraDetalle?> GetByIdAsync(int id);
        Task AddAsync(FacturaCompraDetalleDTO facturaCompraDetalleDto);
        Task UpdateAsync(int id, FacturaCompraDetalle facturaCompraDetalleDto);
        Task DeleteAsync(int id);
    }
}
