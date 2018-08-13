using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ViagensOnline.Dominio;

namespace ViagensOnline.Repositorios.SqlServer
{
    public class ViagensOnlineDbContext : DbContext
    {
        public ViagensOnlineDbContext() : base("viagensOnlineConnectionString")
        {

        }

        public DbSet<Destino> Destinos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}