using System;
using System.Collections.Generic;
using System.Data.Entity;
using Loja.Dominio;

namespace Loja.Repositorios.SqlServer.EFCodeFirst
{
    internal class LojaDbInitializer : DropCreateDatabaseIfModelChanges<LojaDbContext>
    {
        protected override void Seed(LojaDbContext context)
        {
            context.Produtos.AddRange(ObterProdutos());

            context.SaveChanges();
        }

        private IEnumerable<Produto> ObterProdutos()
        {
            var grampeador = new Produto();
            grampeador.Categoria = new Categoria() { Nome = "Papelaria" };
            grampeador.Ativo = false;
            grampeador.Estoque = 38;
            grampeador.Nome = "Grampeador";
            grampeador.Preco = 9.38m;

            var penDrive = new Produto();
            penDrive.Categoria = new Categoria { Nome = "Informática" };
            penDrive.Ativo = false;
            penDrive.Estoque = 420;
            penDrive.Nome = "Pen drive";
            penDrive.Preco = 9.42m;

            return new List<Produto>() { grampeador, penDrive };
        }
    }
}