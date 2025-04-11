using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class SocioNegocioService : ISocioNegocioService
    {
        private readonly ISocioNegocioRepository _socioNegocioRepository;

        public SocioNegocioService(ISocioNegocioRepository socioNegocioRepository)
        {
            _socioNegocioRepository = socioNegocioRepository;
        }

        public async Task<IEnumerable<SocioNegocio>> GetAllAsync() =>
            await _socioNegocioRepository.GetAllAsync();

        public async Task<SocioNegocio?> GetByIdAsync(int id) =>
            await _socioNegocioRepository.GetByIdAsync(id);

        public async Task AddAsync(SocioNegocioDTO socioNegocioDto)
        {
            var socioNegocio = new SocioNegocio
            {
                Codigo = socioNegocioDto.Codigo,
                Nombre = socioNegocioDto.Nombre,
                Tipo = socioNegocioDto.Tipo,
                Saldo = socioNegocioDto.Saldo
            };
            await _socioNegocioRepository.AddAsync(socioNegocio);
        }

        public async Task UpdateAsync(int id, SocioNegocioDTO socioNegocioDto)
        {
            var socioNegocio = await _socioNegocioRepository.GetByIdAsync(id);
            if (socioNegocio == null) return;

            socioNegocio.Codigo = socioNegocioDto.Codigo;
            socioNegocio.Nombre = socioNegocioDto.Nombre;
            socioNegocio.Tipo = socioNegocioDto.Tipo;
            socioNegocio.Saldo = socioNegocioDto.Saldo;
            await _socioNegocioRepository.UpdateAsync(socioNegocio);
        }

        public async Task DeleteAsync(int id) =>
            await _socioNegocioRepository.DeleteAsync(id);
    }
}
