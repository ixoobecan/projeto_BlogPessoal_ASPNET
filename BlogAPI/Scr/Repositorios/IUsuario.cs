using BlogAPI.Scr.Modelos;
using System.Threading.Tasks;

namespace BlogAPI.Scr.Repositorios
{
    public interface IUsuario
    {
        Task<Usuario> PegarUsuarioPeloEmailAsync(string email);
        Task NovoUsuarioAsync(Usuario usuario);
    }

}
