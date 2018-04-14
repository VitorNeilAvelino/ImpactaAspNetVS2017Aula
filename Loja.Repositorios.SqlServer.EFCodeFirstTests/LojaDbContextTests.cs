using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorios.SqlServer.EFCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Dominio;
using System.Diagnostics;
using System.Data.Entity;

namespace Loja.Repositorios.SqlServer.EFCodeFirst.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        LojaDbContext _db = new LojaDbContext();

        public LojaDbContextTests()
        {
            _db.Database.Log = LogarQueries;
        }

        private void LogarQueries(string query)
        {
            Debug.Write(query);
        }

        [TestMethod()]
        public void SelecionarTodasCategoriasTeste()
        {
            var categorias = _db.Categorias.ToList();
        }

        [TestMethod]
        public void InserirProdutoTeste()
        {
            var produto = new Produto();

            produto.Estoque = 16;
            produto.Nome = "Caneta";
            produto.Preco = 16.25m;

            //produto.Categoria = new Categoria();
            //produto.Categoria = _db.Categorias.Where((Categoria c) => c.Nome == "Papelaria")
            //produto.Categoria = _db.Categorias.Where(c => c.Nome == "Papelaria").First();
            //produto.Categoria = _db.Categorias.Where(c => c.Nome == "Papelaria").Single();
            produto.Categoria = _db.Categorias.Single(c => c.Id == 1);

            _db.Produtos.Add(produto);
            _db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoComNovaCategoriaTeste()
        {
            var produto = new Produto();

            produto.Estoque = 16;
            produto.Nome = "Barbeador";
            produto.Preco = 16.25m;

            //produto.Categoria = new Categoria();
            //produto.Categoria = _db.Categorias.Where((Categoria c) => c.Nome == "Papelaria")
            //produto.Categoria = _db.Categorias.Where(c => c.Nome == "Papelaria").First();
            //produto.Categoria = _db.Categorias.Where(c => c.Nome == "Papelaria").Single();
            //produto.Categoria = _db.Categorias.Single(c => c.Id == 1);
            produto.Categoria = new Categoria { Nome = "Perfumaria" };

            _db.Produtos.Add(produto);
            _db.SaveChanges();
        }

        [TestMethod]
        public void EditarProdutoTeste()
        {
            var produto = (from p in _db.Produtos
                          where p.Nome == "Barbeador"
                          select p).First();

            produto.Preco = 16.54m;
            produto.Nome = "Barbeador Editado";

            _db.SaveChanges();
        }

        [TestMethod]
        public void ExcluirProdutoTeste()
        {
            var produto = _db.Produtos.Single(p => p.Nome == "Barbeador Editado");

            _db.Produtos.Remove(produto);

            _db.SaveChanges();
        }

        [TestMethod]
        public void LazyLoadDesligadoTeste()
        {
            var produto = _db.Produtos.Single(p => p.Id == 1);

            Assert.IsNull(produto.Categoria);
        }

        [TestMethod]
        public void IncludeTeste()
        {
            var produto = _db.Produtos.Include(p => p.Categoria).Single(p => p.Id == 1);

            Assert.IsTrue(produto.Categoria.Nome == "Perfumaria");
        }

        [TestMethod]
        public void QueryableTeste()
        {
            var query = _db.Produtos.Where(p => p.Preco > 10);

            if (true)
            {
                query = query.Where(p => p.Estoque > 5);
            }

            query = query.OrderBy(p => p.Preco);

            var primeiro = query.First();
            //var ultimo = query.Last();
            var unico = query.Single();
            var todos = query.ToList();
        }
    }
}