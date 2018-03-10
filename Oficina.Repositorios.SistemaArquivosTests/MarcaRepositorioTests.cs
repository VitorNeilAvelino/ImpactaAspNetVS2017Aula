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
    public class MarcaRepositorioTests
    {
        MarcaRepositorio _repositorio = new MarcaRepositorio();

        [TestMethod()]
        public void SelecionarTest()
        {
            var marcas = _repositorio.Selecionar();

            foreach (var marca in marcas)
            {
                Console.WriteLine($"{marca.Id} - {marca.Nome}");
            }
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(-1)]
        public void SelecionarPorIdTest(int marcaId)
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