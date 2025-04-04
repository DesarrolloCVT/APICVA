using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IMetodoPagoRepository
    {
        Task<IEnumerable<MetodoPago>> GetAllAsync();
        Task<MetodoPago?> GetByIdAsync(int id);
        Task AddAsync(MetodoPago metodoPago);
        Task UpdateAsync(MetodoPago metodoPago);
        Task DeleteAsync(int id);
    }
}
