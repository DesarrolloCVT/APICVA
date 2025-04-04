using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IMetodoPagoService
    {
        Task<IEnumerable<MetodoPago>> GetAllAsync();
        Task<MetodoPago?> GetByIdAsync(int Id_Metodo_Pago);
        Task AddAsync(MetodoPagoDTO metodoPagoDto);
        Task UpdateAsync(int Id_Metodo_Pago, MetodoPagoDTO metodoPagoDto);
        Task DeleteAsync(int Id_Metodo_Pago);
    }
}
