using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Repositorios.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.WebApi.Tests
{
    [TestClass()]
    public class ProductRepositorioTests
    {
        private ProductRepositorio _repositorio = new ProductRepositorio();

        [TestMethod()]
        public void PostTest()
        {
            var product = new ProductViewModel();
            product.ProductName = "Café";
            product.UnitsInStock = 35;
            product.UnitPrice = 11.36m;

            var response = _repositorio.Post(product).Result;

            Console.WriteLine(response.ProductID);
        }

        [TestMethod()]
        public void PutTest()
        {
            var product = new ProductViewModel();
            product.ProductName = "Café com leite";
            product.UnitsInStock = 49;
            product.UnitPrice = 11.48m;
            product.ProductID = 81;

            _repositorio.Put(product.ProductID, product).Wait();

            var response = _repositorio.Get(81).Result;

            Assert.AreEqual(response.UnitPrice, 11.48m);
        }

        [TestMethod]
        public void GetTest()
        {
            var produtos = _repositorio.Get().Result;

            Assert.IsTrue(produtos.Count > 1);
        }

        [TestMethod]
        public void DeleteTeste()
        {
            _repositorio.Delete(81).Wait();

            var produto = _repositorio.Get(81).Result;

            Assert.IsNull(produto);
        }

        [TestMethod]
        public void GetProductOrdersTeste()
        {
            var pedidos = _repositorio.GetProductOrders(34).Result;

            Assert.IsTrue(pedidos.Count > 0);
        }
    }
}