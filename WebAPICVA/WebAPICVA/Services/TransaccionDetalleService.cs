using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class TransaccionDetalleService : ITransaccionDetalleService
    {
        private readonly ITransaccionDetalleRepository _transaccionDetalleRepository;

        public TransaccionDetalleService(ITransaccionDetalleRepository transaccionDetalleRepository)
        {
            _transaccionDetalleRepository = transaccionDetalleRepository;
        }

        public async Task<IEnumerable<TransaccionDetalle>> GetAllAsync() =>
            await _transaccionDetalleRepository.GetAllAsync();

        public async Task<TransaccionDetalle?> GetByIdAsync(int id_transaccion_detalle) =>
            await _transaccionDetalleRepository.GetByIdAsync(id_transaccion_detalle);

        public async Task AddAsync(TransaccionDetalleDTO transaccionDetalleDto)
        {
            var transaccionDetalle = new TransaccionDetalle
            {
                Id_Transaccion = transaccionDetalleDto.Id_Transaccion,
                Folio_Factura = transaccionDetalleDto.Folio_Factura,
                Tipo_Factura = transaccionDetalleDto.Tipo_Factura,
                Monto = transaccionDetalleDto.Monto
            };
            await _transaccionDetalleRepository.AddAsync(transaccionDetalle);
        }

        public async Task UpdateAsync(int id_transaccion_detalle, TransaccionDetalleDTO transaccionDetalleDto)
        {
            var transaccionDetalle = await _transaccionDetalleRepository.GetByIdAsync(id_transaccion_detalle);
            if (transaccionDetalle == null) return;

            transaccionDetalle.Id_Transaccion = transaccionDetalleDto.Id_Transaccion;
            transaccionDetalle.Folio_Factura = transaccionDetalleDto.Folio_Factura;
            transaccionDetalle.Tipo_Factura = transaccionDetalleDto.Tipo_Factura;
            transaccionDetalle.Monto = transaccionDetalleDto.Monto;
            await _transaccionDetalleRepository.UpdateAsync(transaccionDetalle);
        }

        public async Task DeleteAsync(int id_transaccion_detalle) =>
            await _transaccionDetalleRepository.DeleteAsync(id_transaccion_detalle);

        public async Task<IEnumerable<TransaccionDetalle>> GetFilterTransaccionDetalle(int id_transaccion_detalle) =>
            await _transaccionDetalleRepository.GetFilterTransaccionDetalle(id_transaccion_detalle);
    }
}
