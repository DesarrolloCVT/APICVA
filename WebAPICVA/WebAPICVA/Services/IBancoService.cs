using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IBancoService
    {
        Task<IEnumerable<Banco>> GetAllAsync();
        Task<Banco?> GetByIdAsync(int codigo);
        Task AddAsync(BancoDTO bancoDto);
        Task UpdateAsync(int codigo, BancoDTO bancoDto);
        Task DeleteAsync(int codigo);
    }
}
