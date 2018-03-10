using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class ModeloRepositorioTests
    {
        ModeloRepositorio _repositorio = new ModeloRepositorio();

        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void SelecionarPorMarcaTest(int marcaId)
        {
            var modelos = _repositorio.SelecionarPorMarca(marcaId);

            Assert.IsTrue(modelos.Count != 0);
        }
    }
}