using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface ISubTiposService
    {
        Task<IEnumerable<Subtipos>> GetAllAsync();
        Task<Subtipos?> GetByIdAsync(int Id_Subtipos);
        Task AddAsync(SubtiposDTO subTipoDto);
        Task UpdateAsync(int Id_Subtipos, SubtiposDTO subTipoDto);
        Task DeleteAsync(int Id_Subtipos);
    }
}
