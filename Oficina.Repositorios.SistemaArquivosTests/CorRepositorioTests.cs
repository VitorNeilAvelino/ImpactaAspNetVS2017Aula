using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class CorRepositorioTests
    {
        [TestMethod()]
        public void SelecionarTest()
        {
            var corRepositorio = new CorRepositorio();

            var cores = corRepositorio.Selecionar();

            foreach (var cor in cores)
            {
                Console.WriteLine($"{cor.Id} - {cor.Nome}");
            }
        }
    }
}