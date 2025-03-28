using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IIngresosService
    {
        Task<IEnumerable<Ingresos>> GetAllAsync();
        Task<Ingresos?> GetByIdAsync(int id_ingreso);
        Task AddAsync(IngresosDTO ingresosDto);
        Task UpdateAsync(int id_ingreso, IngresosDTO ingresosDto);
        Task DeleteAsync(int id_ingreso);
    }
}
