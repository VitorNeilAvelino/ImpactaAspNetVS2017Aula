using Loja.Dominio;
using System;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.EFCodeFirst.ModelConfiguration
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            //Property((Produto produto) => produto.Nome).IsRequired();
            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200) ;

            Property(p => p.Preco)
                .HasPrecision(9, 2);

            HasRequired(p => p.Categoria);
        }

        //private object SelecionarPropriedadeNome(Produto produto)
        //{
        //    return produto.Nome;
        //}
    }
}