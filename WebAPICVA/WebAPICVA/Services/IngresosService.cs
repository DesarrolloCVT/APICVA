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

        public async Task<Ingresos?> GetByIdAsync(int id_ingreso) =>
            await _ingresoRepository.GetByIdAsync(id_ingreso);

        public async Task AddAsync(IngresosDTO ingresoDto)
        {
            var ingresos = new Ingresos
            {
                Folio = ingresoDto.Folio,
                Tipo_Transaccion = ingresoDto.Tipo_Transaccion,
                Subtipo_Transaccion = ingresoDto.Subtipo_Transaccion,
                Moneda = ingresoDto.Moneda,
                Fecha = ingresoDto.Fecha,
                Cliente = ingresoDto.Cliente,
                Metodo_Pago = ingresoDto.Metodo_Pago,
                Banco = ingresoDto.Banco,
                Cuenta = ingresoDto.Cuenta
            };
            await _ingresoRepository.AddAsync(ingresos);
        }

        public async Task UpdateAsync(int id_ingreso, IngresosDTO ingresoDto)
        {
            var ingresos = await _ingresoRepository.GetByIdAsync(id_ingreso);
            if (ingresos == null) return;

            ingresos.Id_Ingreso = ingresoDto.Id_Ingreso;
            ingresos.Folio = ingresoDto.Folio;
            ingresos.Tipo_Transaccion = ingresoDto.Tipo_Transaccion;
            ingresos.Subtipo_Transaccion = ingresoDto.Subtipo_Transaccion;
            ingresos.Moneda = ingresoDto.Moneda;
            ingresos.Fecha = ingresoDto.Fecha;
            ingresos.Cliente = ingresoDto.Cliente;
            ingresos.Metodo_Pago = ingresoDto.Metodo_Pago;
            ingresos.Banco = ingresoDto.Banco;
            ingresos.Cuenta = ingresoDto.Cuenta;
            await _ingresoRepository.UpdateAsync(ingresos);
        }

        public async Task DeleteAsync(int id_ingreso) =>
            await _ingresoRepository.DeleteAsync(id_ingreso);
    }
}
