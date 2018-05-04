using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Linq;

namespace Loja.Repositorios.WebApi.Tests
{
    [TestClass()]
    public class ProdutoRepositorioTests
    {
        ProdutoRepositorio _repositorio = new ProdutoRepositorio(ConfigurationManager.AppSettings["urlApiNorthwind"] + "Produtos");

        [TestMethod()]
        public void GetTest()
        {
            var produtos = _repositorio.Get().Result;

            Assert.IsTrue(produtos.Count != 0);
        }

        [TestMethod()]
        public void GetByNameTest()
        {
            //https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application
            var produtos = _repositorio.GetByName("caneta").Result;

            Assert.IsTrue(produtos.Count != 0);
        }

        [TestMethod()]
        public void PostTest()
        {
            var produto = new ProductViewModel();
            produto.ProductName= "Corretivo líquido";
            produto.UnitPrice = 16.57m;

            _repositorio.Post(produto).Wait();

            var produtos = _repositorio.Get("name=corretivo").Result;

            Assert.IsTrue(produtos.Count != 0);
        }

        [TestMethod]
        public void PutTeste()
        {
            var produto = _repositorio.Get(47).Result;

            produto.Preco = 17.05m;

            _repositorio.Put(produto.Id, produto).Wait();

            produto = _repositorio.Get(47).Result;

            Assert.AreEqual(produto.Preco, 17.05m);
        }

        [TestMethod]
        public void DeleteTeste()
        {
            _repositorio.Delete(47).Wait();

            var produto = _repositorio.Get(47).Result;

            Assert.IsNull(produto);
        }
    }
}