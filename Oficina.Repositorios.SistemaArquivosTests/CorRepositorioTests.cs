using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class CorRepositorioTests
    {
        CorRepositorio _repositorio = new CorRepositorio();

        [TestMethod()]
        public void SelecionarTest()
        {
            var cores = _repositorio.Selecionar();

            foreach (var cor in cores)
            {
                Console.WriteLine($"{cor.Id} - {cor.Nome}");
            }
        }

        [TestMethod()]
        public void SelecionarPorIdTest()
        {
            Assert.IsNotNull(_repositorio.Selecionar(1));
        }
    }
}