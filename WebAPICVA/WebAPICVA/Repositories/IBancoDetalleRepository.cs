using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IBancoDetalleRepository
    {
        Task<IEnumerable<BancoDetalle>> GetAllAsync();
        Task<BancoDetalle?> GetByIdAsync(int codigo);
        Task AddAsync(BancoDetalle bancoDetalle);
        Task UpdateAsync(BancoDetalle bancoDetalle);
        Task DeleteAsync(int codigo);
    }
}
