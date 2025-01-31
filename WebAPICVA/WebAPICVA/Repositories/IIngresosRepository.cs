using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IIngresosRepository
    {
        Task<IEnumerable<Ingresos>> GetAllAsync();
        Task<Ingresos?> GetByIdAsync(int folio);
        Task AddAsync(Ingresos ingresos);
        Task UpdateAsync(Ingresos ingresos);
        Task DeleteAsync(int folio);
    }
}
