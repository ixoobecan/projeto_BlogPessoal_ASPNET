using BlogAPI.Scr.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogAPI.Scr.Repositorios
{/// <summary>
/// <para>Resumo: Responsavel por representar ações de CRUD de postagem</para>
/// <para>Criado por: Samira Ixoobecan por Gustavo Boaz (Generation)</para>
/// <para>Versão: 1.0</para>
/// <para>Data: 22/08/2022</para>
/// </summary>
    public interface IPostagem
    {
        Task<List<Postagem>> PegarTodasPostagensAsync();
        Task<Postagem> PegarPostagemPeloIdAsync(int id);
        Task NovaPostagemAsync(Postagem postagem);
        Task AtualizarPostagemAsync(Postagem postagem);
        Task DeletarPostagemAsync(int id);
    }
}
