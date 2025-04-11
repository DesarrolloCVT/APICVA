using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IFacturaVentaDetalleRepository
    {
        Task<IEnumerable<FacturaVentaDetalle>> GetAllAsync();
        Task<FacturaVentaDetalle?> GetByIdAsync(int id);
        Task<IEnumerable<FacturaVentaDetalle>> GetFilterFactVentaDetalle(int id);
        Task AddAsync(FacturaVentaDetalle facturaVentaDetalle);
        Task UpdateAsync(FacturaVentaDetalle facturaVentaDetalle);
        Task DeleteAsync(int id);
    }
}
