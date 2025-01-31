using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface ISocioNegocioService
    {
        Task<IEnumerable<SocioNegocio>> GetAllAsync();
        Task<SocioNegocio?> GetByIdAsync(int codigo);
        Task AddAsync(SocioNegocioDTO socioNegocioDto);
        Task UpdateAsync(int codigo, SocioNegocioDTO socioNegocioDto);
        Task DeleteAsync(int codigo);
    }
}
