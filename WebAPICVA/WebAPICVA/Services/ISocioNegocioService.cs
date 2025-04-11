using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface ISocioNegocioService
    {
        Task<IEnumerable<SocioNegocio>> GetAllAsync();
        Task<SocioNegocio?> GetByIdAsync(int id);
        Task AddAsync(SocioNegocioDTO socioNegocioDto);
        Task UpdateAsync(int id, SocioNegocioDTO socioNegocioDto);
        Task DeleteAsync(int id);
    }
}
