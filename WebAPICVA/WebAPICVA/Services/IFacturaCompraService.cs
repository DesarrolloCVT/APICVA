using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IFacturaCompraService
    {
        Task<IEnumerable<FacturaCompra>> GetAllAsync();
        Task<FacturaCompra?> GetByIdAsync(int folio);
        Task AddAsync(FacturaCompraDTO facturaCompraDto);
        Task UpdateAsync(int folio, FacturaCompraDTO facturaCompraDto);
        Task DeleteAsync(int folio);
    }
}
