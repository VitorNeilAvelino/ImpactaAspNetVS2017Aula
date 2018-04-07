using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.EFCodeFirst.ModelConfiguration
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            //ToTable("Categoria");

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}