using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface ISubTiposRepository
    {
        Task<IEnumerable<Subtipos>> GetAllAsync();
        Task<Subtipos?> GetByIdAsync(int Id_Subtipos);
        Task AddAsync(Subtipos subTipos);
        Task UpdateAsync(Subtipos subTipos);
        Task DeleteAsync(int Id_Subtipos);
    }
}
