using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class CuentasService : ICuentasService
    {
        private readonly ICuentasRepository _cuentasRepository;

        public CuentasService(ICuentasRepository cuentasRepository)
        {
            _cuentasRepository = cuentasRepository;
        }

        public async Task<IEnumerable<Cuentas>> GetAllAsync() =>
            await _cuentasRepository.GetAllAsync();

        public async Task<Cuentas?> GetByIdAsync(int id) =>
            await _cuentasRepository.GetByIdAsync(id);

        public async Task AddAsync(CuentasDTO cuentasDto)
        {
            var cuentas = new Cuentas
            {
                Codigo = cuentasDto.Codigo,
                Nombre = cuentasDto.Nombre,
                Tipo = cuentasDto.Tipo
            };
            await _cuentasRepository.AddAsync(cuentas);
        }

        public async Task UpdateAsync(int id, CuentasDTO cuentasDto)
        {
            var cuentas = await _cuentasRepository.GetByIdAsync(id);
            if (cuentas == null) return;

            cuentas.Codigo = cuentasDto.Codigo;
            cuentas.Nombre = cuentasDto.Nombre;
            cuentas.Tipo = cuentasDto.Tipo;
            await _cuentasRepository.UpdateAsync(cuentas);
        }

        public async Task DeleteAsync(int id) =>
            await _cuentasRepository.DeleteAsync(id);
    }
}
