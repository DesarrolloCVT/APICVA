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

        public async Task<IEnumerable<Producto>> GetAllAsync() =>
            await _productoRepository.GetAllAsync();

        public async Task<Producto?> GetByIdAsync(int codigo) =>
            await _productoRepository.GetByIdAsync(codigo);

        public async Task AddAsync(ProductoDTO productoDto)
        {
            var producto = new Producto
            {
                codigo = productoDto.codigo,
                producto = productoDto.producto
            };
            await _productoRepository.AddAsync(producto);
        }

        public async Task UpdateAsync(int codigo, ProductoDTO productoDto)
        {
            var producto = await _productoRepository.GetByIdAsync(codigo);
            if (producto == null) return;

            producto.codigo = productoDto.codigo;
            producto.producto = productoDto.producto;
            await _productoRepository.UpdateAsync(producto);
        }

        public async Task DeleteAsync(int codigo) =>
            await _productoRepository.DeleteAsync(codigo);
    }
}