namespace Loja.Repositorios.SqlServer.EF.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarProdutoDescontinuadoParaAtivo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "Ativo", c => c.Boolean(nullable: false, defaultValue: true));
            DropColumn("dbo.Produto", "Descontinuado");

            Sql("Update Produto set Ativo = 1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "Descontinuado", c => c.Boolean(nullable: false));
            DropColumn("dbo.Produto", "Ativo");
        }
    }
}
