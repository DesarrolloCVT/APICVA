using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface ICuentasService
    {
        Task<IEnumerable<Cuentas>> GetAllAsync();
        Task<Cuentas?> GetByIdAsync(int id);
        Task AddAsync(CuentasDTO cuentasDto);
        Task UpdateAsync(int id, CuentasDTO cuentasDto);
        Task DeleteAsync(int id);
    }
}
