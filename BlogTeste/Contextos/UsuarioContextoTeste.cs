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
    public class UsuarioContextoTeste
    {
        #region Atributos
        private BlogPessoalContexto _contexto;
        #endregion

        #region Métodos
        [TestMethod]
        public void InserirNovoUsuarioRetornaUsuarioInserido()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT1")
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
            // QUANDO - Quando eu pesquiso pelo e-mail do usuario adicionado
            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Email ==
            "sixoobecan@gmail.com");
            // ENTÃO - Então deve retornar resultado nao nulo
            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void LerListaDeUsuariosRetornaTresUsuarios()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT2")
            .Options;
            _contexto = new BlogPessoalContexto(opt);
            // DADO - Dado que adiciono 3 usuarios novos no sistema
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Bruno Oliveiros",
                Email = "Bruno@email.com",
                Senha = "134652",
                Foto = "URLFOTOBRUNO",
            });
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "João Lucas Oliveiros",
                Email = "JLOliveiros@email.com",
                Senha = "134652",
                Foto = "URLFOTOJOAO",
            });
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Julia Oliveiros",
                Email = "JuliaO@email.com",
                Senha = "134652",
                Foto = "URLFOTOJULIA",
            });
            _contexto.SaveChanges();
            // QUANDO - Quando eu pesquisar por todos os usuarios
            var resultado = _contexto.Usuarios.ToList();
            // ENTÃO - Então deve retornar uma lista com 3 usuarios
            Assert.AreEqual(3, resultado.Count);
        }
        [TestMethod]
        public void AtualizarUsuarioRetornaUsuarioAtualizado()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT3")
            .Options;
            _contexto = new BlogPessoalContexto(opt);
            // DADO - Dado que adiciono um usuario no sistema
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Zaida Oliveira",
                Email = "Zaida@email.com",
                Senha = "134652",
                Foto = "URLFOTOZAIDA",
            });
            _contexto.SaveChanges();
            // E - E altero seu nome para Zaida Ixoobecan
            var auxiliar = _contexto.Usuarios.FirstOrDefault(u => u.Email ==
            "Zaida@email.com");
            auxiliar.Nome = "Zaida Ixoobecan";
            _contexto.Usuarios.Update(auxiliar);
            _contexto.SaveChanges();
            // QUANDO - Quando pesquiso pelo nome Zaida Ixoobecan
            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Nome == "Zaida Ixoobecan");
            // ENTÃO - Então deve retornar resultado nao nulo
            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void DeletaUsuarioRetornaUsuarioInesistente()
        {
            // Ambiente
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT4")
            .Options;
            _contexto = new BlogPessoalContexto(opt);
            // DADO - Dado que adiciono um usuario no sistema
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Rafael Candeias",
                Email = "rafael@email.com",
                Senha = "134652",
                Foto = "URLFOTORAFAEL",
            });
            _contexto.SaveChanges();
            // QUANDO - Quando deleto o usuario inserido
            var auxiliar = _contexto.Usuarios.FirstOrDefault(u => u.Email ==
            "rafael@email.com");
            _contexto.Usuarios.Remove(auxiliar);
            _contexto.SaveChanges();
            // E - E pesquiso pelo nome Rafael Candeias
            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Nome == "Rafael Candeias");
            // ENTÃO - Então deve retornar resultado nulo
            Assert.IsNull(resultado);
        }
        #endregion
    }
}