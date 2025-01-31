using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Services;

namespace WebAPICVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos() =>
            Ok(await _productoService.GetAllAsync());

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Producto>> GetProducto(int codigo)
        {
            var producto = await _productoService.GetByIdAsync(codigo);
            return producto == null ? NotFound() : Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProducto(ProductoDTO productoDto)
        {
            await _productoService.AddAsync(productoDto);
            return CreatedAtAction(nameof(GetProducto), new { codigo = productoDto.codigo }, productoDto);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutProducto(int codigo, ProductoDTO productoDto)
        {
            await _productoService.UpdateAsync(codigo, productoDto);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteProducto(int codigo)
        {
            await _productoService.DeleteAsync(codigo);
            return NoContent();
        }
    }
}