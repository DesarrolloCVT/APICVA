using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _bancoRepository;

        public BancoService(IBancoRepository bancoRepository)
        {
            _bancoRepository = bancoRepository;
        }

        public async Task<IEnumerable<Banco>> GetAllAsync() =>
            await _bancoRepository.GetAllAsync();

        public async Task<Banco?> GetByIdAsync(int codigo) =>
            await _bancoRepository.GetByIdAsync(codigo);

        public async Task AddAsync(BancoDTO bancoDto)
        {
            var banco = new Banco
            {
                Codigo = bancoDto.Codigo,
                Nombre = bancoDto.Nombre
            };
            await _bancoRepository.AddAsync(banco);
        }

        public async Task UpdateAsync(int codigo, BancoDTO bancoDto)
        {
            var banco = await _bancoRepository.GetByIdAsync(codigo);
            if (banco == null) return;

            banco.Codigo = bancoDto.Codigo;
            banco.Nombre = bancoDto.Nombre;
            await _bancoRepository.UpdateAsync(banco);
        }

        public async Task DeleteAsync(int codigo) =>
            await _bancoRepository.DeleteAsync(codigo);
    }
}
