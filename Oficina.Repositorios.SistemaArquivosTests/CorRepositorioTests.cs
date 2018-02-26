using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class CorRepositorioTests
    {
        [TestMethod()]
        public void SelecionarTest()
        {
            var repositorio = new CorRepositorio();

            var cores = repositorio.Selecionar();

            foreach (var cor in cores)
            {
                Console.WriteLine($"{cor.Id} - {cor.Nome}");
            }
        }
    }
}