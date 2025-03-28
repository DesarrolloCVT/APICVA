﻿using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IIngresosDetalleService
    {
        Task<IEnumerable<IngresosDetalle>> GetAllAsync();
        Task<IngresosDetalle?> GetByIdAsync(int folio);
        Task<IEnumerable<IngresosDetalle>> GetFilterIngresosDetalle(int id);
        Task AddAsync(IngresosDetalleDTO ingresosDetalleDto);
        Task UpdateAsync(int folio, IngresosDetalleDTO ingresosDetalleDto);
        Task DeleteAsync(int folio);
    }
}
