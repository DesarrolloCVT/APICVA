using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IBancoDetalleService
    {
        Task<IEnumerable<BancoDetalle>> GetAllAsync();
        Task<BancoDetalle?> GetByIdAsync(int codigo);
        Task AddAsync(BancoDetalleDTO bancoDetalleDto);
        Task UpdateAsync(int codigo, BancoDetalleDTO bancoDetalleDto);
        Task DeleteAsync(int codigo);
    }
}
