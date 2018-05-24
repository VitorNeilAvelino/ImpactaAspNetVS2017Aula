using Microsoft.EntityFrameworkCore.Migrations;

namespace Empresa.Repositorios.SqlServer.Migrations
{
    public partial class AdicionarContatoSenha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Contatos",
                nullable: true,
                maxLength: 200);

            migrationBuilder.Sql("Update Contatos set Senha = '123' where Senha is null");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Contatos",
                nullable: false,
                maxLength: 200);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Contatos");
        }
    }
}