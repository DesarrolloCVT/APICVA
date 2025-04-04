using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface ITransaccionesRepository
    {
        Task<IEnumerable<Transacciones>> GetAllAsync();
        Task<Transacciones?> GetByIdAsync(int id_transaccion);
        Task AddAsync(Transacciones transacciones);
        Task UpdateAsync(Transacciones transacciones);
        Task DeleteAsync(int id_transaccion);
    }
}
