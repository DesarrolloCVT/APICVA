using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface ITransaccionesService
    {
        Task<IEnumerable<Transacciones>> GetAllAsync();
        Task<Transacciones?> GetByIdAsync(int id_transaccion);
        Task AddAsync(TransaccionesDTO transaccionesDto);
        Task UpdateAsync(int id_transaccion, TransaccionesDTO transaccionesDto);
        Task DeleteAsync(int id_transaccion);
    }
}
