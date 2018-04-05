namespace Loja.Repositorios.SqlServer.EF.CodeFirst.Migrations
{
    using Loja.Dominio;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Loja.Repositorios.SqlServer.EF.CodeFirst.LojaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Loja.Repositorios.SqlServer.EF.CodeFirst.LojaDbContext";
        }

        protected override void Seed(LojaDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Categorias.AddOrUpdate(c => c.Nome, new Categoria { Nome = "Telefonia" });
        }
    }
}