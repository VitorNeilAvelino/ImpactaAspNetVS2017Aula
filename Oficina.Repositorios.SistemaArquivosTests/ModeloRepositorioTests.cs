using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class ModeloRepositorioTests
    {
        ModeloRepositorio _modeloRepositorio = new ModeloRepositorio();
        
        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void SelecionarPorMarcaTest(int marcaId)
        {
            var modelos = _modeloRepositorio.SelecionarPorMarca(marcaId);

            foreach (var modelo in modelos)
            {
                Console.WriteLine($"{modelo.Id} - {modelo.Nome} - {modelo.Marca.Nome}");
            }
        }

        [TestMethod()]
        public void SelecionarPorIdTest()
        {
            Assert.IsNotNull(_modeloRepositorio.Selecionar(1));
        }
    }
}