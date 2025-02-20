using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class BancoDetalleService : IBancoDetalleService
    {
        private readonly IBancoDetalleRepository _bancoDetalleRepository;

        public BancoDetalleService(IBancoDetalleRepository bancoDetalleRepository)
        {
            _bancoDetalleRepository = bancoDetalleRepository;
        }

        public async Task<IEnumerable<BancoDetalle>> GetAllAsync() =>
            await _bancoDetalleRepository.GetAllAsync();

        public async Task<BancoDetalle?> GetByIdAsync(int codigo) =>
            await _bancoDetalleRepository.GetByIdAsync(codigo);

        public async Task AddAsync(BancoDetalleDTO bancoDetalleDto)
        {
            var bancoDetalle = new BancoDetalle
            {
                Codigo_Banco = bancoDetalleDto.Codigo_Banco,
                Numero = bancoDetalleDto.Numero
            };
            await _bancoDetalleRepository.AddAsync(bancoDetalle);
        }

        public async Task UpdateAsync(int codigo, BancoDetalleDTO bancoDetalleDto)
        {
            var bancoDetalle = await _bancoDetalleRepository.GetByIdAsync(codigo);
            if (bancoDetalle == null) return;

            bancoDetalle.Codigo_Banco = bancoDetalleDto.Codigo_Banco;
            bancoDetalle.Numero = bancoDetalleDto.Numero;
            await _bancoDetalleRepository.UpdateAsync(bancoDetalle);
        }

        public async Task DeleteAsync(int codigo) =>
            await _bancoDetalleRepository.DeleteAsync(codigo);
    }
}
