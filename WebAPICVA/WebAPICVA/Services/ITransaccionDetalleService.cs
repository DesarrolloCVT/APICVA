using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface ITransaccionDetalleService
    {
        Task<IEnumerable<TransaccionDetalle>> GetAllAsync();
        Task<TransaccionDetalle?> GetByIdAsync(int folio);
        Task<IEnumerable<TransaccionDetalle>> GetFilterTransaccionDetalle(int id_transaccion_detalle);
        Task AddAsync(TransaccionDetalleDTO ingresosDetalleDto);
        Task UpdateAsync(int id_transaccion_detalle, TransaccionDetalleDTO transaccionDetalleDto);
        Task DeleteAsync(int id_transaccion_detalle);
    }
}
