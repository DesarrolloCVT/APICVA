using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuarios>> GetAllAsync();
        Task<Usuarios?> GetByIdAsync(int idUsuario);
        Task AddAsync(UsuariosDTO usuarioDto);
        Task UpdateAsync(int idUsuario, UsuariosDTO usuarioDto);
        Task DeleteAsync(int idUsuario);
    }
}
