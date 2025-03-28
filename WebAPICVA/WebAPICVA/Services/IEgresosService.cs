using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IEgresosService
    {
        Task<IEnumerable<Egresos>> GetAllAsync();
        Task<Egresos?> GetByIdAsync(int id_egreso);
        Task AddAsync(EgresosDTO egresosDto);
        Task UpdateAsync(int id_egreso, EgresosDTO egresosDto);
        Task DeleteAsync(int id_egreso);
    }
}
