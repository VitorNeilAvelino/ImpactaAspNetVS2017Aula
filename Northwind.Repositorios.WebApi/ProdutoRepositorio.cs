using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Loja.Repositorios.WebApi
{
    public class ProdutoRepositorio : RepositorioBase<ProductViewModel>
    {
        private string _urlProdutos;

        public ProdutoRepositorio(string urlProdutos) : base(urlProdutos)
        {
            _urlProdutos = urlProdutos;
        }

        public async Task<List<ProductViewModel>> GetProductOrders(int id)
        {
            using (var response = await Cliente.GetAsync($"{_urlProdutos}/{id}/orders"))
            {
                return await response.Content.ReadAsAsync<List<ProductViewModel>>();
            }
        }
    }

    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
        public Nullable<short> UnitsOnOrder { get; set; }
        public Nullable<short> ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}