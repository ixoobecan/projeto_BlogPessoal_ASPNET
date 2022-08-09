using BlogAPI.Scr.Contextos;
using BlogAPI.Scr.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTeste.Contextos
{
    [TestClass]
    public class PostagemContextoTeste
    {
        #region Atributos
        private BlogPessoalContexto _contexto;
        #endregion

        #region Métodos
        [TestMethod]
        public void InserirNovaPostagemRetornaPostagemInserida()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_PCT1")
            .Options;
            _contexto = new BlogPessoalContexto(opt);
            // DADO - Dado que adiciono um usuario no sistema
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Samira Ixoobecan",
                Email = "sixoobecan@gmail.com",
                Senha = "134652",
                Foto = "URLFOTOSAMI",
            });
            _contexto.SaveChanges();
            // E - E adciono um tema
            _contexto.Temas.Add(new Tema
            {
                Descricao = "HARRY POTTER"
            });
            _contexto.SaveChanges();
            // E - E adciono uma novapostagem com o usuario e o tema acima
            _contexto.Postagens.Add(new Postagem
            {
                Titulo = "FANFICS QUE FIZERAM HISTORIA",
                Descricao = "VOCÊ já conhece o Floreios e Borroes",
                Foto = "URLDAFOTO",
                Criador = _contexto.Usuarios.FirstOrDefault(u => u.Email ==
                "sixoobecan@gmail.com"),
                Tema = _contexto.Temas.FirstOrDefault(t => t.Descricao == "HARRY POTTER")
            });
            _contexto.SaveChanges();
            // QUANDO - Quando eu pesquiso pelo titulo da postagem adicionada
            var resultado = _contexto.Postagens.FirstOrDefault(p => p.Titulo ==
            "FANFICS QUE FIZERAM HISTORIA");
            // ENTÃO - Então deve retornar resultado nao nulo
            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void LerListaDePostagensRetornaTresPostagens()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_PCT2")
            .Options;
            _contexto = new BlogPessoalContexto(opt);
            // DADO - Dado que adiciono um usuario no sistema
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Samira Ixoobecan",
                Email = "sixoobecan@gmail.com",
                Senha = "134652",
                Foto = "URLFOTOSAMI",
            });
            _contexto.SaveChanges();
            // E - E adciono um tema
            _contexto.Temas.Add(new Tema
            {
                Descricao = "HARRY POTTER"
            });
            _contexto.SaveChanges();
            // E - E adciono uma 3 postagens com o usuario e o tema acima
            _contexto.Postagens.Add(new Postagem
            {
                Titulo = "FICSONGS E COMO FOI NOSTALGICO",
                Descricao = "SAUDADES DE ACHAR ESSE TIPO DE CONTEUDO FACIL",
                Foto = "URLDAFOTO",
                Criador = _contexto.Usuarios.FirstOrDefault(u => u.Email ==
                "sixoobecan@gmail.com"),
                Tema = _contexto.Temas.FirstOrDefault(t => t.Descricao == "HARRY POTTER")
            });
            _contexto.SaveChanges();
            // QUANDO - Quando eu pesquisar por todas as postagens
            var resultado = _contexto.Postagens.ToList();
            // ENTÃO - Então deve retornar uma lista com 2 postagens
            Assert.AreEqual(1, resultado.Count);
        }
        [TestMethod]
        public void AtualizarPostagenRetornaPostagenAtualizado()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_PCT3")
            .Options;
            _contexto = new BlogPessoalContexto(opt);
            // DADO - Dado que adiciono um usuario no sistema
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Samira Ixoobecan",
                Email = "sixoobecan@gmail.com",
                Senha = "134652",
                Foto = "URLFOTOSAMI",
            });
            _contexto.SaveChanges();
            // E - E adciono um tema
            _contexto.Temas.Add(new Tema
            {
                Descricao = "HARRY POTTER"
            });
            _contexto.SaveChanges();
            // E - E adciono uma postagen com o usuario e o tema acima
            _contexto.Postagens.Add(new Postagem
            {
                Titulo = "RONNY O MELHOR AMIGO",
                Descricao = "O RUIVO MAIS AMADO VEIO AO BRASIL",
                Foto = "URLDAFOTO",
                Criador = _contexto.Usuarios.FirstOrDefault(u => u.Email == "sixoobecan@gmail.com"),
                Tema = _contexto.Temas.FirstOrDefault(t => t.Descricao == "HARRY POTTER")
            });
            _contexto.SaveChanges();
            // E - E altero sua descrição
            var auxiliar = _contexto.Postagens.FirstOrDefault(p => p.Id == 1);
            auxiliar.Descricao = "O RUIVO MAIS AMADO VEIO AO BRASIL E FALOU SOBRE NOVOS PROJETOS";
            _contexto.Postagens.Update(auxiliar);
            _contexto.SaveChanges();
            // QUANDO - Quando pesquiso pela postegem alterada
            var resultado = _contexto.Postagens.FirstOrDefault(p => p.Id == 1);
            // ENTÃO - Então deve retornar alteração
            Assert.AreEqual("O RUIVO MAIS AMADO VEIO AO BRASIL E FALOU SOBRE NOVOS PROJETOS",
            resultado.Descricao);
        }
        [TestMethod]
        public void DeletaPostagemRetornaPostagemInesistente()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_PCT4")
            .Options;
            _contexto = new BlogPessoalContexto(opt);
            // DADO - Dado que adiciono um usuario no sistema
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Samira Ixoobecan",
                Email = "sixoobecan@gmail.com",
                Senha = "134652",
                Foto = "URLFOTOSAMI",
            });
            _contexto.SaveChanges();
            // E - E adciono um tema
            _contexto.Temas.Add(new Tema
            {
                Descricao = "HARRY POTTER"
            });
            _contexto.SaveChanges();
            // E - E adciono uma postagen com o usuario e o tema acima
            _contexto.Postagens.Add(new Postagem
            {
                Titulo = "cansei de criar titulos",
                Descricao = "Blablablaa escrito ERRADO",
                Foto = "URLDAFOTO",
                Criador = _contexto.Usuarios.FirstOrDefault(u => u.Email ==
                "sixoobecan@gmail.com"),
                Tema = _contexto.Temas.FirstOrDefault(t => t.Descricao == "HARRY POTTER")
            });
            _contexto.SaveChanges();
            // QUANDO - Quando deleto a postagem inserida
            var auxiliar = _contexto.Postagens.FirstOrDefault(p => p.Titulo ==
            "cansei de criar titulos");
            _contexto.Postagens.Remove(auxiliar);
            _contexto.SaveChanges();
            // E - E pesquiso pelo ttitulo da postagem ASP.NET
            var resultado = _contexto.Postagens.FirstOrDefault(p => p.Titulo ==
            "cansei de criar titulos");
            // ENTÃO - Então deve retornar resultado nulo
            Assert.IsNull(resultado);
        }
        #endregion
    }
}








