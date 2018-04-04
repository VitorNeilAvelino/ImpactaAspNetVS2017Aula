namespace Loja.Repositorios.SqlServer.EF.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Loja.Repositorios.SqlServer.EF.CodeFirst.LojaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Loja.Repositorios.SqlServer.EF.CodeFirst.LojaDbContext";
        }

        protected override void Seed(Loja.Repositorios.SqlServer.EF.CodeFirst.LojaDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
