using System.Collections.Generic;
using System.Data.Entity;
using Loja.Dominio;

namespace Loja.Repositorios.SqlServer.EFCodeFirst
{
    internal class LojaInitializer : DropCreateDatabaseIfModelChanges<LojaDbContext>
    {
        protected override void Seed(LojaDbContext context)
        {
            context.Produtos.AddRange(ObterProdutos());

            context.SaveChanges();
        }

        private IEnumerable<Produto> ObterProdutos()
        {
            var grampeador = new Produto();
            grampeador.Nome = "Grampeador";
            grampeador.Preco = 16.06m;
            grampeador.Estoque = 6;
            grampeador.Categoria = new Categoria { Nome = "Papelaria" };

            var penDrive = new Produto();
            penDrive.Nome = "Pen drive";
            penDrive.Preco = 19.22m;
            penDrive.Estoque = 22;
            penDrive.Categoria = new Categoria { Nome = "Informática" }; 

            return new List<Produto> { grampeador, penDrive };
        }
    }
}