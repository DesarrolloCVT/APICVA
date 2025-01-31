using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IIngresosService
    {
        Task<IEnumerable<Ingresos>> GetAllAsync();
        Task<Ingresos?> GetByIdAsync(int folio);
        Task AddAsync(IngresosDTO ingresosDto);
        Task UpdateAsync(int folio, IngresosDTO ingresosDto);
        Task DeleteAsync(int folio);
    }
}
