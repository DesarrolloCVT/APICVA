using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IMonedasService
    {
        Task<IEnumerable<Moneda>> GetAllAsync();
        Task<Moneda?> GetByIdAsync(int id_Monedas);
        Task AddAsync(MonedaDTO monedaDto);
        Task UpdateAsync(int id_Monedas, MonedaDTO monedaDto);
        Task DeleteAsync(int id_Monedas);
    }
}
