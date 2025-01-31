using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(int codigo);
        Task AddAsync(ProductoDTO productoDto);
        Task UpdateAsync(int codigo, ProductoDTO productoDto);
        Task DeleteAsync(int codigo);
    }
}