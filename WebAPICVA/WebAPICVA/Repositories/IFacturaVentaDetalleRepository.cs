using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IFacturaVentaDetalleRepository
    {
        Task<IEnumerable<FacturaVentaDetalle>> GetAllAsync();
        Task<FacturaVentaDetalle?> GetByIdAsync(int folio);
        Task AddAsync(FacturaVentaDetalle facturaVentaDetalle);
        Task UpdateAsync(FacturaVentaDetalle facturaVentaDetalle);
        Task DeleteAsync(int folio);
    }
}
