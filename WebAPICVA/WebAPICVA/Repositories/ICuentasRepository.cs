using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface ICuentasRepository
    {
        Task<IEnumerable<Cuentas>> GetAllAsync();
        Task<Cuentas?> GetByIdAsync(int id);
        Task AddAsync(Cuentas cuentas);
        Task UpdateAsync(Cuentas cuentas);
        Task DeleteAsync(int id);
    }
}
