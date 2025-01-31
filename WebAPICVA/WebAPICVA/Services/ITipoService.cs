using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface ITipoService
    {
        Task<IEnumerable<Tipo>> GetAllAsync();
        Task<Tipo?> GetByIdAsync(int codigo);
        Task AddAsync(TipoDTO tipoDto);
        Task UpdateAsync(int codigo, TipoDTO tipoDto);
        Task DeleteAsync(int codigo);
    }
}
