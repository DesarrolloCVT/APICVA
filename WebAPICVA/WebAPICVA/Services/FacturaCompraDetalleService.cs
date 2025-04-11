using Microsoft.EntityFrameworkCore;
using WebAPICVA.Data;
using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class FacturaCompraDetalleService : IFacturaCompraDetalleService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFacturaCompraDetalleRepository _facturaCompraDetalleRepository;

        public FacturaCompraDetalleService(IFacturaCompraDetalleRepository facturaCompraDetalleRepository, ApplicationDbContext applicationDbContext)
        {
            _facturaCompraDetalleRepository = facturaCompraDetalleRepository;
            _context = applicationDbContext;
        }

        public async Task<IEnumerable<FacturaCompraDetalle>> GetAllAsync() =>
            await _facturaCompraDetalleRepository.GetAllAsync();

        public async Task<FacturaCompraDetalle?> GetByIdAsync(int id) =>
            await _facturaCompraDetalleRepository.GetByIdAsync(id);

        public async Task AddAsync(FacturaCompraDetalleDTO facturaCompraDetalleDto)
        {
            var facturaCompraDetalle = new FacturaCompraDetalle
            {
                Id_Factura_Compra = facturaCompraDetalleDto.Id_Factura_Compra,
                Folio = facturaCompraDetalleDto.Folio,
                Codigo_Producto = facturaCompraDetalleDto.Codigo_Producto,
                Cantidad = facturaCompraDetalleDto.Cantidad,
                Precio = facturaCompraDetalleDto.Precio
            };
            await _facturaCompraDetalleRepository.AddAsync(facturaCompraDetalle);
        }

        public async Task UpdateAsync(int id, FacturaCompraDetalleDTO facturaCompraDetalleDto)
        {
            var facturaCompraDetalle = await _facturaCompraDetalleRepository.GetByIdAsync(id);
            if (facturaCompraDetalle == null) return;

            facturaCompraDetalle.Id_Factura_Compra = facturaCompraDetalleDto.Id_Factura_Compra;
            facturaCompraDetalle.Folio = facturaCompraDetalleDto.Folio;
            facturaCompraDetalle.Codigo_Producto = facturaCompraDetalleDto.Codigo_Producto;
            facturaCompraDetalle.Cantidad = facturaCompraDetalleDto.Cantidad;
            facturaCompraDetalle.Precio = facturaCompraDetalleDto.Precio;
            await _facturaCompraDetalleRepository.UpdateAsync(facturaCompraDetalle);
        }

        public async Task DeleteAsync(int folio) =>
            await _facturaCompraDetalleRepository.DeleteAsync(folio);

        public async Task<IEnumerable<FacturaCompraDetalle>> GetFilterFactCompraDetalle(int id) =>
            await _context.FacturaCompraDetalle.ToListAsync();
    }
}
