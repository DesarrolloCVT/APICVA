using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class IngresosDetalleService : IIngresosDetalleService
    {
        private readonly IIngresosDetalleRepository _ingresoDetalleRepository;

        public IngresosDetalleService(IIngresosDetalleRepository ingresoDetalleRepository)
        {
            _ingresoDetalleRepository = ingresoDetalleRepository;
        }

        public async Task<IEnumerable<IngresosDetalle>> GetAllAsync() =>
            await _ingresoDetalleRepository.GetAllAsync();

        public async Task<IngresosDetalle?> GetByIdAsync(int folio) =>
            await _ingresoDetalleRepository.GetByIdAsync(folio);

        public async Task AddAsync(IngresosDetalleDTO ingresoDetalleDto)
        {
            var ingresosDetalle = new IngresosDetalle
            {
                Folio_FacturaVenta = ingresoDetalleDto.Folio_FacturaVenta,
                Monto = ingresoDetalleDto.Monto
            };
            await _ingresoDetalleRepository.AddAsync(ingresosDetalle);
        }

        public async Task UpdateAsync(int folio, IngresosDetalleDTO ingresoDetalleDto)
        {
            var ingresosDetalle = await _ingresoDetalleRepository.GetByIdAsync(folio);
            if (ingresosDetalle == null) return;

            ingresosDetalle.Folio_FacturaVenta = ingresoDetalleDto.Folio_FacturaVenta;
            ingresosDetalle.Monto = ingresoDetalleDto.Monto;
            await _ingresoDetalleRepository.UpdateAsync(ingresosDetalle);
        }

        public async Task DeleteAsync(int folio) =>
            await _ingresoDetalleRepository.DeleteAsync(folio);
    }
}
