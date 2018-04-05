namespace Loja.Repositorios.SqlServer.EF.CodeFirst.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RenameProdutoEstoque : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "QuantidadeEstoque", c => c.Int(nullable: false));
            Sql("Update Produto set QuantidadeEstoque = Estoque");
            DropColumn("dbo.Produto", "Estoque");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "Estoque", c => c.Int(nullable: false));
            Sql("Update Produto set Estoque = QuantidadeEstoque");
            DropColumn("dbo.Produto", "QuantidadeEstoque");
        }
    }
}