using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface ICuentasService
    {
        Task<IEnumerable<Cuentas>> GetAllAsync();
        Task<Cuentas?> GetByIdAsync(int codigo);
        Task AddAsync(CuentasDTO cuentasDto);
        Task UpdateAsync(int codigo, CuentasDTO cuentasDto);
        Task DeleteAsync(int codigo);
    }
}
