using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Northwind.Repositorios.WebApi.Tests
{
    [TestClass()]
    public class ProdutoRepositorioTests
    {
        ProdutoRepositorio _repositorio = new ProdutoRepositorio(ConfigurationManager.AppSettings["urlApiNorthwind"] + "Products");

        [TestMethod()]
        public void GetTest()
        {
            var produtos = _repositorio.Get().Result;

            Assert.IsTrue(produtos.Count > 1);
        }

        [TestMethod()]
        public void PostTest()
        {
            var produto = new ProductViewModel();
            produto.ProductName= "Geleia de pimenta";
            produto.UnitPrice = 13.21m;

            var produtoResponse = _repositorio.Post(produto).Result;

            System.Console.WriteLine(produtoResponse.ProductID);
        }

        [TestMethod]
        public void PutTeste()
        {
            var produto = _repositorio.Get(79).Result;

            produto.UnitPrice = 17.05m;
            produto.UnitsInStock = 23;

            _repositorio.Put(produto.ProductID, produto).Wait();

            produto = _repositorio.Get(79).Result;

            Assert.AreEqual(produto.UnitPrice, 17.05m);
        }

        [TestMethod]
        public void DeleteTeste()
        {
            _repositorio.Delete(79).Wait();

            var produto = _repositorio.Get(79).Result;

            Assert.IsNull(produto);
        }

        [TestMethod]
        public void GetProductOrdersTeste()
        {
            var pedidos = _repositorio.GetProductOrders(27).Result;

            Assert.IsTrue(pedidos.Count > 1);
        }
    }
}