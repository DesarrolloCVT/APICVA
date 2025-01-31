using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IFacturaCompraDetalleRepository
    {
        Task<IEnumerable<FacturaCompraDetalle>> GetAllAsync();
        Task<FacturaCompraDetalle?> GetByIdAsync(int folio);
        Task AddAsync(FacturaCompraDetalle facturaCompraDetalle);
        Task UpdateAsync(FacturaCompraDetalle facturaCompraDetalle);
        Task DeleteAsync(int folio);
    }
}
