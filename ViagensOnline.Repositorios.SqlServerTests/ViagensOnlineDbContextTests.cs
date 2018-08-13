using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagensOnline.Dominio;

namespace ViagensOnline.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class ViagensOnlineDbContextTests
    {
        private ViagensOnlineDbContext _db = new ViagensOnlineDbContext();

        [TestMethod()]
        public void InserirTeste()
        {
            var destino = new Destino();

            destino.CaminhoFoto = "Paulista.png";
            destino.Cidade = "São Paulo";
            destino.Nome = "São Paulo";
            destino.Pais = "Brasil";

            _db.Destinos.Add(destino);

            _db.SaveChanges();
        }

        [TestMethod]
        public void AtualizarTeste()
        {
            var destino = _db.Destinos.Find(1);

            destino.Pais = "Brazil";

            _db.SaveChanges();
        }

        [TestMethod]
        public void ExcluirTeste()
        {
            var destino = _db.Destinos.Find(1);

            _db.Destinos.Remove(destino);

            _db.SaveChanges();
        }
    }
}