using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IMonedasRepository
    {
        Task<IEnumerable<Moneda>> GetAllAsync();
        Task<Moneda?> GetByIdAsync(int id_Monedas);
        Task AddAsync(Moneda moneda);
        Task UpdateAsync(Moneda moneda);
        Task DeleteAsync(int id_Monedas);
    }
}
