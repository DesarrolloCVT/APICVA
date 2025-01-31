using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IBancoRepository
    {
        Task<IEnumerable<Banco>> GetAllAsync();
        Task<Banco?> GetByIdAsync(int codigo);
        Task AddAsync(Banco banco);
        Task UpdateAsync(Banco banco);
        Task DeleteAsync(int codigo);
    }
}
