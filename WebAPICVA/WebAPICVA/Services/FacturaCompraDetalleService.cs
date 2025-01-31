using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class FacturaCompraDetalleService : IFacturaCompraDetalleService
    {
        private readonly IFacturaCompraDetalleRepository _facturaCompraDetalleRepository;

        public FacturaCompraDetalleService(IFacturaCompraDetalleRepository facturaCompraDetalleRepository)
        {
            _facturaCompraDetalleRepository = facturaCompraDetalleRepository;
        }

        public async Task<IEnumerable<FacturaCompraDetalle>> GetAllAsync() =>
            await _facturaCompraDetalleRepository.GetAllAsync();

        public async Task<FacturaCompraDetalle?> GetByIdAsync(int folio) =>
            await _facturaCompraDetalleRepository.GetByIdAsync(folio);

        public async Task AddAsync(FacturaCompraDetalleDTO facturaCompraDetalleDto)
        {
            var facturaCompraDetalle = new FacturaCompraDetalle
            {
                Folio = facturaCompraDetalleDto.Folio,
                Codigo_Producto = facturaCompraDetalleDto.Codigo_Producto,
                Cantidad = facturaCompraDetalleDto.Cantidad,
                Precio = facturaCompraDetalleDto.Precio
            };
            await _facturaCompraDetalleRepository.AddAsync(facturaCompraDetalle);
        }

        public async Task UpdateAsync(int folio, FacturaCompraDetalleDTO facturaCompraDetalleDto)
        {
            var facturaCompraDetalle = await _facturaCompraDetalleRepository.GetByIdAsync(folio);
            if (facturaCompraDetalle == null) return;

            facturaCompraDetalle.Folio = facturaCompraDetalleDto.Folio;
            facturaCompraDetalle.Codigo_Producto = facturaCompraDetalleDto.Codigo_Producto;
            facturaCompraDetalle.Cantidad = facturaCompraDetalleDto.Cantidad;
            facturaCompraDetalle.Precio = facturaCompraDetalleDto.Precio;
            await _facturaCompraDetalleRepository.UpdateAsync(facturaCompraDetalle);
        }

        public async Task DeleteAsync(int folio) =>
            await _facturaCompraDetalleRepository.DeleteAsync(folio);
    }
}
