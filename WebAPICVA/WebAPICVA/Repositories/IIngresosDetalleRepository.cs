using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IIngresosDetalleRepository
    {
        Task<IEnumerable<IngresosDetalle>> GetAllAsync();
        Task<IngresosDetalle?> GetByIdAsync(int folio);
        Task<IEnumerable<IngresosDetalle>> GetFilterIngresosDetalle(int id);
        Task AddAsync(IngresosDetalle ingresosDetalle);
        Task UpdateAsync(IngresosDetalle ingresosDetalle);
        Task DeleteAsync(int folio);
    }
}
