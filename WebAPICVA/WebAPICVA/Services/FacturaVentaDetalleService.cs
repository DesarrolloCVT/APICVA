using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class FacturaVentaDetalleService : IFacturaVentaDetalleService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFacturaVentaDetalleRepository _facturaVentaDetalleRepository;

        public FacturaVentaDetalleService(IFacturaVentaDetalleRepository facturaVentaDetalleRepository, ApplicationDbContext applicationDbContext)
        {
            _facturaVentaDetalleRepository = facturaVentaDetalleRepository;
            _context = applicationDbContext;
        }

        public async Task<IEnumerable<FacturaVentaDetalle>> GetAllAsync() =>
            await _facturaVentaDetalleRepository.GetAllAsync();

        public async Task<FacturaVentaDetalle?> GetByIdAsync(int id) =>
            await _facturaVentaDetalleRepository.GetByIdAsync(id);

        public async Task AddAsync(FacturaVentaDetalleDTO facturaVentaDetalleDto)
        {
            var facturaVentaDetalle = new FacturaVentaDetalle
            {
                Id_Factura_Venta = facturaVentaDetalleDto.Id_Factura_Venta,
                Folio = facturaVentaDetalleDto.Folio,
                Codigo_Producto = facturaVentaDetalleDto.Codigo_Producto,
                Cantidad = facturaVentaDetalleDto.Cantidad,
                Precio = facturaVentaDetalleDto.Precio
            };
            await _facturaVentaDetalleRepository.AddAsync(facturaVentaDetalle);
        }

        public async Task UpdateAsync(int id, FacturaVentaDetalleDTO facturaVentaDetalleDto)
        {
            var facturaVentaDetalle = await _facturaVentaDetalleRepository.GetByIdAsync(id);
            if (facturaVentaDetalle == null) return;

            facturaVentaDetalle.Id_Factura_Venta = facturaVentaDetalleDto.Id_Factura_Venta;
            facturaVentaDetalle.Folio = facturaVentaDetalleDto.Folio;
            facturaVentaDetalle.Codigo_Producto = facturaVentaDetalleDto.Codigo_Producto;
            facturaVentaDetalle.Cantidad = facturaVentaDetalleDto.Cantidad;
            facturaVentaDetalle.Precio = facturaVentaDetalleDto.Precio;
            await _facturaVentaDetalleRepository.UpdateAsync(facturaVentaDetalle);
        }

        public async Task DeleteAsync(int id) =>
            await _facturaVentaDetalleRepository.DeleteAsync(id);

        public async Task<IEnumerable<FacturaVentaDetalle>> GetFilterFactVentaDetalle(int id) =>
            await _context.FacturaVentaDetalle.ToListAsync();
    }
}
