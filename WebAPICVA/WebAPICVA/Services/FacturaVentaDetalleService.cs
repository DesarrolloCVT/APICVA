using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class FacturaVentaDetalleService : IFacturaVentaDetalleService
    {
        private readonly IFacturaVentaDetalleRepository _facturaVentaDetalleRepository;

        public FacturaVentaDetalleService(IFacturaVentaDetalleRepository facturaVentaDetalleRepository)
        {
            _facturaVentaDetalleRepository = facturaVentaDetalleRepository;
        }

        public async Task<IEnumerable<FacturaVentaDetalle>> GetAllAsync() =>
            await _facturaVentaDetalleRepository.GetAllAsync();

        public async Task<FacturaVentaDetalle?> GetByIdAsync(int folio) =>
            await _facturaVentaDetalleRepository.GetByIdAsync(folio);

        public async Task AddAsync(FacturaVentaDetalleDTO facturaVentaDetalleDto)
        {
            var facturaVentaDetalle = new FacturaVentaDetalle
            {
                Folio = facturaVentaDetalleDto.Folio,
                Codigo_Producto = facturaVentaDetalleDto.Codigo_Producto,
                Cantidad = facturaVentaDetalleDto.Cantidad,
                Precio = facturaVentaDetalleDto.Precio
            };
            await _facturaVentaDetalleRepository.AddAsync(facturaVentaDetalle);
        }

        public async Task UpdateAsync(int folio, FacturaVentaDetalleDTO facturaVentaDetalleDto)
        {
            var facturaVentaDetalle = await _facturaVentaDetalleRepository.GetByIdAsync(folio);
            if (facturaVentaDetalle == null) return;

            facturaVentaDetalle.Folio = facturaVentaDetalleDto.Folio;
            facturaVentaDetalle.Codigo_Producto = facturaVentaDetalleDto.Codigo_Producto;
            facturaVentaDetalle.Cantidad = facturaVentaDetalleDto.Cantidad;
            facturaVentaDetalle.Precio = facturaVentaDetalleDto.Precio;
            await _facturaVentaDetalleRepository.UpdateAsync(facturaVentaDetalle);
        }

        public async Task DeleteAsync(int folio) =>
            await _facturaVentaDetalleRepository.DeleteAsync(folio);
    }
}
