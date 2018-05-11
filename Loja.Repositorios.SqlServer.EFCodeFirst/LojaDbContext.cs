using Loja.Dominio;
using Loja.Repositorios.SqlServer.EFCodeFirst.Migrations;
using Loja.Repositorios.SqlServer.EFCodeFirst.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Loja.Repositorios.SqlServer.EFCodeFirst
{
    public class LojaDbContext : IdentityDbContext<Usuario>
    {
        public LojaDbContext() : base("name=lojaConnectionString")
        {
            //Database.SetInitializer(new LojaDbInitializer());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LojaDbContext, Configuration>());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
        }
    }
}
