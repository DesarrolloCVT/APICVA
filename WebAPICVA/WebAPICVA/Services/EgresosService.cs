using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class EgresosService : IEgresosService
    {
        private readonly IEgresosRepository _egresoRepository;

        public EgresosService(IEgresosRepository egresoRepository)
        {
            _egresoRepository = egresoRepository;
        }

        public async Task<IEnumerable<Egresos>> GetAllAsync() =>
            await _egresoRepository.GetAllAsync();

        public async Task<Egresos?> GetByIdAsync(int id_egreso) =>
            await _egresoRepository.GetByIdAsync(id_egreso);

        public async Task AddAsync(EgresosDTO egresoDto)
        {
            var egresos = new Egresos
            {
                Folio = egresoDto.Folio,
                Tipo_Transaccion = egresoDto.Tipo_Transaccion,
                Subtipo_Transaccion = egresoDto.Subtipo_Transaccion,
                Moneda = egresoDto.Moneda,
                Fecha = egresoDto.Fecha,
                Cliente = egresoDto.Cliente,
                Metodo_Pago = egresoDto.Metodo_Pago,
                Banco = egresoDto.Banco,
                Cuenta = egresoDto.Cuenta
            };
            await _egresoRepository.AddAsync(egresos);
        }

        public async Task UpdateAsync(int id_egreso, EgresosDTO egresoDto)
        {
            var egresos = await _egresoRepository.GetByIdAsync(id_egreso);
            if (egresos == null) return;

            egresos.Id_Egreso = egresoDto.Id_Egreso;
            egresos.Folio = egresoDto.Folio;
            egresos.Tipo_Transaccion = egresoDto.Tipo_Transaccion;
            egresos.Subtipo_Transaccion = egresoDto.Subtipo_Transaccion;
            egresos.Moneda = egresoDto.Moneda;
            egresos.Fecha = egresoDto.Fecha;
            egresos.Cliente = egresoDto.Cliente;
            egresos.Metodo_Pago = egresoDto.Metodo_Pago;
            egresos.Banco = egresoDto.Banco;
            egresos.Cuenta = egresoDto.Cuenta;
            await _egresoRepository.UpdateAsync(egresos);
        }

        public async Task DeleteAsync(int id_egreso) =>
            await _egresoRepository.DeleteAsync(id_egreso);
    }
}
