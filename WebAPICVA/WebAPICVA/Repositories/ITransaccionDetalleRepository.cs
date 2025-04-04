using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface ITransaccionDetalleRepository
    {
        Task<IEnumerable<TransaccionDetalle>> GetAllAsync();
        Task<TransaccionDetalle?> GetByIdAsync(int id_transaccion_detalle);
        Task<IEnumerable<TransaccionDetalle>> GetFilterTransaccionDetalle(int id);
        Task AddAsync(TransaccionDetalle transaccionDetalle);
        Task UpdateAsync(TransaccionDetalle transaccionDetalle);
        Task DeleteAsync(int id);
    }
}
