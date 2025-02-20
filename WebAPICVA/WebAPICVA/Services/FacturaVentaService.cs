using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class FacturaVentaService : IFacturaVentaService
    {
        private readonly IFacturaVentaRepository _facturaVentaRepository;

        public FacturaVentaService(IFacturaVentaRepository facturaVentaRepository)
        {
            _facturaVentaRepository = facturaVentaRepository;
        }

        public async Task<IEnumerable<FacturaVenta>> GetAllAsync() =>
            await _facturaVentaRepository.GetAllAsync();

        public async Task<FacturaVenta?> GetByIdAsync(int codigo) =>
            await _facturaVentaRepository.GetByIdAsync(codigo);

        public async Task AddAsync(FacturaVentaDTO facturaVentaDto)
        {
            var facturaVenta = new FacturaVenta
            {
                Folio = facturaVentaDto.Folio,
                Cliente = facturaVentaDto.Cliente,
                Direccion_Despacho = facturaVentaDto.Direccion_Despacho,
                Moneda = facturaVentaDto.Moneda,
                Fecha = facturaVentaDto.Fecha
            };
            await _facturaVentaRepository.AddAsync(facturaVenta);
        }

        public async Task UpdateAsync(int folio, FacturaVentaDTO facturaVentaDto)
        {
            var facturaVenta = await _facturaVentaRepository.GetByIdAsync(folio);
            if (facturaVenta == null) return;

            facturaVenta.Folio = facturaVentaDto.Folio;
            facturaVenta.Cliente = facturaVentaDto.Cliente;
            facturaVenta.Direccion_Despacho = facturaVentaDto.Direccion_Despacho;
            facturaVenta.Moneda = facturaVentaDto.Moneda;
            facturaVenta.Fecha = facturaVentaDto.Fecha;
            await _facturaVentaRepository.UpdateAsync(facturaVenta);
        }

        public async Task DeleteAsync(int folio) =>
            await _facturaVentaRepository.DeleteAsync(folio);
    }
}
