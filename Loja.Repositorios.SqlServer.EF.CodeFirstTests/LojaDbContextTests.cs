using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Dominio;
using System.Diagnostics;

namespace Loja.Repositorios.SqlServer.EF.CodeFirst.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private LojaDbContext _db = new LojaDbContext();

        public LojaDbContextTests()
        {
            _db.Database.Log = LogarQueries;
        }

        private void LogarQueries(string querie)
        {
            Debug.Write(querie);
        }

        [TestMethod()]
        public void LojaDbContextTest()
        {
            var categoria = new Categoria { Nome = "Papelaria" };

            _db.Categorias.Add(categoria);

            _db.SaveChanges();
        }
    }
}