using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class SubTiposService : ISubTiposService
    {
        private readonly ISubTiposRepository _subTiposRepository;

        public SubTiposService(ISubTiposRepository subTipoRepository)
        {
            _subTiposRepository = subTipoRepository;
        }

        public async Task<IEnumerable<Subtipos>> GetAllAsync() =>
            await _subTiposRepository.GetAllAsync();

        public async Task<Subtipos?> GetByIdAsync(int id) =>
            await _subTiposRepository.GetByIdAsync(id);

        public async Task AddAsync(SubtiposDTO subTipoDto)
        {
            var subTipo = new Subtipos
            {
                Id_Subtipos = subTipoDto.Id_Subtipos,
                Identificador = subTipoDto.Identificador,
                Nombre = subTipoDto.Nombre
            };
            await _subTiposRepository.AddAsync(subTipo);
        }

        public async Task UpdateAsync(int id, SubtiposDTO subTipoDto)
        {
            var subTipo = await _subTiposRepository.GetByIdAsync(id);
            if (subTipo == null) return;

            subTipo.Id_Subtipos = subTipoDto.Id_Subtipos;
            subTipo.Identificador = subTipoDto.Identificador;
            subTipo.Nombre = subTipoDto.Nombre;
            await _subTiposRepository.UpdateAsync(subTipo);
        }

        public async Task DeleteAsync(int id) =>
            await _subTiposRepository.DeleteAsync(id);
    }
}
