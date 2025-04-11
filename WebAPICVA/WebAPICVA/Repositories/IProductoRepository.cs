using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Productos>> GetAllAsync();
        Task<Productos?> GetByIdAsync(int id);
        Task AddAsync(Productos producto);
        Task UpdateAsync(Productos producto);
        Task DeleteAsync(int id);
    }
}