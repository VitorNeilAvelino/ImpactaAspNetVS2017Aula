namespace Loja.Repositorios.SqlServer.EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Cod = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Cod);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Cliente_Cod = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Cod)
                .Index(t => t.Cliente_Cod);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                        Preco = c.Decimal(nullable: false, precision: 9, scale: 2),
                        Estoque = c.Int(nullable: false),
                        Descontinuado = c.Boolean(nullable: false),
                        Categoria_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id, cascadeDelete: true)
                .Index(t => t.Categoria_Id);
            
            CreateTable(
                "dbo.ProdutoPedido",
                c => new
                    {
                        Pedido_Id = c.Int(nullable: false),
                        Produto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pedido_Id, t.Produto_Id })
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.Produto_Id, cascadeDelete: true)
                .Index(t => t.Pedido_Id)
                .Index(t => t.Produto_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoPedido", "Produto_Id", "dbo.Produto");
            DropForeignKey("dbo.ProdutoPedido", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.Produto", "Categoria_Id", "dbo.Categoria");
            DropForeignKey("dbo.Pedido", "Cliente_Cod", "dbo.Cliente");
            DropIndex("dbo.ProdutoPedido", new[] { "Produto_Id" });
            DropIndex("dbo.ProdutoPedido", new[] { "Pedido_Id" });
            DropIndex("dbo.Produto", new[] { "Categoria_Id" });
            DropIndex("dbo.Pedido", new[] { "Cliente_Cod" });
            DropTable("dbo.ProdutoPedido");
            DropTable("dbo.Produto");
            DropTable("dbo.Pedido");
            DropTable("dbo.Cliente");
            DropTable("dbo.Categoria");
        }
    }
}
