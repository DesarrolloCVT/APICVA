using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class FacturaCompraService : IFacturaCompraService
    {
        private readonly IFacturaCompraRepository _facturaCompraRepository;

        public FacturaCompraService(IFacturaCompraRepository facturaCompraRepository)
        {
            _facturaCompraRepository = facturaCompraRepository;
        }

        public async Task<IEnumerable<FacturaCompra>> GetAllAsync() =>
            await _facturaCompraRepository.GetAllAsync();

        public async Task<FacturaCompra?> GetByIdAsync(int folio) =>
            await _facturaCompraRepository.GetByIdAsync(folio);

        public async Task AddAsync(FacturaCompraDTO facturaCompraDto)
        {
            var facturaCompra = new FacturaCompra
            {
                Folio = facturaCompraDto.Folio,
                Proveedor = facturaCompraDto.Proveedor,
                Fecha = facturaCompraDto.Fecha,
                Moneda = facturaCompraDto.Moneda
            };
            await _facturaCompraRepository.AddAsync(facturaCompra);
        }

        public async Task UpdateAsync(int folio, FacturaCompraDTO facturaCompraDto)
        {
            var facturaCompra = await _facturaCompraRepository.GetByIdAsync(folio);
            if (facturaCompra == null) return;

            facturaCompra.Folio = facturaCompraDto.Folio;
            facturaCompra.Proveedor = facturaCompraDto.Proveedor;
            facturaCompra.Fecha = facturaCompraDto.Fecha;
            facturaCompra.Moneda = facturaCompraDto.Moneda;
            await _facturaCompraRepository.UpdateAsync(facturaCompra);
        }

        public async Task DeleteAsync(int folio) =>
            await _facturaCompraRepository.DeleteAsync(folio);

        public async Task<IEnumerable<FacturaCompra>> GetFilterFactCompra() =>
            await _facturaCompraRepository.GetFilterFactCompra();
    }
}
