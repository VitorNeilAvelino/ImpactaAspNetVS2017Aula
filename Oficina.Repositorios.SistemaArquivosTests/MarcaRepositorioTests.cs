using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class MarcaRepositorioTests
    {
        private MarcaRepositorio _repositorio = new MarcaRepositorio();

        [TestMethod()]
        public void SelecionarTodasTest()
        {
            var marcas = _repositorio.Selecionar();

            foreach (var marca in marcas)
            {
                Console.WriteLine($"{marca.Id} - {marca.Nome}");
            }
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(-1)]
        public void SelecionarPorIdTeste(int marcaId)
        {
            var marca = _repositorio.Selecionar(marcaId);

            if (marcaId > 0)
            {
                Assert.IsNotNull(marca);
            }
            else
            {
                Assert.IsNull(marca);
            }
        }
    }
}