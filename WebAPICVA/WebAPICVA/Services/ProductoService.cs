using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Productos>> GetAllAsync() =>
            await _productoRepository.GetAllAsync();

        public async Task<Productos?> GetByIdAsync(int codigo) =>
            await _productoRepository.GetByIdAsync(codigo);

        public async Task AddAsync(ProductosDTO productoDto)
        {
            var producto = new Productos
            {
                Id_Producto = productoDto.Id_Producto,
                Codigo = productoDto.Codigo,
                Producto = productoDto.Producto
            };
            await _productoRepository.AddAsync(producto);
        }

        public async Task UpdateAsync(int id, ProductosDTO productoDto)
        {
            var producto = await _productoRepository.GetByIdAsync(id);
            if (producto == null) return;

            producto.Codigo = productoDto.Codigo;
            producto.Producto = productoDto.Producto;
            await _productoRepository.UpdateAsync(producto);
        }

        public async Task DeleteAsync(int id) =>
            await _productoRepository.DeleteAsync(id);
    }
}