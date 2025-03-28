using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IFacturaCompraDetalleRepository
    {
        Task<IEnumerable<FacturaCompraDetalle>> GetAllAsync();
        Task<FacturaCompraDetalle?> GetByIdAsync(int id);
        Task AddAsync(FacturaCompraDetalle facturaCompraDetalle);
        Task UpdateAsync(FacturaCompraDetalle facturaCompraDetalle);
        Task DeleteAsync(int id);
    }
}
