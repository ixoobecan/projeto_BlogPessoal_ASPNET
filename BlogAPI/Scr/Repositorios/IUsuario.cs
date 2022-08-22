using BlogAPI.Scr.Modelos;
using System.Threading.Tasks;

namespace BlogAPI.Scr.Repositorios
{ /// <summary>
  /// <para>Resumo: Responsavel por representar ações de CRUD de usuario</para>
  /// <para>Criado por:Samira Ixoobecan por Gustavo Boaz (Generation)</para>
  /// <para>Versão: 1.0</para>
  /// <para>Data: 22/08/2022</para>
  /// </summary>
    public interface IUsuario
    {
        Task<Usuario> PegarUsuarioPeloEmailAsync(string email);
        Task NovoUsuarioAsync(Usuario usuario);
    }

}
