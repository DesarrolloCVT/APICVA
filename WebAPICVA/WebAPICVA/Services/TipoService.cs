﻿using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class TipoService : ITipoService
    {
        private readonly ITipoRepository _tipoRepository;

        public TipoService(ITipoRepository tipoRepository)
        {
            _tipoRepository = tipoRepository;
        }

        public async Task<IEnumerable<Tipo>> GetAllAsync() =>
            await _tipoRepository.GetAllAsync();

        public async Task<Tipo?> GetByIdAsync(int codigo) =>
            await _tipoRepository.GetByIdAsync(codigo);

        public async Task AddAsync(TipoDTO tipoDto)
        {
            var tipo = new Tipo
            {
                Codigo = tipoDto.Codigo,
                Nombre = tipoDto.Nombre,
                Tipo_Dato = tipoDto.Tipo_Dato,
                Cuenta = tipoDto.Cuenta
            };
            await _tipoRepository.AddAsync(tipo);
        }

        public async Task UpdateAsync(int codigo, TipoDTO tipoDto)
        {
            var tipo = await _tipoRepository.GetByIdAsync(codigo);
            if (tipo == null) return;

            tipo.Codigo = tipoDto.Codigo;
            tipo.Nombre = tipoDto.Nombre;
            tipo.Tipo_Dato = tipoDto.Tipo_Dato;
            tipo.Cuenta = tipoDto.Cuenta;
            await _tipoRepository.UpdateAsync(tipo);
        }

        public async Task DeleteAsync(int codigo) =>
            await _tipoRepository.DeleteAsync(codigo);
    }
}
