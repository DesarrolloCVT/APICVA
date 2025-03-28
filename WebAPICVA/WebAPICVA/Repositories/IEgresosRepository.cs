using Microsoft.AspNetCore.Mvc;
using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IEgresosRepository
    {
        Task<IEnumerable<Egresos>> GetAllAsync();
        Task<Egresos?> GetByIdAsync(int id_egreso);
        Task AddAsync(Egresos egresos);
        Task UpdateAsync(Egresos egresos);
        Task DeleteAsync(int id_egreso);
    }
}
