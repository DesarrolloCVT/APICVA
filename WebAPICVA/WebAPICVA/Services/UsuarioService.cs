using WebAPICVA.DTOs;
using WebAPICVA.Models;
using WebAPICVA.Repositories;

namespace WebAPICVA.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuarios>> GetAllAsync() =>
            await _usuarioRepository.GetAllAsync();

        public async Task<Usuarios?> GetByIdAsync(int idUsuario) =>
            await _usuarioRepository.GetByIdAsync(idUsuario);

        public async Task<Usuarios?> GetByNameAsync(string UsuarioSistema) =>
            await _usuarioRepository.GetByNameAsync(UsuarioSistema);

        public async Task AddAsync(UsuariosDTO usuarioDto)
        {
            var usuario = new Usuarios
            {
                NombreUsuario = usuarioDto.NombreUsuario,
                UsuarioSistema = usuarioDto.UsuarioSistema,
                ClaveEncriptada = usuarioDto.ClaveEncriptada,
                Clave = usuarioDto.Clave
            };
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task UpdateAsync(int idUsuario, UsuariosDTO usuarioDto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(idUsuario);
            if (usuario == null) return;

            usuario.NombreUsuario = usuarioDto.NombreUsuario;
            usuario.UsuarioSistema = usuarioDto.UsuarioSistema;
            usuario.ClaveEncriptada = usuarioDto.ClaveEncriptada;
            usuario.Clave = usuarioDto.Clave;
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteAsync(int idUsuario) =>
            await _usuarioRepository.DeleteAsync(idUsuario);
    }
}