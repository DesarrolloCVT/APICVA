using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class MetodoPagoService : IMetodoPagoService
    {
        private readonly IMetodoPagoRepository _metodoPagoRepository;

        public MetodoPagoService(IMetodoPagoRepository metodoPagoRepository)
        {
            _metodoPagoRepository = metodoPagoRepository;
        }

        public async Task<IEnumerable<MetodoPago>> GetAllAsync() =>
            await _metodoPagoRepository.GetAllAsync();

        public async Task<MetodoPago?> GetByIdAsync(int id) =>
            await _metodoPagoRepository.GetByIdAsync(id);

        public async Task AddAsync(MetodoPagoDTO metodoPagoDto)
        {
            var metodoPago = new MetodoPago
            {
                Id_Metodo_Pago = metodoPagoDto.Id_Metodo_Pago,
                Nombre = metodoPagoDto.Nombre
            };
            await _metodoPagoRepository.AddAsync(metodoPago);
        }

        public async Task UpdateAsync(int id, MetodoPagoDTO metodoPagoDto)
        {
            var metodoPago = await _metodoPagoRepository.GetByIdAsync(id);
            if (metodoPago == null) return;

            metodoPago.Id_Metodo_Pago = metodoPagoDto.Id_Metodo_Pago;
            metodoPago.Nombre = metodoPagoDto.Nombre;
            await _metodoPagoRepository.UpdateAsync(metodoPago);
        }

        public async Task DeleteAsync(int id) =>
            await _metodoPagoRepository.DeleteAsync(id);
    }
}
