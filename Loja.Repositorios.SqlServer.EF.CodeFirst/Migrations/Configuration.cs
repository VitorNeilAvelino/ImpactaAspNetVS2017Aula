namespace Loja.Repositorios.SqlServer.EF.CodeFirst.Migrations
{
    using Loja.Dominio;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LojaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Loja.Repositorios.SqlServer.EF.CodeFirst.LojaDbContext";
        }

        protected override void Seed(LojaDbContext context)
        {
            context.Categorias.AddOrUpdate(c => c.Nome, new Categoria { Nome = "Papelaria" });
            context.Categorias.AddOrUpdate(c => c.Nome, new Categoria { Nome = "Informática" });

            context.SaveChanges();

            context.Produtos.AddOrUpdate(c => c.Nome, new Produto
            {
                Nome = "Grampeador",
                Preco = 16.06m,
                QuantidadeEstoque = 6,
                Categoria = context.Categorias.Single(c => c.Nome == "Papelaria")
            });

            context.Produtos.AddOrUpdate(c => c.Nome, new Produto
            {
                Nome = "Pen drive",
                Preco = 16.29m,
                QuantidadeEstoque = 29,
                Categoria = context.Categorias.Single(c => c.Nome == "Informática")
            });

            context.SaveChanges();
        }
    }
}