using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface ITipoRepository
    {
        Task<IEnumerable<Tipo>> GetAllAsync();
        Task<Tipo?> GetByIdAsync(int codigo);
        Task AddAsync(Tipo tipo);
        Task UpdateAsync(Tipo tipo);
        Task DeleteAsync(int codigo);
    }
}
