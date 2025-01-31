using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IFacturaVentaRepository
    {
        Task<IEnumerable<FacturaVenta>> GetAllAsync();
        Task<FacturaVenta?> GetByIdAsync(int folio);
        Task AddAsync(FacturaVenta facturaVenta);
        Task UpdateAsync(FacturaVenta facturaVenta);
        Task DeleteAsync(int folio);
    }
}
