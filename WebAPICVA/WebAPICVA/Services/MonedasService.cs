using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class MonedasService : IMonedasService
    {
        private readonly IMonedasRepository _monedasRepository;

        public MonedasService(IMonedasRepository monedasRepository)
        {
            _monedasRepository = monedasRepository;
        }

        public async Task<IEnumerable<Moneda>> GetAllAsync() =>
            await _monedasRepository.GetAllAsync();

        public async Task<Moneda?> GetByIdAsync(int id) =>
            await _monedasRepository.GetByIdAsync(id);

        public async Task AddAsync(MonedaDTO monedaDto)
        {
            var moneda = new Moneda
            {
                Id_Monedas = monedaDto.Id_Monedas,
                Nombre = monedaDto.Nombre
            };
            await _monedasRepository.AddAsync(moneda);
        }

        public async Task UpdateAsync(int id, MonedaDTO monedaDto)
        {
            var moneda = await _monedasRepository.GetByIdAsync(id);
            if (moneda == null) return;

            moneda.Id_Monedas = monedaDto.Id_Monedas;
            moneda.Nombre = monedaDto.Nombre;
            await _monedasRepository.UpdateAsync(moneda);
        }

        public async Task DeleteAsync(int id) =>
            await _monedasRepository.DeleteAsync(id);
    }
}
