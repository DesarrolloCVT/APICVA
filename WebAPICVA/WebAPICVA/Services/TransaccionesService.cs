using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class TransaccionesService : ITransaccionesService
    {
        private readonly ITransaccionesRepository _transaccionesRepository;

        public TransaccionesService(ITransaccionesRepository transaccionesRepository)
        {
            _transaccionesRepository = transaccionesRepository;
        }

        public async Task<IEnumerable<Transacciones>> GetAllAsync() =>
            await _transaccionesRepository.GetAllAsync();

        public async Task<Transacciones?> GetByIdAsync(int id_transaccion) =>
            await _transaccionesRepository.GetByIdAsync(id_transaccion);

        public async Task AddAsync(TransaccionesDTO transaccionesDto)
        {
            var transacciones = new Transacciones
            {
                Folio = transaccionesDto.Folio,
                Tipo_Transaccion = transaccionesDto.Tipo_Transaccion,
                Subtipo_Transaccion = transaccionesDto.Subtipo_Transaccion,
                Moneda = transaccionesDto.Moneda,
                Fecha = transaccionesDto.Fecha,
                Cliente = transaccionesDto.Cliente,
                Metodo_Pago = transaccionesDto.Metodo_Pago,
                Banco = transaccionesDto.Banco,
                Cuenta = transaccionesDto.Cuenta
            };
            await _transaccionesRepository.AddAsync(transacciones);
        }

        public async Task UpdateAsync(int id_transaccion, TransaccionesDTO transaccionesDto)
        {
            var transacciones = await _transaccionesRepository.GetByIdAsync(id_transaccion);
            if (transacciones == null) return;

            transacciones.Id_Transaccion = transaccionesDto.Id_Transaccion;
            transacciones.Folio = transaccionesDto.Folio;
            transacciones.Tipo_Transaccion = transaccionesDto.Tipo_Transaccion;
            transacciones.Subtipo_Transaccion = transaccionesDto.Subtipo_Transaccion;
            transacciones.Moneda = transaccionesDto.Moneda;
            transacciones.Fecha = transaccionesDto.Fecha;
            transacciones.Cliente = transaccionesDto.Cliente;
            transacciones.Metodo_Pago = transaccionesDto.Metodo_Pago;
            transacciones.Banco = transaccionesDto.Banco;
            transacciones.Cuenta = transaccionesDto.Cuenta;
            await _transaccionesRepository.UpdateAsync(transacciones);
        }

        public async Task DeleteAsync(int id_transaccion) =>
            await _transaccionesRepository.DeleteAsync(id_transaccion);
    }
}
