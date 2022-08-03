using BlogAPI.Scr.Modelos;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Scr.Contextos
{
    public class BlogPessoalContexto : DbContext
    {
        #region Atributos

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Postagem> Postagens { get; set; }

        #endregion


        #region Construtores

        public BlogPessoalContexto(DbContextOptions<BlogPessoalContexto> opt) : base(opt)
        {

        }

        #endregion
    }
}