namespace Loja.Repositorios.SqlServer.EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProdutoDescontinuadoToAtivo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "Ativo", c => c.Boolean(nullable: false, defaultValue: true));
            Sql("Update Produto set Ativo = Descontinuado ^ 1");
            DropColumn("dbo.Produto", "Descontinuado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "Descontinuado", c => c.Boolean(nullable: false, defaultValue: false));
            Sql("Update Produto set Descontinuado = Ativo ^ 1");
            DropColumn("dbo.Produto", "Ativo");
        }
    }
}
