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
        public async Task<ActionResult<IEnumerable<Productos>>> GetProductos() =>
            Ok(await _productoService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProducto(int id)
        {
            var producto = await _productoService.GetByIdAsync(id);
            return producto == null ? NotFound() : Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProducto(ProductosDTO productoDto)
        {
            await _productoService.AddAsync(productoDto);
            return CreatedAtAction(nameof(GetProducto), new { id = productoDto.Id_Producto }, productoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, ProductosDTO productoDto)
        {
            await _productoService.UpdateAsync(id, productoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            await _productoService.DeleteAsync(id);
            return NoContent();
        }
    }
}