using WebAPICVA.Models;

namespace WebAPICVA.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuarios>> GetAllAsync();
        Task<Usuarios?> GetByIdAsync(int idUsuario);
        Task<Usuarios?> GetByNameAsync(string UsuarioSistema);
        Task AddAsync(Usuarios usuario);
        Task UpdateAsync(Usuarios usuario);
        Task DeleteAsync(int idUsuario);
    }
}
