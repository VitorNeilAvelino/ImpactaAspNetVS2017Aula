using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class ModeloRepositorioTests
    {
        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void SelecionarPorMarcaTest(int marcaId)
        {
            var modeloRepositorio = new ModeloRepositorio();

            var modelos = modeloRepositorio.SelecionarPorMarca(marcaId);

            foreach (var modelo in modelos)
            {
                Console.WriteLine($"{modelo.Id} - {modelo.Descricao} - {modelo.Marca.Nome}");
            }
        }
    }
}