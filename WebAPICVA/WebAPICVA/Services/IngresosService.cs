using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class IngresosService : IIngresosService
    {
        private readonly IIngresosRepository _ingresoRepository;

        public IngresosService(IIngresosRepository ingresoRepository)
        {
            _ingresoRepository = ingresoRepository;
        }

        public async Task<IEnumerable<Ingresos>> GetAllAsync() =>
            await _ingresoRepository.GetAllAsync();

        public async Task<Ingresos?> GetByIdAsync(int folio) =>
            await _ingresoRepository.GetByIdAsync(folio);

        public async Task AddAsync(IngresosDTO ingresoDto)
        {
            var ingresos = new Ingresos
            {
                Folio = ingresoDto.Folio,
                Tipo = ingresoDto.Tipo,
                Moneda = ingresoDto.Moneda,
                Fecha = ingresoDto.Fecha,
                Cliente = ingresoDto.Cliente,
                Metodo_Pago = ingresoDto.Metodo_Pago,
                Banco = ingresoDto.Banco,
                Cuenta = ingresoDto.Cuenta
            };
            await _ingresoRepository.AddAsync(ingresos);
        }

        public async Task UpdateAsync(int folio, IngresosDTO ingresoDto)
        {
            var ingresos = await _ingresoRepository.GetByIdAsync(folio);
            if (ingresos == null) return;

            ingresos.Folio = ingresoDto.Folio;
            ingresos.Tipo = ingresoDto.Tipo;
            ingresos.Moneda = ingresoDto.Moneda;
            ingresos.Cliente = ingresoDto.Cliente;
            ingresos.Metodo_Pago = ingresoDto.Metodo_Pago;
            ingresos.Banco = ingresoDto.Banco;
            ingresos.Cuenta = ingresoDto.Cuenta;
            await _ingresoRepository.UpdateAsync(ingresos);
        }

        public async Task DeleteAsync(int folio) =>
            await _ingresoRepository.DeleteAsync(folio);
    }
}
