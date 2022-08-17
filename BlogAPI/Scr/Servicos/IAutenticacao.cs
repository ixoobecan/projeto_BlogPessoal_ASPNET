using System.Threading.Tasks;
using BlogAPI.Scr.Modelos;
namespace BlogAPI.Src.Servicos
{
  
public interface IAutenticacao
    {
        string CodificarSenha(string senha);
        Task CriarUsuarioSemDuplicarAsync(Usuario usuario);
        string GerarToken(Usuario usuario);
    }
}
