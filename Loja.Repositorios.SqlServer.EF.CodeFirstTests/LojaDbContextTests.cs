using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Dominio;
using System.Diagnostics;
using System.Linq;
using System;

namespace Loja.Repositorios.SqlServer.EF.CodeFirst.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private static LojaDbContext _db = new LojaDbContext();

        public LojaDbContextTests()
        {
            _db.Database.Log = LogarQueries;
        }

        private void LogarQueries(string query)
        {
            Debug.Write(query);
        }

        [TestMethod()]
        public void LojaDbContextTest()
        {
            var categoria = new Categoria { Nome = "Perfumaria" };

            _db.Categorias.Add(categoria);

            _db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoTeste()
        {
            var produto = new Produto();
            produto.Estoque = 43;
            produto.Nome = "Caneta";
            produto.Preco = 21.43m;

            produto.Categoria = _db.Categorias.Single((Categoria categoria) => categoria.Nome == "Papelaria");
        }

        private bool SelecionarPapelaria(Categoria arg)
        {
            throw new NotImplementedException();
        }

        [ClassCleanup]
        public static void LimparReferencias()
        {
            _db.Dispose();
        }
    }
}