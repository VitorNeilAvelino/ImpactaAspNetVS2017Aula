using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.EFCodeFirst.ModelConfiguration
{
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            HasMany(p => p.Itens)
                .WithMany(pr => pr.Pedidos)
                .Map(pp => pp.ToTable("ProdutoPedido"));
        }
    }
}