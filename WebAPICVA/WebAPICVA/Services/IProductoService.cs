using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<Productos>> GetAllAsync();
        Task<Productos?> GetByIdAsync(int id);
        Task AddAsync(ProductosDTO productoDto);
        Task UpdateAsync(int id, ProductosDTO productoDto);
        Task DeleteAsync(int id);
    }
}